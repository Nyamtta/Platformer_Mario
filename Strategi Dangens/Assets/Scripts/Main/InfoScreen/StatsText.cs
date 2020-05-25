using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsText : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private LevelInfo.Parameters _thisParameter;
    [SerializeField] private LevelInfo _levelInfo;
    [SerializeField] private string InfoText;

    private void Start() {

        _text.text = InfoText + "\n" + _levelInfo.GetParametr(_thisParameter);
        _levelInfo.UpdateParametersText += UpdateText;
    }

    private void UpdateText() {

        _text.text = InfoText + "\n" + _levelInfo.GetParametr(_thisParameter);
    }

}
