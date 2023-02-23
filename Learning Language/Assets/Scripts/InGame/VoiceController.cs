using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpeech;
using UnityEngine.UI;
using UnityEngine.Android;
using System;

public class VoiceController : MonoBehaviour
{
    const string LANG_CODE = "en-US";


    public Text uiText;
    public Text hurufBesar;
    public Text hurufBesar1;
    public Text hurufBesar2;
    public Text hurufBesar3;
    public Text hurufBesar4;
    public Text huruKecil1;
    public Text hurufKecil2;
    public Text hurufKecil3;
    public Text hurufKecil4;
    public Text hurufKecil5;
    public GameObject youwin1;
    public GameObject youwin2;
    public GameObject youwin3;
    public GameObject youwin4;
    public GameObject youwin5;
    public GameObject youlose1;
    public GameObject youlose2;
    public GameObject youlose3;
    public GameObject youlose4;
    public GameObject youlose5;

    int huruf = 1;

    private readonly string selectedHuruf = "SelectedHuruf";

    void Start()
    {
        Setup(LANG_CODE);
        CheckPermission();


#if UNITY_ANDROID
        SpeechToText.instance.onPartialResultsCallback = OnPartialSpeechResult;
    #endif 
        SpeechToText.instance.onResultCallback = OnFinalSpeechResult;
        TextToSpeech.instance.onStartCallBack = OnSpeakStart;
        TextToSpeech.instance.onDoneCallback = OnSpeakStop;
    
    }


    void CheckPermission()
    {
    #if UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
    #endif
    }

    #region Text to Speech

    public void StartSpeaking(string message)
    {
        TextToSpeech.instance.StartSpeak(message);
    }

    public void StopSpeaking()
    {
        TextToSpeech.instance.StopSpeak();
    }

    void OnSpeakStart()
    {
        Debug.Log("Talking started...");
    }

    void OnSpeakStop()
    {
        Debug.Log("Talking Stop");
    }

    #endregion

    #region Speech To Text
    
    public void StartListening()
    {
        SpeechToText.instance.StartRecording();
    }
    public void StopListening()
    {
        SpeechToText.instance.StopRecording();
    }

    public void OnFinalSpeechResult(string result)
    {
        uiText.text = result;
        switch(huruf)
        {
            case 1:
                PlayerPrefs.SetInt(selectedHuruf, 1);
                if (result == huruKecil1.text || result == hurufBesar.text)
                {
                    youwin1.SetActive(true);
                    GameControl.instance.point ++;
                    GameControl.instance.pointHuruf ++;
                    FindObjectOfType<AudioManager>().Play("EjaanBenar");
                }
                else
                {
                    youlose1.SetActive(true);
                    GameControl.instance.TakeDamage(1);
                    GameControl.instance.pointHuruf++;
                    FindObjectOfType<AudioManager>().Play("EjaanSalah");
                }
                huruf++;
                break;
            case 2:
                PlayerPrefs.SetInt(selectedHuruf, 2);
                if (result == hurufKecil2.text || result == hurufBesar1.text)
                {
                    youwin2.SetActive(true);
                    GameControl.instance.point ++;
                    GameControl.instance.pointHuruf++;
                    FindObjectOfType<AudioManager>().Play("EjaanBenar");
                }
                else
                {
                    youlose2.SetActive(true);
                    GameControl.instance.TakeDamage(1);
                    GameControl.instance.pointHuruf++;
                    FindObjectOfType<AudioManager>().Play("EjaanSalah");
                }
                huruf++;
                break;
            case 3:
                PlayerPrefs.SetInt(selectedHuruf, 3);
                if (result == hurufKecil3.text || result == hurufBesar2.text)
                {
                    youwin3.SetActive(true);
                    GameControl.instance.point ++;
                    GameControl.instance.pointHuruf++;
                    FindObjectOfType<AudioManager>().Play("EjaanBenar");
                }
                else
                {
                    youlose3.SetActive(true);
                    GameControl.instance.TakeDamage(1);
                    GameControl.instance.pointHuruf++;
                    FindObjectOfType<AudioManager>().Play("EjaanSalah");
                }
                huruf++;
                break;
            case 4:
                PlayerPrefs.SetInt(selectedHuruf, 4);
                if (result == hurufKecil4.text || result == hurufBesar3.text)
                {
                    youwin4.SetActive(true);
                    GameControl.instance.point ++;
                    GameControl.instance.pointHuruf++;
                    FindObjectOfType<AudioManager>().Play("EjaanBenar");
                }
                else
                {
                    youlose4.SetActive(true);
                    GameControl.instance.TakeDamage(1);
                    GameControl.instance.pointHuruf++;
                    FindObjectOfType<AudioManager>().Play("EjaanSalah");
                }
                huruf++;
                break;
            case 5:
                PlayerPrefs.SetInt(selectedHuruf, 5);
                if(hurufKecil5 != null)
                {
                    if (result == hurufKecil5.text || result == hurufBesar4.text)
                    {
                        youwin5.SetActive(true);
                        GameControl.instance.point++;
                        GameControl.instance.pointHuruf++;
                        FindObjectOfType<AudioManager>().Play("EjaanBenar");
                    }
                    else
                    {
                        youlose5.SetActive(true);
                        GameControl.instance.TakeDamage(1);
                        GameControl.instance.pointHuruf++;
                        FindObjectOfType<AudioManager>().Play("EjaanSalah");
                    }
                }
                huruf++;
                break;
        }

    }
    
    public void OnPartialSpeechResult(string result)
    {
          uiText.text = result;
    }
    
    #endregion


    void Setup(string code)
    {
        TextToSpeech.instance.Setting(code, 1, 1);
        SpeechToText.instance.Setting(code);
    }
}
