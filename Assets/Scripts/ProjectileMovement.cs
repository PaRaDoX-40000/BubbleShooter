using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool moving=false;
    private List<Vector2> _positions;
    private Vector2 startPosition;
    private int _indexPosition=0;
    private float i;//!!!!!!!!!!!!!! 

    void Start()
    {
        
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
            transform.position = Vector2.Lerp(startPosition, _positions[_indexPosition], i / time);
            i += Time.deltaTime;
            if (i >= time)
            {
                startPosition = _positions[_indexPosition];
                _indexPosition++;
                if(_indexPosition>= _positions.Count)
                {
                    moving = false;
                    _indexPosition = 0;
                }
                i = 0;

            }
        }
    }
}
