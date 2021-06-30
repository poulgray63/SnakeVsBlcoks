using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TailManager))]
public class Snake : MonoBehaviour
{
    [SerializeField] private SnakeHead _head;

    [SerializeField] private int _tailLenght;
    private TailManager _tailManager;
    private List<TailSegment> _tail;

    public event UnityAction<int> LenghtUpdated;

    [SerializeField] private float _tailSpeed;

    private void Awake()
    {
        _tailManager = GetComponent<TailManager>();
        _tail = _tailManager.Create(_tailLenght);

        LenghtUpdated?.Invoke(_tail.Count);
    }

    private void OnEnable()
    {
        _head.BlockCollided += OnBlockCollided;
        _head.FoodCollided += OnFoodCollided;
    }

    private void OnDisable()
    {
        _head.BlockCollided -= OnBlockCollided;
        _head.FoodCollided -= OnFoodCollided;
    }

    private void FixedUpdate()
    {
        Move(); 
    }

    private void Move()
    {
        Vector2 previousPosition = _head.transform.position;

        foreach (TailSegment a in _tail)
        {
            Vector2 temp = a.transform.position;
            a.transform.position = Vector2.Lerp(a.transform.position, previousPosition, _tailSpeed);
            previousPosition = temp;
        }
    }

    private void OnBlockCollided()
    {
        TailSegment segmentToDelete = _tail[_tail.Count - 1];
        _tail.Remove(segmentToDelete);
        Destroy(segmentToDelete.gameObject);

        LenghtUpdated?.Invoke(_tail.Count);
    }

    private void OnFoodCollided(int size)
    {
        _tail.AddRange(_tailManager.Create(size));
        LenghtUpdated?.Invoke(_tail.Count);
    }
}
