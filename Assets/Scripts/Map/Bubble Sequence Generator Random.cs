using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bubble Sequence Generator Random", order = 100)]
public class BubbleSequenceGeneratorRandom : BubbleSequenceGenerator
{
    [SerializeField] Bubble[] bubbles;

    public override Bubble NextBubble()
    {
        int randomint = Random.Range(0, bubbles.Length);
        return bubbles[randomint];
    }

    
}
