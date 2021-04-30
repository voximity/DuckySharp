using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DuckySharp.Test {
    class HsvColorWheel {
        public static void Main(string[] args) {
            Keyboard keyboard = new Keyboard();
            keyboard.Initialize();

            // center coordinates for wheel
            double cx = 7;
            double cy = 3;

            DateTime start = DateTime.Now;
            while (true) {
                double t = (DateTime.Now - start).TotalSeconds;

                foreach (Key key in Keys.All) {
                    double angle = Math.Atan2(key.Y - cy, key.X - cx) * 180 / Math.PI;
                    keyboard.SetKeyColor(key, Color.FromHSV(angle + t * 60, 1, 1));
                }

                keyboard.Update();
                Thread.Sleep(1000 / 30);
            }
        }
    }
}
