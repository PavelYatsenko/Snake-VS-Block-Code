using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bonus : MonoBehaviour
{

    [SerializeField] private TMP_Text _view;
    [SerializeField] private Vector2Int _bounusSizeRange;

    private int _bounusSize;

    private void Start()
    {
        _bounusSize = Random.Range(_bounusSizeRange.x, _bounusSizeRange.y);
        _view.text = _bounusSize.ToString();

    }

    public int Collect()
    {
        Destroy(gameObject);
        return _bounusSize;
    }
}
