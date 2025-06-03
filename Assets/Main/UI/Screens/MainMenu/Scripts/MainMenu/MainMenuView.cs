using System;
using System.Collections.Generic;
using UnityEngine;

namespace Main.UI.Screens.MainMenu.MainMenu {
	public class MainMenuView : Screen {
		[SerializeField] private Transform contentParent;
		
		public override Type Presenter => typeof(MainMenuPresenter);

		public void SetContent(IEnumerable<View> puzzlePreviews) {
			foreach (View puzzlePreview in puzzlePreviews) {
				puzzlePreview.transform.SetParent(contentParent, worldPositionStays: false);
			}
		}
	}
}