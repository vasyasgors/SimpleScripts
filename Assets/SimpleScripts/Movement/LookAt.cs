using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SimpleScripts
{
	public class LookAt : MonoBehaviour 
	{
		public Transform Target;
		public bool FindTargetOnStart;
		public string TargetTag = "Player";

		void Start()
		{
			if (FindTargetOnStart == true) 
			{
				Target = GameObject.FindGameObjectWithTag(TargetTag).transform;	    
			}
		}


		void Update()
		{
			transform.LookAt (Target);
		}
	}

}