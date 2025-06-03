using UnityEngine;

namespace Main.UI.Screens.Configs {
	[CreateAssetMenu(fileName = nameof(PuzzlePreviewConfig), menuName = "Configs/" + nameof(PuzzlePreviewConfig))]
	public class PuzzlePreviewConfig : ScriptableObject {
		public Sprite Icon;
		public PuzzlePreviewType Type;
		public bool UseDefaultSlicesPresets = true;
		public SlicesPresetsConfig SlicesPresets;
		public bool UseDefaultPrice = true;
		public int Price;
	}
}