using UnityEngine;

namespace Main.Services.Configs {
	[CreateAssetMenu(fileName = nameof(PreviewGridConfig), menuName = "Configs/" + nameof(PreviewGridConfig))]
	public class PreviewGridConfig : ScriptableObject {
		public Color Color;
		public int LineWidth;
	}
}