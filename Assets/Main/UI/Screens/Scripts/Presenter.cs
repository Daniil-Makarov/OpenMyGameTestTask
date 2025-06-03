using System.Collections.Generic;
using Object = UnityEngine.Object;

namespace Main.UI.Screens {
	public abstract class Presenter {
		private readonly View view;
		private readonly List<View> dependentViews = new ();

		protected Presenter(View view) => this.view = view;
		public virtual void Initialize() {
			view.Initialize();
			view.Disposed += Dispose;
		}
		protected void AddDependentViews(IEnumerable<View> dependentView) => dependentViews.AddRange(dependentView);
		protected virtual void Dispose() {
			view.Disposed -= Dispose;
			
			foreach (View dependentView in dependentViews) {
				dependentView.Dispose();
			}
			Object.Destroy(view.gameObject);
		}
	}
}