using System.Collections.Generic;
using Main.Services.Factories;
using Main.Services.Input;
using Main.UI.Screens;
using Main.UI.Screens.Configs;
using UnityEngine;
using Zenject;

namespace Main.Services {
	public class ScreenNavigator : MonoBehaviour {
		[SerializeField] private Transform screensRoot;
		[SerializeField] private ScreenType startScreen;
		private UiFactory uiFactory;
		private InputHandler inputHandler;
		private ScreensConfig config;
		private readonly Stack<View> history = new ();

		[Inject]
		private void Construct(UiFactory uiFactory, InputHandler inputHandler, ScreensConfig config) {
			this.inputHandler = inputHandler;
			this.uiFactory = uiFactory;
			this.config = config;
		}
		private void Start() => Open(startScreen);
		private void OnEnable() => inputHandler.BackPressed += CloseCurrentScreen;
		private void OnDisable() => inputHandler.BackPressed -= CloseCurrentScreen;
		public void Open(ScreenType screenType, params object[] extraArgs) {
			View screen = uiFactory.Create(config.ScreensByType[screenType], screensRoot, extraArgs);
			history.Push(screen);
		}
		public void CloseCurrentScreen() {
			if (history.Count > 1) history.Pop().Dispose();
		}
	}
}