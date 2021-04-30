using System;
using System.Collections.Generic;
using System.Text;

namespace DuckySharp {
    public struct Color {
        public byte R;
        public byte G;
        public byte B;

        public Color(byte r, byte g, byte b) {
            R = r;
            G = g;
            B = b;
        }

        public Color(byte n) {
            R = n;
            G = n;
            B = n;
        }

        public Color(int r, int g, int b) {
            R = (byte)r;
            G = (byte)g;
            B = (byte)b;
        }

        public Color(double r, double g, double b) {
            R = (byte)(r * 255);
            G = (byte)(g * 255);
            B = (byte)(b * 255);
        }

        public Color(int n) {
            R = G = B = (byte)n;
        }

        public Color(double n) {
            R = G = B = (byte)(n * 255);
        }
    }
}
