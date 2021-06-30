using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Block))]
public class BlockHealthView : MonoBehaviour
{
    [SerializeField] private TMP_Text _view;
    
    private Block _block;

    private void Awake()
    {
        _block = GetComponent<Block>();
    }

    private void OnEnable()
    {
        _block.HealthUpdated += OnHealthUpdated;
    }

    private void OnDisable()
    {
        _block.HealthUpdated -= OnHealthUpdated;
    }

    private void OnHealthUpdated() 
    {
        _view.text = _block.Health.ToString();
    }
}
