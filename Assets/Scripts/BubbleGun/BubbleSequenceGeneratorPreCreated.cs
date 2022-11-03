using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bubble Sequence Generator Pre Created", menuName = "Bubble Sequence Generator/Pre Created", order = 100)]
public class BubbleSequenceGeneratorPreCreated : BubbleSequenceGenerator
{
    [SerializeField] private Bubble[] _bubbles;
    private int _index=-1;

    public override Bubble NextBubble()
    {
        if (_index == _bubbles.Length-1)
        {
            _index = -1;
        }
        _index++;
        return _bubbles[_index];
       
    }
}
