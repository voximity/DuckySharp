using System;
using System.Linq;
using System.Threading;
using HidLibrary;
using DuckySharp;

namespace DuckySharp.Test {
    class Program {
        static Keyboard keyboard;

        static void Main(string[] args) {
            keyboard = new Keyboard();
            keyboard.Initialize();

            Thread.Sleep(1000);

            double cx = 7;
            double cy = 3;

            DateTime lastFrame = DateTime.Now;
            double t = 0;
            while (true) {
                DateTime now = DateTime.Now;
                t += (now - lastFrame).TotalSeconds;
                lastFrame = now;

                foreach (Key key in Keys.All) {
                    double angle = Math.Atan2(key.Y - cy, key.X - cx) * 180 / Math.PI;
                    int r, g, b;
                    HsvGarbage.HsvToRgb((angle + t * 60) % 360, 1, 1, out r, out g, out b);
                    keyboard.SetKeyColor(key, new Color(r, g, b));
                }

                keyboard.Update();

                Thread.Sleep(1000 / 30);
            }
        }

        static void OnProcessExit(object sender, EventArgs e) {
            keyboard.Close();
        }
    }
}

