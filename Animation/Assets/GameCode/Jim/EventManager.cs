using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void EventDelegate();
    public static event EventDelegate OnIdleStayEvent;

    public static void OnIdleStay()
    {
        OnIdleStayEvent?.Invoke();
    }
}
