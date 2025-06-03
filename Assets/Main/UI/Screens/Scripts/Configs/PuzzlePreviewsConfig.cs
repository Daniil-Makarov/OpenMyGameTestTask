using Main.UI.Screens.MainMenu.PuzzlePreview;
using Main.UI.Screens.SliceSelection.SliceChoice;
using UnityEngine;

namespace Main.UI.Screens.Configs {
	[CreateAssetMenu(fileName = nameof(PuzzlePreviewsConfig), menuName = "Configs/" + nameof(PuzzlePreviewsConfig))]
	public class PuzzlePreviewsConfig : ScriptableObject {
		public PuzzlePreviewView PuzzlePreviewPrefab;
		public SliceChoiceView SliceChoicePrefab;
		public SlicesPresetsConfig DefaultSlicesPresets;
		public int DefaultPrice;
		public PuzzlePreviewConfig[] PuzzlePreviews;
	}
}