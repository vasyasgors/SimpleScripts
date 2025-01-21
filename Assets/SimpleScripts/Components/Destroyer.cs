using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SimpleScripts
{
	public class Destroyer : MonoBehaviour 
	{
		public float Delay;

		void Start()
		{
			Destroy (gameObject, Delay);
		}
			
	}

}