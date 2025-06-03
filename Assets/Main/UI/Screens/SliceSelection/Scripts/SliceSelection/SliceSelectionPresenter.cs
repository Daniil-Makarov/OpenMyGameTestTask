using System;
using System.Collections.Generic;
using System.Linq;
using Main.Services;
using Main.Services.Factories;
using Main.UI.Screens.Configs;
using UnityEngine;

namespace Main.UI.Screens.SliceSelection.SliceSelection {
	public class SliceSelectionPresenter : Presenter {
		private int price;
		private SlicesPreset currentPreset;
		private readonly ScreenNavigator screenNavigator;
		private readonly PuzzlePreviewsConfig globalConfig;
		private readonly PuzzlePreviewConfig config;
		private readonly UiFactory uiFactory;
		private readonly PreviewGridGenerator previewGridGenerator;
		private readonly SliceSelectionView view;

		public SliceSelectionPresenter(SliceSelectionView view, ScreenNavigator screenNavigator, PuzzlePreviewsConfig globalConfig, PuzzlePreviewConfig config,
			UiFactory uiFactory, PreviewGridGenerator previewGridGenerator) : base(view) {
			this.view = view;
			this.screenNavigator = screenNavigator;
			this.globalConfig = globalConfig;
			this.config = config;
			this.uiFactory = uiFactory;
			this.previewGridGenerator = previewGridGenerator;
		}
		public override void Initialize() {
			base.Initialize();
			
			view.BackClicked += OnBackClicked;
			view.StartClicked += OnStartClicked;
			
			SlicesPreset[] presets = config.UseDefaultSlicesPresets ? globalConfig.DefaultSlicesPresets.Presets : config.SlicesPresets.Presets;
			price = config.UseDefaultPrice ? globalConfig.DefaultPrice : config.Price;
			
			Sprite icon = config.Icon;
			IEnumerable<View> sliceChoices = CreateSliceChoices(presets).ToArray();
			string startButtonText = GetStartButtonText();
			
			view.SetIcon(icon);
			view.SetStartButtonText(startButtonText);
			view.SetSliceChoices(sliceChoices);
			GenerateGridOverlay(presets[0]);
			AddDependentViews(sliceChoices);
		}
		protected override void Dispose() {
			view.BackClicked -= OnBackClicked;
			view.StartClicked -= OnStartClicked;
			base.Dispose();
		}
		public void GenerateGridOverlay(SlicesPreset preset) {
			if (currentPreset is not null && currentPreset.Equals(preset)) return;
			
			Sprite gridOverlay = previewGridGenerator.Generate(view.IconRect, preset);
			view.SetGridOverlay(gridOverlay);
			
			currentPreset = preset;
		}
		private IEnumerable<View> CreateSliceChoices(SlicesPreset[] presets) => presets.Select(x => uiFactory.Create(globalConfig.SliceChoicePrefab, x, this));
		private string GetStartButtonText() {
			return config.Type switch {
				PuzzlePreviewType.Free => "Start",
				PuzzlePreviewType.Ad => "Start with Ad",
				PuzzlePreviewType.Price => price.ToString(),
				_ => throw new ArgumentOutOfRangeException()
			};
		}
		private void OnBackClicked() => screenNavigator.CloseCurrentScreen();
		private void OnStartClicked() {
			switch (config.Type) {
				case PuzzlePreviewType.Free:
					StartGame();
					break;
				case PuzzlePreviewType.Ad:
					StartGameAfterAd();
					break;
				case PuzzlePreviewType.Price:
					TryStartWithPrice();
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
		private void StartGame() {}
		private void StartGameAfterAd() {}
		private void TryStartWithPrice() {}
	}
}