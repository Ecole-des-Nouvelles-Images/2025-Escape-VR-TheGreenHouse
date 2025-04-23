using UnityEngine;

namespace _3Dynamite.Real_Ivy.SampleResources.Scripts
{
	public class PlayerController : MonoBehaviour
	{
		public IvyCaster ivyCaster;
		public Transform trIvy;

		private void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				ivyCaster.CastRandomIvy(trIvy.position, trIvy.rotation);
			}
		}
	}
}