using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace SimpleScripts
{
	public class SceneLoad : MonoBehaviour 
	{
		public void Load(int number)
		{
			SceneManager.LoadScene (number);
		}

		public void Load(string name)
		{
			SceneManager.LoadScene(name);
		}




	}
}
