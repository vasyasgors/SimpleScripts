using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ActionPath("Destroy")]
public class Destroy : ActionBase
{
	[SerializeField] private GameObject _gameObject;
	[SerializeField] private float delay;

    public override void StartExecute()
    {
        Destroy(_gameObject, delay);
    }
}
