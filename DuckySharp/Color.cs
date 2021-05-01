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

        private static double lerp(double a, double b, double c) {
            return a + (b - a) * c;
        }

        /// <summary>
        /// The red channel.
        /// </summary>
        public byte R;

        /// <summary>
        /// The green channel.
        /// </summary>
        public byte G;

        /// <summary>
        /// The blue channel.
        /// </summary>
        public byte B;

        /// <summary>
        /// Instantiate a new color.
        /// </summary>
        /// <param name="r">The red channel.</param>
        /// <param name="g">The green channel.</param>
        /// <param name="b">The blue channel.</param>
        public Color(byte r, byte g, byte b) {
            R = r;
            G = g;
            B = b;
        }

        /// <summary>
        /// Instantiates a greyscale color.
        /// </summary>
        /// <param name="n">The number to apply to each channel.</param>
        public Color(byte n) {
            R = n;
            G = n;
            B = n;
        }

        /// <summary>
        /// Instantiates a color from three integer channels. These channels are ranged from 0 to 255.
        /// </summary>
        /// <param name="r">Red channel, 0 to 255.</param>
        /// <param name="g">Green channel, 0 to 255.</param>
        /// <param name="b">Blue channel, 0 to 255.</param>
        public Color(int r, int g, int b) {
            R = (byte)r;
            G = (byte)g;
            B = (byte)b;
        }

        /// <summary>
        /// Instantiate a color from three double channels. These channels are ranged from 0 to 1.
        /// </summary>
        /// <param name="r">Red channel, 0 to 1.</param>
        /// <param name="g">Green channel, 0 to 1.</param>
        /// <param name="b">Blue channel, 0 to 1.</param>
        public Color(double r, double g, double b) {
            R = (byte)(r * 255);
            G = (byte)(g * 255);
            B = (byte)(b * 255);
        }

        /// <summary>
        /// Instantiate a greyscale color from an int, 0 to 255.
        /// </summary>
        /// <param name="n">The number, from 0 to 255, to apply to all channels.</param>
        public Color(int n) {
            R = G = B = (byte)n;
        }

        /// <summary>
        /// Instantiate a greyscale color from a double, 0 to 1.
        /// </summary>
        /// <param name="n">The number, from 0 to 1, to apply to all channels.</param>
        public Color(double n) {
            R = G = B = (byte)(n * 255);
        }

        /// <summary>
        /// Instantiate a color from a System.Drawing color.
        /// </summary>
        /// <param name="color">The System.Drawing color.</param>
        public Color(System.Drawing.Color color) {
            R = color.R;
            G = color.G;
            B = color.B;
        }

        /// <summary>
        /// Linearly interpolate between this color and another.
        /// </summary>
        /// <param name="other">The other color.</param>
        /// <param name="c">The interpolation amount. At 0, it is the base color. At 1, it is the other color.</param>
        /// <returns></returns>
        public Color Lerp(Color other, double c) {
            return new Color((int)lerp(R, other.R, c), (int)lerp(G, other.G, c), (int)lerp(B, other.B, c));
        }

        /// <summary>
        /// Smoothly clamp between two colors.
        /// </summary>
        /// <param name="a">The first color.</param>
        /// <param name="b">The second color.</param>
        /// <param name="aBound">The lower bound of the transition range. Anything below will be color A.</param>
        /// <param name="bBound">The upper bound of the transition range. Anything above will be color B.</param>
        /// <param name="value">The value along the range to test.</param>
        /// <returns>The interpolated color.</returns>
        public static Color SmoothClamp(Color a, Color b, double aBound, double bBound, double value) {
            if (bBound < aBound) return SmoothClamp(a, b, bBound, aBound, value);

            if (value <= aBound)
                return a;
            else if (value >= bBound)
                return b;
            else {
                double c = (value - aBound) / (bBound - aBound);
                return a.Lerp(b, c);
			}
		}

        /// <summary>
        /// Grab a color across a gradient of passed stops. Stops must be in ascending order for this to work correctly.
        /// </summary>
        /// <param name="stops">An array of doubles representing the positions of the stops.</param>
        /// <param name="colorStops">An array of Colors representing the colors of the corresponding stops.</param>
        /// <param name="value">The position along the gradient to grab color from.</param>
        /// <returns>The color on the gradient.</returns>
        public static Color Gradient(double[] stops, Color[] colorStops, double value) {
            if (value >= stops[stops.Length - 1]) {
                return colorStops[stops.Length - 1];
			} else if (value <= stops[0]) {
                return colorStops[0];
			} else {
                double first = stops[0];

                int i;
                for (i = 1; i < stops.Length; i++) {
                    if (value - stops[i] < 0) {
                        // this stop is just beyond our point
                        break;
					}
				}
                if (i == stops.Length) i--;

                double min = stops[i - 1];
                double max = stops[i];
                double c = (value - min) / (max - min);

                return colorStops[i - 1].Lerp(colorStops[i], c);
			}
		}
    }
}
