using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelInfo : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI LevelNumber;
    [SerializeField] private float TimeOnLevel;
    public enum Parameters {PlayarScore, PlayarLife, PlayarCoin}

    public event Action UpdateParametersText;


    private void Awake() {


        LevelNumber.text = "WORLD\n" + SceneManager.GetActiveScene().name;
    }
    public void SetParametr(Parameters nameStats, int value) {
        value += GetParametr(nameStats);
        PlayerPrefs.SetInt(nameStats.ToString(), value);
        UpdateInfoBar();
    }

    public int GetParametr(Parameters nameStats){

        if(PlayerPrefs.HasKey(nameStats.ToString()) == false)
            PlayerPrefs.SetInt(nameStats.ToString(), 0);
        
        return PlayerPrefs.GetInt(nameStats.ToString());
    }

    public float GetTime() {
        return TimeOnLevel;
    }

    public void UpdateInfoBar() {

        UpdateParametersText?.Invoke();
    }

    public void Endlevel() {
        UpdateParametersText = null;
    }

}
