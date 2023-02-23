using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeScene : MonoBehaviour
{
    public GameObject credits;
    public GameObject closeGameUI;
    protected Canvas canvas;
    
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;

    private bool muted = false;

    void Start()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        UpdateButtonIcon();

    }

    public void OnButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }
        FindObjectOfType<AudioManager>().Play("Button");
        Save();
        UpdateButtonIcon();

    }

    public void UpdateButtonIcon()
    {
        if (muted == false)
        {
            soundOffIcon.enabled = false;
            soundOnIcon.enabled = true;
        }
        else
        {
            soundOffIcon.enabled = true;
            soundOnIcon.enabled = false;
        }
    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }
    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }

    public void openCreditUI()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        FindObjectOfType<AudioManager>().Play("PopupOpen");
        FindObjectOfType<AudioManager>().Play("PopupOpenButton");
        credits.SetActive(true);
    }
    
    public void closeCreditUI()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        FindObjectOfType<AudioManager>().Play("PopupClose");
        FindObjectOfType<AudioManager>().Play("PopupCloseButton");
        credits.SetActive(false);
    }

    public void openCloseGameUI()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        FindObjectOfType<AudioManager>().Play("PopupOpen");
        FindObjectOfType<AudioManager>().Play("PopupOpenButton");
        closeGameUI.SetActive(true);
    }  
    public void closeCloseGameUI()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        FindObjectOfType<AudioManager>().Play("PopupClose");
        FindObjectOfType<AudioManager>().Play("PopupCloseButton");
        closeGameUI.SetActive(false);
    }

    public void yesQuitGame()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        Application.Quit();
    }
}
