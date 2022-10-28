using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleGun : MonoBehaviour
{
    [SerializeField] private ProjectileMovement _projectileMovement;
    private Vector2 _pathVector = new Vector2();
    [SerializeField] private LayerMask _layerMaskBubble;
    






    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
                              

        }
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 touch = Input.mousePosition;
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch);
            _pathVector = (touchPosition - (Vector2)transform.position);
            _pathVector = _pathVector.normalized;
            Vector2 statrPosition = transform.position;

            List<Vector2> positions = new List<Vector2>();
            int i = 0;
            while (true)
            {                
                RaycastHit2D hit = Physics2D.Raycast(statrPosition, _pathVector);
                if (hit==true)
                {
                   
                    positions.Add(hit.point);

                    if (hit.collider.gameObject.layer == 8)
                    {
                        _projectileMovement.StartMoving(positions);
                        break;
                    }
                    else
                    {                     
                        statrPosition = hit.point - new Vector2(_pathVector.x*1,0);
                        
                        _pathVector.x = _pathVector.x * -1;                                              
                    }
                }
                i++;
                if (i > 20)
                {
                    Debug.Log("Привышен лимит");
                    
                    break;
                }
            }
            
        }
    }
}
