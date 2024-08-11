﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;








[System.Serializable]
public sealed class EventHandler
{
    public List<ActionBase> actions;

    public string DispalyName = "EventHandler";


    public EventGroups Groupe;
    public string Type;
    public string Properties;

    public bool ToRemove = false;

    public EventHandler()
    {

    }

    public EventHandler(string groupe, string type, string properties)
    {
        Groupe = (EventGroups)Enum.Parse(typeof(EventGroups), groupe);
        Type = type;
        Properties = properties;


        if (Groupe == EventGroups.LifeTime)
            DispalyName = Type;
        else
            DispalyName = Groupe.ToString() + Type + "-" + Properties;
    }





    public void ForcedInvoke()
    {
        // Некая оптимизация
        if (actions == null) return;

        for (int i = 0; i < actions.Count; i++)
        {

            actions[i].TryExecute();
        }
    }





    public void AddAction(Type type, GameObject gameObject, MonoBehaviour owner)
    {
        if (actions == null) actions = new List<ActionBase>();


        // не уверен что нужно так
        ActionBase action = gameObject.AddComponent(type) as ActionBase;
        action.SetOwner(owner);


        actions.Add(action);
    }

    public void ToggleHideAction(ActionBase action)
    {
        action.HideProperties = !action.HideProperties;
    }

    public bool GetHideAction(ActionBase action)
    {
        return action.HideProperties;
    }

    public void RemoveAction(ActionBase action)
    {

        GameObject.DestroyImmediate(action, true);
        actions.Remove(action);
    }

    public void RemoveAllAction()
    {
        if (actions == null) return;

        for (int i = 0; i < actions.Count; i++)
        {
            GameObject.DestroyImmediate(actions[i], true);
            actions.Remove(actions[i]);
        }
    }




    public bool TryRemoveAction()
    {
        if (actions == null) return false;

        for (int i = 0; i < actions.Count; i++)
        {
            if (actions[i] == null) continue;

            if (actions[i].ToRemove == true)
            {
                RemoveAction(actions[i]);
                return true;
            }
        }

        return false;
    }

 





}
