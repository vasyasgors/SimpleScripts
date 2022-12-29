using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SimpleScripts
{
	public class Mover : MonoBehaviour
	{
		[SerializeField] private Vector3 speed;

		void Update()
		{
			transform.Translate(speed * Time.deltaTime);
		}
	}
}
