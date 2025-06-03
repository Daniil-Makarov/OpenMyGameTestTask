using System.Collections.Generic;
using System.Linq;
using Main.Services.Factories;
using Main.UI.Screens.Configs;

namespace Main.UI.Screens.MainMenu.MainMenu {
	public class MainMenuPresenter : Presenter {
		private readonly PuzzlePreviewsConfig config;
		private readonly UiFactory uiFactory;
		private readonly MainMenuView view;
		
		public MainMenuPresenter(MainMenuView view, PuzzlePreviewsConfig config, UiFactory uiFactory) : base(view) {
			this.view = view;
			this.config = config;
			this.uiFactory = uiFactory;
		}
		public override void Initialize() {
			IEnumerable<View> puzzlePreviews = CreatePuzzlePreviews().ToArray();
			
			view.SetContent(puzzlePreviews);
			AddDependentViews(puzzlePreviews);
		}
		private IEnumerable<View> CreatePuzzlePreviews() => config.PuzzlePreviews.Select(x => uiFactory.Create(config.PuzzlePreviewPrefab, x));
	}
}