using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ActionPath("SetActive")]
public class SetActive : ActionBase
{
	public enum ToggleState
    {
		On,
		Off,
		Toogle
    }

    [SerializeField] private GameObject target;
    [SerializeField] private ToggleState state;

    public override void StartExecute()
    {
        if (state == ToggleState.Toogle) target.SetActive(!target.activeSelf);
        if (state == ToggleState.On) target.SetActive(true);
        if (state == ToggleState.Off) target.SetActive(false);
    }
}
