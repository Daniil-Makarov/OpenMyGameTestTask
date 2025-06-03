using Main.Services.Configs;
using Main.Services.Factories;
using Main.Services.Input;
using Main.UI.Screens.Configs;
using UnityEngine;
using Zenject;

namespace Main.Services.Installers {
	public class SceneContextInstaller : MonoInstaller {
		[Header("Services")]
		[SerializeField] private ScreenNavigator screenNavigator;
		[Header("Configs")]
		[SerializeField] private PuzzlePreviewsConfig puzzlePreviewsConfig;
		[SerializeField] private ScreensConfig screensConfig;
		[SerializeField] private PreviewGridConfig previewGridConfig;
		
		public override void InstallBindings() {
			BindConfigs();
			BindServices();
			BindFactories();
		}
		private void BindConfigs() {
			Container.BindInstance(puzzlePreviewsConfig).AsSingle();
			Container.BindInstance(screensConfig).AsSingle();
			Container.BindInstance(previewGridConfig).AsSingle();
		}
		private void BindServices() {
			Container.BindInstance(screenNavigator).AsSingle();
			Container.BindInterfacesAndSelfTo<InputHandler>().AsSingle();
			Container.Bind<PreviewGridGenerator>().AsSingle();
		}
		private void BindFactories() => Container.Bind<UiFactory>().AsSingle();
	}
}