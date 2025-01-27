using System;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Spawner<T> : MonoBehaviour
    where T : MonoBehaviour, IDestroyable<T>
{
    [SerializeField] private T _prefab;
    [SerializeField] private Transform _container;
    
    private ObjectPool<T> _pool;

    public event Action<T> ObjectSpawned;
    public event Action<T> ObjectDisabled;
    
    public virtual void Init()
    {
        _pool = new ObjectPool<T>(_container, _prefab);
    }

    public virtual T Spawn()
    {
        T newObject = _pool.Get();

        newObject.Disabled += OnDisabled;

        ObjectSpawned?.Invoke(newObject);

        return newObject;
    }

    private void OnDisabled(T obj)
    {
        obj.Disabled -= OnDisabled;
        ObjectDisabled?.Invoke(obj);
        _pool.Put(obj);
    }
}