using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Food : MonoBehaviour
{
    [SerializeField] private TMP_Text _view;

    private int _size;
    
    public int Collect() 
    {
        Destroy(gameObject);
        return _size;
    }

    private void Start()
    {
        _size = Random.Range(1, 10);
        _view.text = _size.ToString();
    }
}
