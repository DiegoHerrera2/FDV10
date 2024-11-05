using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class MyObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private static ObjectPool<GameObject> _instance;
    private float _delay = 1f;
    // static getter for the object pool
    public static ObjectPool<GameObject> ObjectPoolInstance => _instance;
    
    private void Start()
    {
        _instance = new ObjectPool<GameObject>( 
            () => Instantiate(prefab),
            instance => instance.SetActive(true),
            instance =>
            {
                if (_instance.CountActive <= 3) return;
                instance.SetActive(false);
                if (instance.GetComponent<CountingPickup>().count >= 3 ) Destroy(instance);
            },
            instance => Destroy(instance)
            );
        // prewarm the pool with 10 instances
        for (var i = 0; i < 10; i++)
        {
            var pooledObject = _instance.Get();
            pooledObject.transform.position = new Vector3((i-5) * 1.1f, 0, 0);
        }
    }
    
    
    private void Update()
    {
        
        // If there is less than 10 objects active in the scene, spawn a new one
        if (_instance.CountActive < 10 && _delay <= 0)
        {
            _instance.Get();
            _delay = 1f;
        }
        else
        {
            _delay -= Time.deltaTime;
        }
        
    }
    
}
