using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Main.UI.Screens.SliceSelection.SliceSelection {
	public class SliceSelectionView : Screen {
		public event Action BackClicked;
		public event Action StartClicked;
		
		[SerializeField] private Image icon;
		[SerializeField] private Image gridOverlay;
		[SerializeField] private Transform sliceChoiceParent;
		[SerializeField] private Button backButton;
		[SerializeField] private Button startButton;
		[SerializeField] private TextMeshProUGUI startButtonText;

		public Rect IconRect => icon.rectTransform.rect;
		public override Type Presenter => typeof(SliceSelectionPresenter);

		public override void Initialize() {
			base.Initialize();
			backButton.onClick.AddListener(OnBackClicked);
			startButton.onClick.AddListener(OnStartClicked);
		}
		public override void Dispose() {
			backButton.onClick.RemoveListener(OnBackClicked);
			startButton.onClick.RemoveListener(OnStartClicked);
			base.Dispose();
		}
		public void SetIcon(Sprite sprite) => icon.sprite = sprite;
		public void SetGridOverlay(Sprite sprite) => gridOverlay.sprite = sprite;
		public void SetStartButtonText(string text) => startButtonText.text = text;
		public void SetSliceChoices(IEnumerable<View> sliceChoices) {
			foreach (View sliceChoice in sliceChoices) {
				sliceChoice.transform.SetParent(sliceChoiceParent, worldPositionStays: false);
			}
		}
		private void OnBackClicked() => BackClicked?.Invoke();
		private void OnStartClicked() => StartClicked?.Invoke();
	}
}