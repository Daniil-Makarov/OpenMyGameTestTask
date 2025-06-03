using Main.Services.Configs;
using Main.UI.Screens.Configs;
using UnityEngine;

namespace Main.Services {
	public class PreviewGridGenerator {
		private readonly PreviewGridConfig config;

		public PreviewGridGenerator(PreviewGridConfig config) => this.config = config;
		public Sprite Generate(Rect rect, SlicesPreset preset) {
			int width = (int) rect.width;
			int height = (int) rect.height;
			
			return Sprite.Create(
				texture: GenerateTexture(width, height, preset.Rows, preset.Columns),
				rect: new Rect(0, 0, width, height),
				pivot: Vector2.zero);
		}
		private Texture2D GenerateTexture(int width, int height, int rows, int columns) {
			Texture2D texture = new (width, height, TextureFormat.ARGB32, false);

			Color[] fill = new Color[width * height];
			for (int i = 0; i < fill.Length; i++) {
				fill[i] = new Color(0, 0, 0, 0);
			}
			texture.SetPixels(fill);

			int cellWidth = width / columns;
			int cellHeight = height / rows;

			for (int x = 0; x <= columns; x++) {
				int pixelX = Mathf.Clamp(x * cellWidth, 0, width - 1);
				for (int y = 0; y < height; y++) {
					for (int lw = -config.LineWidth / 2; lw <= config.LineWidth / 2; lw++) {
						int px = Mathf.Clamp(pixelX + lw, 0, width - 1);
						texture.SetPixel(px, y, config.Color);
					}
				}
			}

			for (int y = 0; y <= rows; y++) {
				int pixelY = Mathf.Clamp(y * cellHeight, 0, height - 1);
				for (int x = 0; x < width; x++) {
					for (int lw = -config.LineWidth / 2; lw <= config.LineWidth / 2; lw++) {
						int py = Mathf.Clamp(pixelY + lw, 0, height - 1);
						texture.SetPixel(x, py, config.Color);
					}
				}
			}

			texture.Apply();
			return texture;
		}
	}
}