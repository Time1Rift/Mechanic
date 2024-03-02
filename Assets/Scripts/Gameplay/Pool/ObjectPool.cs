using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private Transform _container;

    private Queue<T> _pool = new();
    private T _result;

    public void PutObject(T item)
    {
        _pool.Enqueue(item);
        item.transform.SetParent(_container);
        item.gameObject.SetActive(false);
    }

    protected T GetObject(T prefab)
    {
        if (_pool.Count == 0)
        {
            _result = Instantiate(prefab, _container);
            _result.gameObject.SetActive(false);

            return _result;
        }

        return _pool.Dequeue();
    }    
}