using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DuckySharp.Test {
    class Fire {
        public static void Main(string[] args) {
            Keyboard keyboard = new Keyboard();
            keyboard.Initialize();

            Color colorA = Color.Red;
            Color colorB = Color.Blue.Lerp(Color.Black, 0.15);

            double fade = 3;

            DateTime start = DateTime.Now;
            while (true) {
                double t = (DateTime.Now - start).TotalSeconds;

                foreach (Key key in Keys.All) {
                    double thresh = Math.Sin(key.X) * Keys.KeyboardHeight * 0.2 + Keys.KeyboardHeight / 2;
                    if (Math.Abs(thresh - key.Y) < 2) {
                        // fade color
                        double c = (key.Y - thresh) / fade * 0.5 + 0.5;
                        keyboard.SetKeyColor(key, colorB.Lerp(colorA, c));
                    } else if (key.Y > thresh) {
                        keyboard.SetKeyColor(key, colorA);
                    } else {
                        keyboard.SetKeyColor(key, colorB);
                    }

                    Color col = keyboard.GetKeyColor(key);
                    double amnt = 0.2 + 0.3 * (1 - key.Y / Keys.KeyboardHeight);
                    keyboard.SetKeyColor(key, col.Lerp(Color.Black, Math.Sin(key.X * 11.2 + key.Y * 63.5 + t) * amnt + amnt));
                }

                keyboard.Update();
                Thread.Sleep(1000 / 30);
            }
        }
    }
}
