using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private Transform _container;

    private List<T> _pool = new();
    private T _result;

    public void Restart()
    {
        foreach (var item in _pool)
            item.gameObject.SetActive(false);
    }

    protected T GetObject(T prefab)
    {
        _result = _pool.FirstOrDefault(item => item.gameObject.activeSelf == false);

        if (_result == null)
        {
            _result = Instantiate(prefab, _container);
            _result.gameObject.SetActive(false);
            _pool.Add(_result);
        }

        return _result;
    }
}