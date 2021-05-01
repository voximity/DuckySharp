using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DuckySharp.Test {
    class HsvColorWheel {
        public static void Main(string[] args) {
            Keyboard keyboard = new Keyboard();
            keyboard.Initialize();

            DateTime start = DateTime.Now;
            while (true) {
                double t = (DateTime.Now - start).TotalSeconds;

                double cx = 10 + Math.Sin(t * 1.2) * 5;
                double cy = 3 + Math.Cos(t * 1.2) * 1.5;

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
