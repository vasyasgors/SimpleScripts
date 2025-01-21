using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SimpleScripts
{
	
	public class Restarter : MonoBehaviour
	{
		public string Tag = "Player";

		void OnTriggerEnter(Collider col)
		{
			if (col.tag != Tag)
				return;

			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

}