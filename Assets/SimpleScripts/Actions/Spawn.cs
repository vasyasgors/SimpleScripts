using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleScripts
{
	public class Spawn : MonoBehaviour 
	{
		
		public GameObject Prefab;

		public void Create()
		{
			Instantiate (Prefab, transform.position, Quaternion.identity);
		}

	}
}


