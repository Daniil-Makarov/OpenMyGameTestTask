using System.Linq;
using Main.UI.Screens;
using UnityEngine;
using Zenject;

namespace Main.Services.Factories {
	public class UiFactory {
		private readonly IInstantiator instantiator;

		public UiFactory(IInstantiator instantiator) => this.instantiator = instantiator;
		public View Create(View viewPrefab, params object[] extraArgs) => Create(viewPrefab, parent: null, extraArgs);
		public View Create(View viewPrefab, Transform parent, params object[] extraArgs) {
			View view = instantiator.InstantiatePrefabForComponent<View>(viewPrefab);
			if (parent) view.transform.SetParent(parent, worldPositionStays: false);
			
			Presenter presenter = instantiator.Instantiate(viewPrefab.Presenter, extraArgs.Concat(new object[] { view })) as Presenter;
			presenter?.Initialize();
			
			return view;
		}
	}
}