using SharpNoise.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DuckySharp.Test {
	class TerrainNoise {
		public static void Main(string[] args) {
			Color darkGround = new Color(0, 125, 0);
			Color lightGround = new Color(50, 255, 50);
			Color sky = new Color(150, 150, 255);

			Keyboard keyboard = new Keyboard();
			keyboard.Initialize();

			Perlin noise = new Perlin { Seed = new Random().Next() };

			DateTime start = DateTime.Now;
			while (true) {
				double t = (DateTime.Now - start).TotalSeconds;

				foreach (Key key in Keys.All) {
					double noiseAt = (noise.GetValue(key.X * 0.2, t * 0.3, 0) * 0.5 + 0.5) * Keys.KeyboardHeight * 0.6 + 1;

					keyboard.SetKeyColor(key, Color.Gradient(new double[] { 0, noiseAt - 1, noiseAt + 1, Keys.KeyboardHeight }, new Color[] { sky, sky, lightGround, darkGround }, key.Y));
				}

				Thread.Sleep(1000 / 30);
				keyboard.Update();
			}
		}
	}
}
