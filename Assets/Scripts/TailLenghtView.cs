using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TailManager))]
public class TailLenghtView : MonoBehaviour
{
    [SerializeField] private TMP_Text _view;

    private Snake _snake;

    private void Awake()
    {
        _snake = GetComponent<Snake>();
    }

    private void OnEnable()
    {
        _snake.LenghtUpdated += OnLenghtUpdated;
    }

    private void OnDisable()
    {
        _snake.LenghtUpdated -= OnLenghtUpdated;
    }

    private void OnLenghtUpdated(int lenght) 
    {
        _view.text = lenght.ToString();
    }
}
