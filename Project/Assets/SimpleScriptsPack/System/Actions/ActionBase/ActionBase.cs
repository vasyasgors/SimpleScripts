using System;
using System.Reflection;
using UnityEngine;

public enum ActionOwner
{
    Self,
    Other,
    Specific
}

public abstract class ActionBase : MonoBehaviour
{ 
    [HideInInspector] public bool HideProperties;

    [HideInInspector] public bool ToRemove = false;


    private MonoBehaviour owner;
    private bool ownerHasAssigned = false;

    public virtual void StartExecute() { }

    public virtual string GetShortDescription() { return name; }
 


    public void SetOwner(MonoBehaviour owner)
    {
        this.owner = owner;
        ownerHasAssigned = true;

        hideFlags = HideFlags.HideInInspector;

#if UNITY_EDITOR
        UnityEditor.EditorApplication.update += TryDestroy;
#endif
    }

    public bool TryExecute()
    {
        StartExecute();
            
        return false;
    }


#if UNITY_EDITOR
    private void TryDestroy()
    {

        if (owner == null)
        {
            UnityEditor.EditorApplication.update -= TryDestroy;
            DestroyImmediate(this);
        }
    }

#endif

#if UNITY_EDITOR
    private void OnValidate()
    {
           hideFlags = HideFlags.HideInInspector;
    }
#endif

}

