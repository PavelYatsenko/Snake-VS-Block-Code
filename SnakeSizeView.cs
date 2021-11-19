using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[RequireComponent(typeof(Snake))]
public class SnakeSizeView : MonoBehaviour
{


    [SerializeField] private TMP_Text _view;

    private Snake _snake;

    private void Awake()
    {
        _snake = GetComponent<Snake>();
    }

    private void OnEnable()
    {
        print("jj");
        _snake.SizeUpdate += OnSizeUpdate;
    }

    private void OnDisable()
    {
        _snake.SizeUpdate -= OnSizeUpdate;
    }

    private void OnSizeUpdate(int size)
    {
        print("size");
        _view.text = size.ToString();
    }
}
