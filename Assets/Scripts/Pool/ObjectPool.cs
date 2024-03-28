using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private Transform _container;

    private Queue<T> _pool = new();
    private T _result;

    public event Action<T> Unsubscribed;

    public void SetObgect(T item)
    {
        Unsubscribed?.Invoke(item);
        item.gameObject.SetActive(false);
        item.transform.SetParent(_container);
        _pool.Enqueue(item);
    }

    protected T GetObject(T prefab)
    {
        _result = _pool.Count <= 0 ? Instantiate(prefab, _container) : _pool.Dequeue();
        _result.gameObject.SetActive(false);

        return _result;
    }
}