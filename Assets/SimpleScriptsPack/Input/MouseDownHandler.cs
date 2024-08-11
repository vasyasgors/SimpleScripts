using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDownHandler : MonoBehaviour 
{

	public EventHandler MouseDown;

	void OnMouseDown()
    {
        MouseDown.ForcedInvoke();
    }
}
