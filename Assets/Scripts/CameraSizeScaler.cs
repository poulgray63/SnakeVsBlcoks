using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSizeScaler : MonoBehaviour
{
    private const float _defaultWidth = 2.53125f;

    private void Awake()
    {
        Camera.main.orthographicSize = _defaultWidth / Camera.main.aspect;
    }
}
