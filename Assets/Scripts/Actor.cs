using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public event Action EOnEnable = null;
    public event Action EOnDisable = null;


    protected virtual void OnEnable()
    {
        EOnEnable?.Invoke();
    }

    protected virtual void OnDisable()
    {
        EOnDisable?.Invoke();
    }

}
