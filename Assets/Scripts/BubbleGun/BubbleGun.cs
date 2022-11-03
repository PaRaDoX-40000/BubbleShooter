using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class BubbleGun : MonoBehaviour
{
    [SerializeField] private CollisionProjectile _collisionProjectile;
    [SerializeField] private ProjectileMovement _projectileMovement;  
    [SerializeField] private BubbleSequenceGenerator _bubbleSequenceGenerator;
    private LineRenderer _lineRenderer;
    private Vector2 _pathVector = new Vector2();
    private bool _canShoot = true;
    private bool _touchedBubble = false;
    private List<Vector2> _positions = new List<Vector2>();


    void Start()
    {
        _projectileMovement.ProjectileFinishedMovement.AddListener(CanShootTrue);
        _lineRenderer = GetComponent<LineRenderer>();
        
    }

    private void OnEnable()
    {
        CanShootTrue();
    }
    private void OnDisable()
    {
        _lineRenderer.positionCount = 0;
    }


    public void SetBubbleSequenceGenerator(BubbleSequenceGenerator bubbleSequenceGenerator)
    {
        _bubbleSequenceGenerator = bubbleSequenceGenerator;
    }

    private void CanShootTrue()
    {
        _canShoot = true;
        _collisionProjectile.SetColorNumber(_bubbleSequenceGenerator.NextBubble());
    }




    void Update()
    {
        if (_canShoot == true)
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 touch = Input.mousePosition;
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch);
                _pathVector = (touchPosition - (Vector2)transform.position);
                _pathVector = _pathVector.normalized;
                Vector2 statrPosition = transform.position;

                _positions.Clear();
                int i = 0;
                while (true)
                {
                    RaycastHit2D hit = Physics2D.Raycast(statrPosition, _pathVector);
                    if (hit == true)
                    {

                        _positions.Add(hit.point);

                        if (hit.collider.gameObject.layer == 8)
                        {
                            _touchedBubble = true;
                            break;
                        }
                        else
                        {
                            statrPosition = hit.point - new Vector2(_pathVector.x * 1, 0);
                            _pathVector.x = _pathVector.x * -1;
                        }
                    }
                    i++;
                    if (i > 30)
                    {
                        Debug.Log("Привышен лимит");
                        _touchedBubble = false;
                        break;
                    }
                }
                
                    _lineRenderer.positionCount = _positions.Count+1;
                    _lineRenderer.SetPosition(0, transform.position);
                    for (int j =0;j< _positions.Count; j++)
                    {
                        _lineRenderer.SetPosition(j+1, _positions[j]);
                    }
                    
                
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (_touchedBubble == true)
                {
                    _projectileMovement.StartMoving(_positions);
                    _canShoot = false;
                    _lineRenderer.positionCount = 0;
                }
                
            }
        
            
        }
    }
}
