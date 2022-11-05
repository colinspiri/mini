using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour, IProvider<T> where T : Actor
{
    [Header("Prefab to pool")]
    [SerializeField] T Object;
    [Header("How many pooled objects")]
    [SerializeField] int Headcount;

    Queue<T> Pool;

    void Awake()
    {
        Pool = new Queue<T>();

        for(int i = 0; i < Headcount; i++)
        {
            T Instance = Instantiate(Object, transform);
            Instance.gameObject.SetActive(false);
            Pool.Enqueue(Instance);

            Instance.EOnDisable += () =>
            {
                Pool.Enqueue(Instance);
            };
        }
    }

    public T Get()
    {
        var obj = Pool.Dequeue();
        obj.gameObject.SetActive(true);
        return obj;
    }
}
