using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public GameObject[] nyawa;
    private int life;
    private bool dead;

    [Header("Star")]
    public GameObject[] stars;
    [HideInInspector]
    public int point;
    [HideInInspector]
    public int pointHuruf;

    public int huruf;
    public GameObject panelGameOver;
    public GameObject panelGameWin;

    GameObject audioManager;

    public int levelToReach;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
        audioManager = GameObject.Find("AudioManager");
    }

    void Start()
    {
        life = nyawa.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if(dead == true)
        {
            GameOver();
        }
        
        if(point == 1)
        {
            stars[0].SetActive(true);
        }
        else if (point == 2)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
        }
        else if (point >= 4)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
        }
        if(pointHuruf == huruf && life >= 1)
        {
            GameWIn();
        }

    }

    public void TakeDamage(int d)
    {
        if(life >= 1)
        {
            life -= d;
            Destroy(nyawa[life].gameObject);
            if(life < 1)
            {
                dead = true;
            }
        }
    }

   public void HomeButton()
    {
        SceneManager.LoadScene("Homescene");
        FindObjectOfType<AudioManager>().Play("Button");
    }

    public void GameOver()
    {
        panelGameOver.SetActive(true);
        FindObjectOfType<AudioManager>().Play("Kalah");
    }
    
    public void GameWIn()
    {
        panelGameWin.SetActive(true);
        PlayerPrefs.SetInt("currentLevel", levelToReach);
        FindObjectOfType<AudioManager>().Play("Win");
    }
  
    public void PauseButton()
    {
        FindObjectOfType<AudioManager>().Play("Button");
    }

 


}
