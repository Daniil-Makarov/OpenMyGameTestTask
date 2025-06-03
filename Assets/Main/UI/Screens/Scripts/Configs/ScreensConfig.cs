using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Main.UI.Screens.Configs {
	[CreateAssetMenu(fileName = nameof(ScreensConfig), menuName = "Configs/" + nameof(ScreensConfig))]
	public class ScreensConfig : ScriptableObject {
		[SerializeField] private Screen[] screens;
		private Dictionary<ScreenType, Screen> screensByType;
	
		public Dictionary<ScreenType, Screen> ScreensByType => screensByType ??= screens.ToDictionary(x => x.ScreenType, x => x);
	}
}