namespace Example
{
	using System;
	using Fusion;

	/// <summary>
	/// Helper component to invoke fixed and render update methods before HitboxManager and after NetworkCulling.
	/// </summary>
	[OrderBefore(typeof(HitboxManager))]
	[OrderAfter(typeof(NetworkCulling))]
	public sealed class BeforeHitboxManagerUpdater : SimulationBehaviour
	{
		// PRIVATE MEMBERS

		private Action _fixedUpdate;
		private Action _render;

		// PUBLIC METHODS

		public void SetDelegates(Action fixedUpdateDelegate, Action renderDelegate)
		{
			_fixedUpdate = fixedUpdateDelegate;
			_render      = renderDelegate;
		}

		// SimulationBehaviour INTERFACE

		public override void FixedUpdateNetwork()
		{
			if (_fixedUpdate != null)
			{
				_fixedUpdate();
			}
		}

		public override void Render()
		{
			if (_render != null)
			{
				_render();
			}
		}
	}
}
