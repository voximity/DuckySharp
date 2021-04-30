using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DuckySharp.Test {
    class BouncingBall {
        public static void Main(string[] args) {
            Keyboard keyboard = new Keyboard();
            keyboard.Initialize();

            // ball coordinates
            double bx = 5;
            double by = 2;
            
            // ball velocity
            double vx = 5;
            double vy = 2;

            // maximum distance from the ball for a key to light
            double maxDist = 2;

            DateTime last = DateTime.Now;
            while (true) {
                DateTime now = DateTime.Now;
                double delta = (now - last).TotalSeconds;
                last = now;

                // add the velocity to the ball's pos
                bx += vx * delta;
                by += vy * delta;

                // bounce off when ball goes OOB
                if (bx > Keys.KeyboardWidth - 1 || bx < 1)
                    vx *= -1;
                if (by > Keys.KeyboardHeight - 1 || by < 1)
                    vy *= -1;

                foreach (Key key in Keys.All) {
                    double xd = key.X - bx;
                    double yd = key.Y - by;

                    double dist = Math.Sqrt(xd * xd + yd * yd);

                    // if dist from key to ball is under max dist...
                    if (dist < maxDist) {
                        // light it based on its distance
                        double amount = 1 - dist / maxDist;
                        keyboard.SetKeyColor(key, new Color(amount, amount, amount));
                    } else {
                        keyboard.SetKeyColor(key, new Color(0, 0, 0));
                    }
                }

                keyboard.Update();
                Thread.Sleep(1000 / 30); // should be roughly 30Hz update
            }
        }
    }
}
