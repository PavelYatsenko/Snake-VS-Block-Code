using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTraker : MonoBehaviour
{

    [SerializeField] private SnakeHead _snakeHead;
    [SerializeField] private Snake _snake;
    [SerializeField] private float _speed;
    [SerializeField] private float _offsetY;


    private bool _isMove = true;
    private void OnEnable()
    {
        _snake.Dying += OnDying;
    }
    private void OnDisable()
    {
        _snake.Dying -= OnDying;
    }
    private void FixedUpdate()
    {
        if (_isMove)
            transform.Translate(Vector2.up * _speed * Time.deltaTime);
    }

    private Vector3 GetVectorPosition()
    {
        return new Vector3(transform.position.x, _snakeHead.transform.position.y + _offsetY, transform.position.z);
    }
    private void OnDying()
    {
        _isMove = false;
    }
}
