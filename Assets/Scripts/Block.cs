using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    private int _health;

    public event UnityAction HealthUpdated;

    public int Health 
    {
        get { return _health; }
        private set 
        {
            _health = value;
            OnHealthUpdated();
        }
    }

    public void ApplyDamage() 
    {
        Health--;
    }

    private void Awake()
    {
        _health = Random.Range(1, 15);
        HealthUpdated?.Invoke();
    }

    private void OnHealthUpdated() 
    {
        HealthUpdated?.Invoke();
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
