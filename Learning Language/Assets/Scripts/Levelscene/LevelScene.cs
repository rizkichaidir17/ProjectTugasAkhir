using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScene : MonoBehaviour
{

    [Header("level")]
    public GameObject levelHello;
    public GameObject levelTiger;
    public GameObject Levelwolf;
    public GameObject levelbeer;
    public GameObject leveldeer;
    public GameObject levelhorse;

    [Header("Posisi")]
    public GameObject posisiIn;
    public GameObject posisiOut1;

    Vector3 levelPosition;
    Vector3 levelPositionOutKiri;

    int levelInt = 1;

    private readonly string selectedLevel = "SelectedLevel";

    private void Awake()
    {
        levelPosition = posisiIn.transform.position;
        levelPositionOutKiri = posisiOut1.transform.position;

    }

    public void NextLevel()
    {
        switch(levelInt)
        {
            case 1:
                PlayerPrefs.SetInt(selectedLevel, 1);
                levelHello.transform.position = levelPositionOutKiri;
                levelTiger.transform.position = levelPosition;
                levelInt++;
                break;
            case 2:
                PlayerPrefs.SetInt(selectedLevel, 2);
                levelTiger.transform.position = levelPositionOutKiri;
                Levelwolf.transform.position = levelPosition;
                levelInt++;
                break;
            case 3:
                PlayerPrefs.SetInt(selectedLevel, 3);
                Levelwolf.transform.position = levelPositionOutKiri;
                levelbeer.transform.position = levelPosition;
                levelInt++;
                break;
            case 4:
                PlayerPrefs.SetInt(selectedLevel, 4);
                levelbeer.transform.position = levelPositionOutKiri;
                leveldeer.transform.position = levelPosition;
                levelInt++;
                break;
            case 5:
                PlayerPrefs.SetInt(selectedLevel, 5);
                leveldeer.transform.position = levelPositionOutKiri;
                levelhorse.transform.position = levelPosition;
                levelInt++;
                break;
            case 6:
                PlayerPrefs.SetInt(selectedLevel, 6);
                levelhorse.transform.position = levelPositionOutKiri;
                levelHello.transform.position = levelPosition;
                levelInt++;
                ResetInt();
                break;
            default:
                PlayerPrefs.SetInt(selectedLevel, 6);
                ResetInt();
                break;
        }
    }
    
    public void PreviousLevel()
    {
        switch(levelInt)
        {
            case 1:
                PlayerPrefs.SetInt(selectedLevel, 5);
                levelHello.transform.position = levelPositionOutKiri;
                levelhorse.transform.position = levelPosition;
                levelInt--;
                break;
            case 2:
                PlayerPrefs.SetInt(selectedLevel, 6);
                levelhorse.transform.position = levelPositionOutKiri;
                levelHello.transform.position = levelPosition;
                levelInt--;
                ResetInt();
                break;
            case 3:
                PlayerPrefs.SetInt(selectedLevel, 1);
                Levelwolf.transform.position = levelPositionOutKiri;
                levelTiger.transform.position = levelPosition;
                levelInt--;
                break;
            case 4:
                PlayerPrefs.SetInt(selectedLevel, 2);
                levelbeer.transform.position = levelPositionOutKiri;
                Levelwolf.transform.position = levelPosition;
                levelInt--;
                break;
            case 5:
                PlayerPrefs.SetInt(selectedLevel,3);
                leveldeer.transform.position = levelPositionOutKiri;
                levelbeer.transform.position = levelPosition;
                levelInt--;
                break;
            case 6:
                PlayerPrefs.SetInt(selectedLevel, 5);
                levelhorse.transform.position = levelPositionOutKiri;
                levelhorse.transform.position = levelPosition;
                levelInt--;
                break;
            default:
                
                ResetInt();
                break;
        }
    }
    private void ResetInt()
    {
        if (levelInt >= 6)
        {
            levelInt = 1;
        }
        else
        {
            levelInt = 6;
        }
    }
}
