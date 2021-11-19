using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TailGenerator))]
[RequireComponent(typeof(SnakeInput))]
public class Snake : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _tailSize;
    [SerializeField] private float _tailSpringnees;
    [SerializeField] private SnakeHead _head;

    private List<Segment> _tail;
    private SnakeInput _input;
    private TailGenerator _tailGenerator;

    public event UnityAction Dying;
    public event UnityAction<int> SizeUpdate;
    
    private void Awake()
    {
        _tailGenerator = GetComponent<TailGenerator>();
        _input = GetComponent<SnakeInput>();

        _tail = _tailGenerator.Generator(_tailSize);
        
    }
    private void Start()
    {
        SizeUpdate?.Invoke(_tail.Count);
    }
    private void OnEnable()
    {
        _head.BlockCollided += OnBlockCollided;
        _head.BonusCollected += OnBonuSColledted;
    }

    private void OnDisable()
    {
        _head.BlockCollided -= OnBlockCollided;
        _head.BonusCollected -= OnBonuSColledted;
    }
    private void FixedUpdate()
    {
        Move(_head.transform.position + _head.transform.up * _speed * Time.deltaTime);

        _head.transform.up = _input.GetDiractionToClick(_head.transform.position);
    }

    private void Move(Vector3 nextPosition)
    {
        Vector3 previousPosition = _head.transform.position;

        foreach(var segment in _tail)
        {
            Vector3 tempPosition = segment.transform.position;
            segment.transform.position = Vector2.Lerp(segment.transform.position, previousPosition, _tailSpringnees * Time.deltaTime);
            previousPosition = tempPosition;
        }

        _head.Move(nextPosition);
    }

    private void OnBlockCollided()
    {
        if (_tail.Count <= 1)
        {
            Dying?.Invoke();
            Destroy(gameObject);
        }
        Segment deletedSegment = _tail[_tail.Count - 1];
        _tail.Remove(deletedSegment);
        Destroy(deletedSegment);
        SizeUpdate?.Invoke(_tail.Count);
    }

    private void OnBonuSColledted(int bonusSize)
    {
        _tail.AddRange(_tailGenerator.Generator(bonusSize));
        SizeUpdate?.Invoke(_tail.Count);
    }
}
