using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DuckySharp.Test {
    class TypeOut {
        private static Dictionary<char, Key> keymap = new Dictionary<char, Key> {
            ['a'] = Keys.A,
            ['b'] = Keys.B,
            ['c'] = Keys.C,
            ['d'] = Keys.D,
            ['e'] = Keys.E,
            ['f'] = Keys.F,
            ['g'] = Keys.G,
            ['h'] = Keys.H,
            ['i'] = Keys.I,
            ['j'] = Keys.J,
            ['k'] = Keys.K,
            ['l'] = Keys.L,
            ['m'] = Keys.M,
            ['n'] = Keys.N,
            ['o'] = Keys.O,
            ['p'] = Keys.P,
            ['q'] = Keys.Q,
            ['r'] = Keys.R,
            ['s'] = Keys.S,
            ['t'] = Keys.T,
            ['u'] = Keys.U,
            ['v'] = Keys.V,
            ['w'] = Keys.W,
            ['x'] = Keys.X,
            ['y'] = Keys.Y,
            ['z'] = Keys.Z,
            [' '] = Keys.Space
        };

        public static void Main(string[] args) {
            string typeText = "Hello World How Are You";
            Color typedColor = Color.Green;

            Keyboard keyboard = new Keyboard();
            keyboard.Initialize();

            Thread.Sleep(2000);

            for (int i = 0; i < typeText.Length; i++) {
                char c = typeText[i];
                List<Key> lightKeys = new List<Key>();

                if (c >= 'a' && c <= 'z') {
                    lightKeys.Add(keymap[c]);
                } else if (c >= 'A' && c <= 'Z') {
                    lightKeys.Add(keymap[(char)(c + ('a' - 'A'))]);
                    lightKeys.Add(Keys.LeftShift);
                } else if (c == ' ') {
                    lightKeys.Add(keymap[' ']);
                }

                foreach (Key key in Keys.All) {
                    keyboard.SetKeyColor(key, lightKeys.Contains(key) ? typedColor : Color.Black);
                }

                keyboard.Update();
                Thread.Sleep(100);
            }

            keyboard.Close();
        }
    }
}
