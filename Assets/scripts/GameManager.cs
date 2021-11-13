using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

     [SerializeField] GameObject player;

    public GameObject playerInstance;
    public static GameManager instance;
    public int score = 0;

    public int lives = 3;
    // Start is called before the first frame update
    private void Awake()
    {
        this.score = 0;
            this.lives = 3;
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            SpawnPlayer();
        }



       
      
    }
    void Start()
    {
        
    }
    void OnLevelWasLoaded(int level)
    {
      
        if(level == 4)
        {
            return;
        }
        if(level != 4)
        {
            this.SpawnPlayer();
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetPos()
    {
        
    }
    public void SpawnPlayer()
    {
        
        if (this.playerInstance != null)
            return;

        Transform startGame = GameObject.Find("StartGame").transform;

         playerInstance = Instantiate(player, startGame.transform.position, Quaternion.identity);
        playerInstance.transform.tag = "Player";
        playerInstance.transform.name = "Player";

    }

  

}
