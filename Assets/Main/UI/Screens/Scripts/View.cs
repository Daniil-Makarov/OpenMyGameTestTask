using System;
using UnityEngine;

namespace Main.UI.Screens {
	public abstract class View : MonoBehaviour {
		public event Action Disposed;
		
		public abstract Type Presenter { get; }
		
		public virtual void Initialize() {}
		public virtual void Dispose() => Disposed?.Invoke();
	}
}