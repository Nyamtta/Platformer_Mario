using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeText : MonoBehaviour
{
    [SerializeField] LevelInfo _levelInfo;
    [SerializeField] TextMeshProUGUI _text;
    private float TimeOnLevel;

    private void Start() {
        TimeOnLevel = _levelInfo.GetTime();
    }

    private void Update() {

        UpdaiteTime();
        
    }

    private void UpdaiteTime() {

        TimeOnLevel -= Time.deltaTime;
        _text.text = "TIME\n" + (int)TimeOnLevel;
    }

    private void CheckTime() {

        if(TimeOnLevel <= 60) {

        }
        if(TimeOnLevel <= 0) {

        }

    }

}
