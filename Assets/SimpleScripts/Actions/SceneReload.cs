using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SimpleScripts
{
	public class SceneReload : MonoBehaviour 
	{
		public void Reload()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}


	}
}
