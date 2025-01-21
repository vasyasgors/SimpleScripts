using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleScripts
{
	public class Destroy : MonoBehaviour 
	{
		
		public float Delay = 0;

		public void StartDestroy()
		{
			Destroy (gameObject, Delay);

		}

	}
}


