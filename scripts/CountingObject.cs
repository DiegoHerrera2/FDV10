using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CountingPickup : MonoBehaviour 
{
    public int count = 0;
    public void OnMouseUpAsButton()
    {
        count++;
        MyObjectPool.ObjectPoolInstance.Release(gameObject);
    }
}