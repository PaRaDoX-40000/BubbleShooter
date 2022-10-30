using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private CollisionProjectile _collisionProjectile;
    private bool moving=false;
    private List<Vector2> _positions;
    private Vector2 startPosition;
    private int _indexPosition=0;
    private float _timeСounter;

    public UnityEvent ProjectileFinishedMovement;

    void Start()
    {
        _collisionProjectile.ProjectileCollided.AddListener(StopMoving);
    }

    public void StopMoving()
    {
        _positions = null;
        transform.localPosition = Vector3.zero;
        startPosition = transform.position;
        moving = false;
        _indexPosition = 0;
        _timeСounter = 0;
        ProjectileFinishedMovement?.Invoke();
    }

    public void StartMoving(List<Vector2> positions)
    {
        _positions = positions;
        startPosition = transform.position;
        moving = true;

    }
    void Update()
    {
        if(moving == true)
        {
            Vector2 wayVector = _positions[_indexPosition] - startPosition;
            float way = wayVector.magnitude;
            float time = way / speed;
            transform.position = Vector2.Lerp(startPosition, _positions[_indexPosition], _timeСounter / time);
            _timeСounter += Time.deltaTime;
            if (_timeСounter >= time)
            {
                startPosition = _positions[_indexPosition];
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
