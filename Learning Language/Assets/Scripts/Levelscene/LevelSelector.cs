using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Button[] tombolLevel;
    public GameObject[] border;
    private void Start()
    {
        int currentLevel = PlayerPrefs.GetInt("currentLevel", 1);

        for (int i = 0; i < tombolLevel.Length; i++)
        {
            if(i + 1 > currentLevel)
            tombolLevel[i].interactable = false;

        }   
        for (int i = 0; i < border.Length; i++)
        {
            if(i + 1 > currentLevel)
            border[i].SetActive(false);

        }
    }
}
