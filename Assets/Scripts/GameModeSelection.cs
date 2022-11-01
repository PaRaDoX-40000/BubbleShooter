using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameModeSelection : MonoBehaviour
{
    [SerializeField] private MapCreator[] _mapCreators;
    [SerializeField] private BubbleSequenceGenerator[] _bubbleSequenceGenerators;
    [SerializeField] private MenuUI menuUI;
    private MapCreator _selectedMapCreator;
    private BubbleSequenceGenerator _selectedBubbleSequenceGenerator;



    private void Start()
    {
        _selectedMapCreator = _mapCreators[0];
        _selectedBubbleSequenceGenerator = _bubbleSequenceGenerators[0];
        menuUI.BttonAddListener(MenuUI.MenuButtons.RandomModMap, SelectMapCreatorRandom);
        menuUI.BttonAddListener(MenuUI.MenuButtons.PreCreatedModMap, SelectMapCreatorPreCreated);
        menuUI.BttonAddListener(MenuUI.MenuButtons.RandomModSequence, SelectBubbleSequenceGeneratorsRandom);
        menuUI.BttonAddListener(MenuUI.MenuButtons.PreCreatedModSequence, SelectBubbleSequenceGeneratorsPreCreated);
        menuUI.BttonAddListener(MenuUI.MenuButtons.Play, Play);
    }

    private void SelectMapCreatorRandom()
    {
        _selectedMapCreator = _mapCreators[0];
        menuUI.HighlightingSetActive(MenuUI.MenuButtons.RandomModMap);
    }
    private void SelectMapCreatorPreCreated()
    {
        _selectedMapCreator = _mapCreators[1];
        menuUI.HighlightingSetActive(MenuUI.MenuButtons.PreCreatedModMap);

    }
    private void SelectBubbleSequenceGeneratorsRandom()
    {
        _selectedBubbleSequenceGenerator = _bubbleSequenceGenerators[0];
        menuUI.HighlightingSetActive(MenuUI.MenuButtons.RandomModSequence);

    }
    private void SelectBubbleSequenceGeneratorsPreCreated()
    {
        _selectedBubbleSequenceGenerator = _bubbleSequenceGenerators[1];
        menuUI.HighlightingSetActive(MenuUI.MenuButtons.PreCreatedModSequence);

    }
    private void Play()
    {
        
    }




}
