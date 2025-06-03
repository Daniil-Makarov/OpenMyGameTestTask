using System;
using UnityEngine;
using UnityEngine.UI;

namespace Main.UI.Screens.MainMenu.PuzzlePreview {
	public class PuzzlePreviewView : View {
		public event Action Clicked;
		
		[SerializeField] private Image icon;
		[SerializeField] private Button button;
		
		public override Type Presenter => typeof(PuzzlePreviewPresenter);
		
		public void SetIcon(Sprite sprite) => icon.sprite = sprite;
		public override void Initialize() {
			base.Initialize();
			button.onClick.AddListener(OnClicked);
		}
		public override void Dispose() {
			button.onClick.RemoveListener(OnClicked);
			base.Dispose();
		}
		private void OnClicked() => Clicked?.Invoke();
	}
}