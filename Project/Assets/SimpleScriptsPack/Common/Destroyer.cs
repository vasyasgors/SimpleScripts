using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleScripts
{
	public class Destroyer : MonoBehaviour
	{
		public enum DestroyMode
        {
			Start,
			Invoke
        }

		[SerializeField] private DestroyMode mode;
        [SerializeField] private float delay;

		void Start()
        {
			if (mode == DestroyMode.Start)
				Destroy(gameObject, delay);
        }

		public void StartDestroy()
        {
			Destroy(gameObject, delay);
		}

	}
}
