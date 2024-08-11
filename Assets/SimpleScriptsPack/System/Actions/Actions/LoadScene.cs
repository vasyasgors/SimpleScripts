using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ActionPath("LoadScene")]
public class LoadScene : ActionBase 
{
	[SerializeField] private string sceneName;

    public override void StartExecute()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

}
