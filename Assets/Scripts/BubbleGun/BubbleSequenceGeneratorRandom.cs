using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bubble Sequence Generator Random",menuName = "Bubble Sequence Generator/Random", order = 100)]
public class BubbleSequenceGeneratorRandom : BubbleSequenceGenerator
{
    [SerializeField] private Bubble[] _bubbles;

    public override Bubble NextBubble()
    {
        int randomint = Random.Range(0, _bubbles.Length);
        return _bubbles[randomint];
    }

    
}
