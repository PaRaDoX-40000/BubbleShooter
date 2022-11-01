using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonWithHighlighting : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _highlighting;

    public Button Button => _button;
    public Image Highlighting => _highlighting;
}
