using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAcitons : MonoBehaviour
{
    GameManager gm;

    private void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void Retry()
    {
      
        SceneManager.LoadScene(1);
        GameManager.instance.lives = 3;
        GameManager.instance.score = 0;
    }

    public void GameLoad()
    {

        SceneManager.LoadScene(1);
       
    }
    public void Exit()
    {
        Application.Quit();
    }
}
