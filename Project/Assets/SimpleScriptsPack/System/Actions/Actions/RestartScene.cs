using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ActionPath("RestartScene")]
public class RestartScene : ActionBase
{
	public override void StartExecute()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
	}

}