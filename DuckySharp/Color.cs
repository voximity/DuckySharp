using System;
using System.Collections.Generic;
using System.Text;

namespace DuckySharp {
    public struct Color {
        public static Color Black => new Color(0, 0, 0);
        public static Color White => new Color(255, 255, 255);
        public static Color Red => new Color(255, 0, 0);
        public static Color Green => new Color(0, 255, 0);
        public static Color Blue => new Color(0, 0, 255);

        public static explicit operator Color(System.Drawing.Color c) => new Color(c);

        /// <summary>
        /// Get a Color from HSV values. Hue is expected to be in degrees.
        /// </summary>
        /// <param name="hue">The hue, from 0 to 360.</param>
        /// <param name="sat">The saturation, from 0 to 1.</param>
        /// <param name="val">The value, from 0 to 1.</param>
        /// <returns></returns>
        public static Color FromHSV(double hue, double sat, double val) {
            hue %= 360;
            double r, g, b;
            if (val <= 0) {
                r = g = b = 0;
            } else if (sat <= 0) {
                r = g = b = val;
            } else {
                double hf = hue / 60;
                int i = (int)Math.Floor(hf);
                double f = hf - i;
                double pv = val * (1 - sat);
                double qv = val * (1 - sat * f);
                double tv = val * (1 - sat * (1 - f));

                switch (i) {
                    case 6:
                    case 0:
                        r = val; g = tv; b = pv;
                        break;
                    case 1:
                        r = qv; g = val; b = pv;
                        break;
                    case 2:
                        r = pv; g = val; b = tv;
                        break;
                    case 3:
                        r = pv; g = qv; b = val;
                        break;
                    case 4:
                        r = tv; g = pv; b = val;
                        break;
                    case -1:
                    case 5:
                        r = val; g = pv; b = qv;
                        break;
                    default:
                        r = g = b = val;
                        break;
                }
            }

            return new Color(Math.Max(0, Math.Min(255, r)), Math.Max(0, Math.Min(255, g)), Math.Max(0, Math.Min(255, b)));
        }

        private double lerp(double a, double b, double c) {
            return a + (b - a) * c;
        }

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

        public Color(System.Drawing.Color color) {
            R = color.R;
            G = color.G;
            B = color.B;
        }

        public Color Lerp(Color other, double c) {
            return new Color((int)lerp(R, other.R, c), (int)lerp(G, other.G, c), (int)lerp(B, other.B, c));
        }
    }
}
