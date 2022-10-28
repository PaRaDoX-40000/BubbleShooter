using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionProjectile : MonoBehaviour
{
    public int _colorNumber;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        MapBubble mapBubble =  collision.gameObject.GetComponentInParent<MapBubble>();
        if (mapBubble != null)
        {

        }
    }
}
