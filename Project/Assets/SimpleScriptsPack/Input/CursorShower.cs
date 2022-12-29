using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleScripts
{
	public class CursorShower : MonoBehaviour
	{
		public enum State
        {
			Show,
			Hide
        }
		[SerializeField] private State state;

	    void Start()
	    {
			if (state == State.Show)
			{
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}
	    }
		
		public void Show()
        {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		public void Hide()
        {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
	    
	}

}	