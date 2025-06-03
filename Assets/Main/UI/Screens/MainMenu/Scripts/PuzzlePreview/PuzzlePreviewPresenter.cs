using Main.Services;
using Main.UI.Screens.Configs;

namespace Main.UI.Screens.MainMenu.PuzzlePreview {
	public class PuzzlePreviewPresenter : Presenter {
		private readonly PuzzlePreviewView view;
		private readonly PuzzlePreviewConfig config;
		private readonly ScreenNavigator screenNavigator;

		public PuzzlePreviewPresenter(PuzzlePreviewView view, PuzzlePreviewConfig config, ScreenNavigator screenNavigator) : base(view) {
			this.view = view;
			this.config = config;
			this.screenNavigator = screenNavigator;
		}
		public override void Initialize() {
			base.Initialize();
			
			view.Clicked += OnClicked;
			view.SetIcon(config.Icon);
		}
		protected override void Dispose() {
			view.Clicked -= OnClicked;
			base.Dispose();
		}
		private void OnClicked() => screenNavigator.Open(ScreenType.SliceSelection, config);
	}
}