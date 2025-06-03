using Main.UI.Screens.Configs;
using Main.UI.Screens.SliceSelection.SliceSelection;

namespace Main.UI.Screens.SliceSelection.SliceChoice {
	public class SliceChoicePresenter : Presenter {
		private readonly SlicesPreset config;
		private readonly SliceSelectionPresenter sliceSelectionPresenter;
		private readonly SliceChoiceView view;

		public SliceChoicePresenter(SliceChoiceView view, SlicesPreset config, SliceSelectionPresenter sliceSelectionPresenter) : base(view) {
			this.view = view;
			this.config = config;
			this.sliceSelectionPresenter = sliceSelectionPresenter;
		}
		public override void Initialize() {
			base.Initialize();

			view.Clicked += OnClicked;
			
			string text = config.Elements.ToString();
			view.SetText(text);
		}
		protected override void Dispose() {
			view.Clicked -= OnClicked;
			base.Dispose();
		}
		private void OnClicked() => sliceSelectionPresenter.GenerateGridOverlay(config);
	}
}