using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DuckySharp.Test {
    class Visor {
        public static void Main(string[] args) {
            Keyboard keyboard = new Keyboard();
            keyboard.Initialize();

            DateTime start = DateTime.Now;
            while (true) {
                double total = (DateTime.Now - start).TotalSeconds;
                double visorPos = Math.Sin(total * 1.5) * Keys.KeyboardWidth * 0.5 + Keys.KeyboardWidth / 2;

                foreach (Key key in Keys.All) {
                    if (Math.Abs(key.X - visorPos) < 0.5) {
                        keyboard.SetKeyColor(key, Color.FromHSV(total * 120, 1, 1));
                    } else {
                        keyboard.SetKeyColor(key, keyboard.GetKeyColor(key).Lerp(Color.Black, 0.1));
                    }
                }

                keyboard.Update();
                Thread.Sleep(1000 / 60);
            }
        }
    }
}
