using System;
using UnityEngine;

public class BoltInteractionHandler : MonoBehaviour
{
    private bool _isEnable = false;

    public event Action Pressed;

    private void OnMouseDown()
    {
        if (_isEnable == false)
            return;

        Pressed?.Invoke();  // Bolt
        _isEnable = false;
    }

    public void ActivateClick() => _isEnable = true;
}