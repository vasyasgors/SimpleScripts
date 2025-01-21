using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace SimpleScripts
{
	public class TimeScale : MonoBehaviour 
	{
		public void SetTimeScale(float timeScale)
		{
			Time.timeScale = timeScale;
		}

	}
}
