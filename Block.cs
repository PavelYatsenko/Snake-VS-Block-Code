using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class Block : MonoBehaviour
{

    [SerializeField] private Vector2Int _destroyPriceRange;
    [SerializeField] private Color[] _colors;

    private SpriteRenderer _spriteRenderer;

    private int _destrouPrice;
    private int _filling;

    public int LeftToFill => _destrouPrice - _filling;

    public event UnityAction<int> FillingUpdate;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        SetColor(_colors[Random.Range(0, _colors.Length)]);
        _destrouPrice = Random.Range(_destroyPriceRange.x, _destroyPriceRange.y);
        FillingUpdate?.Invoke(LeftToFill);
        
    }

    public void Fill()
    {
        _filling++;
        FillingUpdate?.Invoke(LeftToFill);
        if (_filling == _destrouPrice)
        {
            Destroy(gameObject);
        }
    }

    private void SetColor(Color color)
    {
        _spriteRenderer.color = color;
    }
}
