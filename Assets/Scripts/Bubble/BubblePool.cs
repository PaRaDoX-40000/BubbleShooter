using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BubblePool : MonoBehaviour
{
    [SerializeField] private BubbleCount[] _bubbleCounts;
    [SerializeField] private List<List<Bubble>> _bubbles = new List<List<Bubble>>();
    [SerializeField] private Transform _connector;

    private void Awake()
    {
        CreateBubbles();
       
    }
   
    private void CreateBubbles()
    {
        for (int i = 0; i < _bubbleCounts.Length; i++)
        {
            List<Bubble> bubbles = new List<Bubble>();
            for (int j = 0; j < _bubbleCounts[i].Count; j++)
            {
                Bubble bubble = Instantiate(_bubbleCounts[i].Bubble, _connector);
                bubble.gameObject.SetActive(false);
                bubbles.Add(bubble);
            }
            _bubbles.Add(bubbles);
        }       
    }
    private Bubble CreateOneBubbles(Bubble bubble)
    {
        Bubble bubbleClone = Instantiate(bubble, _connector);
        bubbleClone.gameObject.SetActive(false);
        return bubbleClone;
    }

    public bool TryGetBubble(out Bubble bubble,int colorNumber)
    {
        List<Bubble> bubbles;
       
        try
        {
            bubbles = _bubbles.First(q => q[0].ColorNumber == colorNumber);
        }
        catch
        {
            bubbles = null;
        }
        
        if (bubbles != null)
        {

            try
            {
                bubble = bubbles.First(q => q.gameObject.activeSelf == false);
            }
            catch
            {
                bubble = null;
            }

            if (bubble != null)
            {                
                return true;
            }
            else
            {
                bubble = CreateOneBubbles(bubbles[0]);
                bubbles.Add(bubble);
                return true;
            }
        }
        else
        {
            Debug.LogError("не найден в массиве номер цвета " + colorNumber);
            
        }
        bubble = null;
        return false;
    }

    
    void Update()
    {
        
    }
}
