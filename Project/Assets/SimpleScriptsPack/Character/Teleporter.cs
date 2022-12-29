using SimpleFPS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleScripts
{
	public class Teleporter : MonoBehaviour
	{
		[SerializeField] private Teleporter Target;

		[HideInInspector] public bool IsReceive = false;

		void OnTriggerEnter(Collider col)
		{
			if (IsReceive == true) return;

			FirstPersonController fps = col.GetComponent<FirstPersonController>();

			if (fps == null) return;

			Target.IsReceive = true;

			col.transform.position = Target.transform.position;
			
		}

		void OnTriggerExit(Collider col)
		{
			FirstPersonController fps = col.GetComponent<FirstPersonController>();

			if (fps == null) return;

			IsReceive = false;
			
		}


	}
}