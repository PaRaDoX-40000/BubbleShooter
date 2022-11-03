using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionProjectile : MonoBehaviour
{
    public UnityEvent ProjectileCollided;

    private int _colorNumber;
    private Bubble _bubble;
    private SpriteRenderer _spriteRenderer;
    private bool _ready =true;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
   
    public void SetColorNumber(Bubble bubble)
    {
        _colorNumber = bubble.ColorNumber;
        _spriteRenderer.color = bubble.gameObject.GetComponent<SpriteRenderer>().color;
        _bubble = bubble;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MapBubble mapBubble = collision.gameObject.GetComponentInParent<MapBubble>();
        
        if (mapBubble != null)
        {
            if (_ready == true)
            {
                StartCoroutine(Cooldown(0.1f));
                Bubble collisionBubble = collision.gameObject.GetComponentInParent<Bubble>();

                Vector2 hitVector = (Vector2)(transform.position - collision.gameObject.transform.position);
                hitVector = RoundingVector(hitVector);
                if (mapBubble.TryAddbubble(hitVector, collisionBubble, _bubble.ColorNumber, out Bubble bubble) == true)
                {
                    BubblesDisable(bubble, mapBubble);
                }
                else
                {
                    BubblesDisable(collisionBubble, mapBubble);
                }
                ProjectileCollided?.Invoke();
            }        
        }     
    }
   

    private void BubblesDisable(Bubble bubble, MapBubble mapBubble)
    {
        mapBubble.DestroyNearBubbles(bubble);
    }

    private Vector2 RoundingVector(Vector2 hitVector)
    {
        
        hitVector = hitVector.normalized;        
        if (hitVector.y >= 0.5f)
        {
            hitVector.y = 1;
        }
        if (hitVector.y < 0.5f && hitVector.y > -0.5f)
        {
            hitVector.y = 0;
        }
        if (hitVector.y <= -0.5f)
        {
            hitVector.y = -1;
        }
        if (hitVector.x >= 0f)
        {
            hitVector.x = 1;
        }
        if (hitVector.x < -0f)
        {
            hitVector.x = -1;
        }
        return hitVector;       
    }

    private IEnumerator Cooldown(float t)
    {
        _ready = false;
        yield return new WaitForSeconds(t);
        _ready = true;
    }
}
