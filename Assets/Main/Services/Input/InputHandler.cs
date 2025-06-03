using System;
using UnityEngine.InputSystem;
using Zenject;

namespace Main.Services.Input {
	public class InputHandler : IInitializable, IDisposable {
		public event Action BackPressed;
		
		private InputSystem inputSystem;

		public void Initialize() {
			inputSystem = new InputSystem();
			inputSystem.Enable();
			
			inputSystem.Player.Back.performed += OnBackPerformed;
		}
		public void Dispose() {
			inputSystem.Player.Back.performed -= OnBackPerformed;
			
			inputSystem.Disable();
			inputSystem.Dispose();
			inputSystem = null;
		}
		private void OnBackPerformed(InputAction.CallbackContext context) => BackPressed?.Invoke();
	}
}