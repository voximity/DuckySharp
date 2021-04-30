﻿using HidLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DuckySharp {
    public class DeviceNotFoundException : Exception {
        public DeviceNotFoundException() : base("No relevant device found.") { }
    }

    public class WrongDeviceStateException : Exception {
        public bool Expected;

        public WrongDeviceStateException(bool expected) : base("Device was not in correct state (initialized/uninitialized) for this operation.") {
            Expected = expected;
        }
    }

    public class Keyboard {
        private HidDevice device;
        private bool initialized;
        private Dictionary<Key, Color> keyColorBuffer;

        public async Task sendPacketAsync(byte[] packet) {
            await device.WriteAsync(packet);
        }

        private void sendPacket(byte[] packet) {
            device.Write(packet);
        }

        private byte[] buildColorMessage() {
            byte[] message = new byte[640];

            // copy start packet to the message
            Constants.StartPacket.CopyTo(message, 1);

            // copy the header for each packet
            for (byte i = 0; i < 8; i++)
                new byte[] { 0x56, 0x83, i }.CopyTo(message, (i + 1) * 64 + 1);

            // add extra data to first color packet
            Constants.InitColorBytes.CopyTo(message, 64 + 5);

            // add the terminate color packet
            Constants.TerminateColorBytes.CopyTo(message, 9 * 64 + 1);

            return message;
        }

        public bool Initialized => initialized;

        public Keyboard() {
            // find related devices
            HidDevice[] devices = HidDevices.Enumerate(Constants.VendorID, Constants.ProductID).Where((device) => device.IsConnected).ToArray();

            if (devices.Length < 0) {
                throw new DeviceNotFoundException();
            }

            // take the first device
            device = devices[0];

            // set up the color buffer
            keyColorBuffer = new Dictionary<Key, Color>();
            foreach (Key key in Keys.All) {
                keyColorBuffer[key] = new Color(0, 0, 0);
            }
        }

        public void Initialize() {
            if (initialized) throw new WrongDeviceStateException(expected: false);

            foreach (byte[] packet in Constants.TakeoverBytes) {
                sendPacket(packet);
            }

            initialized = true;
        }

        public void Close() {
            if (!initialized) throw new WrongDeviceStateException(expected: true);

            foreach (byte[] packet in Constants.ReleaseBytes) {
                sendPacket(packet);
            }

            initialized = false;
        }

        public void SetKeyColor(Key key, Color color) {
            if (!keyColorBuffer.ContainsKey(key)) throw new ArgumentException("Invalid key. Must be one defined in the Keys class.");

            keyColorBuffer[key] = color;
        }

        public void Update() {
            if (!initialized) throw new WrongDeviceStateException(expected: true);

            byte[] message = buildColorMessage();

            foreach ((Key key, Color color) in keyColorBuffer) {
                message[key.PacketNum * 64 + key.OffsetNum + 1] = color.R;

                if (key.OffsetNum == 63) {
                    message[key.PacketNum * 64 + key.OffsetNum + 6] = color.G;
                    message[key.PacketNum * 64 + key.OffsetNum + 7] = color.B;
                } else {
                    message[key.PacketNum * 64 + key.OffsetNum + 2] = color.G;
                    message[key.PacketNum * 64 + key.OffsetNum + 3] = color.B;
                }
            }

            byte[][] split = new byte[10][];
            for (int i = 0; i < 10; i++) {
                split[i] = new byte[i < 9 ? 65 : 64];
                for (int j = 0; j < split[i].Length; j++) {
                    split[i][j] = message[i * 64 + j];
                }
            }

            for (int i = 0; i < 10; i++) {
                device.Write(split[i]);
                Thread.Sleep(2);
            }
        }
    }
}