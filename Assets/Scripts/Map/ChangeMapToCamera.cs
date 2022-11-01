using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMapToCamera : MonoBehaviour
{
    [SerializeField] private GameObject _borderTop;
    [SerializeField] private GameObject _borderLeft;
    [SerializeField] private GameObject _borderRight;
    [SerializeField] private GameObject _map;


    void Start()
    {
        MoveBoundariesCamera();
    }

    private void MoveBoundariesCamera()
    {      
        _borderTop.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1f, Camera.main.nearClipPlane));
        _borderLeft.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0.5f, Camera.main.nearClipPlane));
        _borderRight.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0.5f, Camera.main.nearClipPlane));
        _map.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.98f, Camera.main.nearClipPlane));

    }



    void Update()
    {
        
    }
}
