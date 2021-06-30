using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class SnakeHead : MonoBehaviour
{
    [SerializeField] private SnakeInput _input;
    [SerializeField] private float speed;

    private Rigidbody2D _rigidbody;

    public event UnityAction BlockCollided;
    public event UnityAction<int> FoodCollided;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody.position += ((Vector2)transform.up * speed);
        transform.up = _input.GetDirection(transform.position);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Block>(out Block block))
        {
            block.ApplyDamage();
            BlockCollided?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Food>(out Food food))
        {
            FoodCollided?.Invoke(food.Collect());
        }
    }
}
