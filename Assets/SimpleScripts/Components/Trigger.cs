using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SimpleScripts
{
	public class Trigger : MonoBehaviour 
	{
		[SerializeField] protected string Tag = "Player";

		[SerializeField] private UnityEvent OnEnter;
		[SerializeField] private UnityEvent OnExit;
		[SerializeField] private UnityEvent OnStay;

		void OnTriggerEnter(Collider col)
		{
			if(Tag == "")
            {
				OnEnter.Invoke();
				return;
			}

			if (col.tag != Tag) return;
			
			OnEnter.Invoke ();
		}

		void OnTriggerStay(Collider col)
		{

			if (Tag == "")
			{
				OnStay.Invoke();
				return;
			}


			if (col.tag != Tag) return;


			OnStay.Invoke();
		}

		void OnTriggerExit(Collider col)
		{
			if (Tag == "")
			{
				OnExit.Invoke();
				return;
			}

			if (col.tag != Tag) return;

			OnExit.Invoke ();
		}
	}

}