using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _offset;
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3
            (transform.position.x, _target.position.y + _offset, transform.position.z), _speed * Time.deltaTime);
    }
}
