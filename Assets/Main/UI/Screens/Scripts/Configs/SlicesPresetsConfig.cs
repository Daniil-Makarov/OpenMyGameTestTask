using UnityEngine;

namespace Main.UI.Screens.Configs {
	[CreateAssetMenu(fileName = nameof(SlicesPresetsConfig), menuName = "Configs/" + nameof(SlicesPresetsConfig))]
	public class SlicesPresetsConfig : ScriptableObject {
		public SlicesPreset[] Presets;
	}
}