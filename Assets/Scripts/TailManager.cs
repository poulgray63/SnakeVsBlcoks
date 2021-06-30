using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TailManager : MonoBehaviour
{
    [SerializeField] private TailSegment _segmentPrefab;

    public List<TailSegment> Create(int lenght) 
    {
        List<TailSegment> tail = new List<TailSegment>();

        for (int i = 0; i < lenght; i++) 
        {
            tail.Add(Instantiate(_segmentPrefab, transform));
        }

        return tail;
    }

}
