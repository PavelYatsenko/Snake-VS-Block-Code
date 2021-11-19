using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaneraResolution : MonoBehaviour
{
    private float _defaultWidrh;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        _defaultWidrh = _camera.orthographicSize * _camera.aspect;

    }

    private void Update()
    {
        _camera.orthographicSize = _defaultWidrh / _camera.aspect;
    }
}
