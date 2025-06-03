using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Main.UI.Screens.SliceSelection.SliceChoice {
	public class SliceChoiceView : View {
		public event Action Clicked;
		
		[SerializeField] private TextMeshProUGUI text;
		[SerializeField] private Button button;
		
		public override Type Presenter => typeof(SliceChoicePresenter);
		
		public override void Initialize() {
			base.Initialize();
			button.onClick.AddListener(OnClicked);
		}
		public override void Dispose() {
			button.onClick.RemoveListener(OnClicked);
			base.Dispose();
		}
		public void SetText(string text) => this.text.text = text;
		private void OnClicked() => Clicked?.Invoke();
	}
}