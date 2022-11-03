using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileMovement : MonoBehaviour
{
    public UnityEvent ProjectileFinishedMovement;

    [SerializeField] private float _speed;
    [SerializeField] private CollisionProjectile _collisionProjectile;
    private bool _moving=false;
    private List<Vector2> _positions;
    private Vector2 _startPosition;
    private int _indexPosition=0;
    private float _timeСounter;


   
    private void OnDisable()
    {
        StopMoving();
    }


    void Start()
    {
        _collisionProjectile.ProjectileCollided.AddListener(StopMoving);
    }

    public void StopMoving()
    {
        _positions = null;
        transform.localPosition = Vector3.zero;
        _startPosition = transform.position;
        _moving = false;
        _indexPosition = 0;
        _timeСounter = 0;
        ProjectileFinishedMovement?.Invoke();
    }

    public void StartMoving(List<Vector2> positions)
    {
        _positions = positions;
        _startPosition = transform.position;
        _moving = true;

    }
    void Update()
    {
        if(_moving == true)
        {
            Vector2 wayVector = _positions[_indexPosition] - _startPosition;
            float way = wayVector.magnitude;
            float time = way / _speed;
            transform.position = Vector2.Lerp(_startPosition, _positions[_indexPosition], _timeСounter / time);
            _timeСounter += Time.deltaTime;
            if (_timeСounter >= time)
            {
                _startPosition = _positions[_indexPosition];
                _indexPosition++;
                if(_indexPosition>= _positions.Count)
                {
                    StopMoving();
                }
                _timeСounter = 0;


            }
        }
    }
}
