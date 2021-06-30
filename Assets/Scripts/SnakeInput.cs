using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeInput : MonoBehaviour
{
    [SerializeField] private SnakeHead _head;
    private Camera _camera;

    private Vector2 _direction;

    public Vector2 Direction 
    {
        get { return _direction; }
    }

    private void Update()
    {
    }

    public Vector2 GetDirection(Vector3 headPosition) 
    {
        Vector3 currentDragPosition = _camera.ScreenToViewportPoint(Input.mousePosition);
        currentDragPosition.y = 1;
        currentDragPosition = _camera.ViewportToWorldPoint(currentDragPosition);
        Vector3 direction = (currentDragPosition - headPosition).normalized;

        return direction;
    }

    private void Awake()
    {
        _camera = Camera.main;
    }

}
