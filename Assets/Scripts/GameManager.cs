using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    bool Escape;

    private GameObject PlayerSpawn;
      

    public GameObject playerPrefab;

    public static GameManager Instance;

    public GameObject PauseMenuObj;

    public GameObject ResetMenuObj;

    public GameObject MainMenuObj;

    public GameObject LevelCmpltObj;

    public GameObject GameCompleteObj;

    public GameObject DeathScreenObj;

    public Canvas canvasObj;

    public EventSystem eventSystemObj;

    public TextMeshProUGUI playerLivesDisplay;

    public CoroutineManager coroutineManager;
    void Awake()
    {
        if (Instance)
        {
            DestroyImmediate(Instance);
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);

        DontDestroyOnLoad(canvasObj);

        DontDestroyOnLoad(eventSystemObj);

        //DontDestroyOnLoad(coroutineManager);

        SceneManager.sceneLoaded += OnLoaded;


        NextLevel();
        //UtilityScript.AccessMono();
        
    }


    private int _EnemiesInScene;

    public int EnemiesInScene
    {
        get { return _EnemiesInScene; }

        set { _EnemiesInScene = value;

            if (_EnemiesInScene <= 0)
            {
                ResetMenuObj.SetActive(true);
            }
        }
    }

    //the following lines are the values that will be
    private int _PlayerHP = 2;
    public int PlayerHP
    {
        get
        {
            return _PlayerHP;
        }

        set
        {
            _PlayerHP = value;

            playerLivesDisplay.text = "Lives: " + PlayerHP;

            if (_PlayerHP <= 0)
            {

                Debug.LogFormat("Player has Died. Lives {0}", PlayerHP);
                Destroy(GameObject.Find("Player"));
                Time.timeScale = 0f;
                ResetMenuObj.SetActive(false);
                DeathScreenObj.SetActive(true);
            }
        }
    }

    public void NextLevel()
    {
        
        UtilityScript.UnloadScene(UtilityScript.GetCurrScene());

        UtilityScript.ChangeScene(UtilityScript.GetCurrScene() + 1);

        ResetHealth();

        Resume(false);

    }

    public void ResetLevel()
    {
        UtilityScript.ChangeScene(UtilityScript.GetCurrScene());

        ResetHealth();

        Resume(false);
    }

    public void ReturnToMain()
    {
        
        UtilityScript.UnloadScene(UtilityScript.GetCurrScene());

        UtilityScript.ChangeScene(1);

        Resume(true);

        
        //End Subscriptions
        //unload active scene
    }

    public void ExitGame()
    {
        Debug.Log("Exiting Level");
        UtilityScript.ExitGame();
    }

    public void Resume(bool toMain)
    {
        PauseMenuObj.SetActive(false);
        LevelCmpltObj.SetActive(false);
        DeathScreenObj.SetActive(false);
        if (toMain)
        {
            
            ResetMenuObj.SetActive(false);
            GameCompleteObj.SetActive(false);
          
        }
        else
        {
           
            ResetMenuObj.SetActive(true);
        }
        

        Time.timeScale = 1f;
    }

    public void PauseMenu()
    {
        Time.timeScale = 0f;

        ResetMenuObj.SetActive(false);
        PauseMenuObj.SetActive(true);


    }



    // Start is called before the first frame update
    void Start()
    {
        PauseMenuObj.SetActive(false);
        ResetMenuObj.SetActive(false);
        LevelCmpltObj.SetActive(false);
        GameCompleteObj.SetActive(false);
        DeathScreenObj.SetActive(false);

        playerLivesDisplay.text += _PlayerHP;
    }

    void OnLoaded(UnityEngine.SceneManagement.Scene scene, LoadSceneMode loadMode)
    {
        OnLoadLevel();
    }

    void OnLoadLevel()
    {
        if (UtilityScript.GetCurrScene() > 1)
        {
            PlayerSpawn = GameObject.Find("SpawnPoint");


            //if(FindAnyObjectByType<PlayerBehavior>() != null)
                
     

            Instantiate(playerPrefab, PlayerSpawn.transform.position, Quaternion.identity);
        }
    }

    public void LevelComplete()
    {
        Time.timeScale = 0f;
        ResetMenuObj.SetActive(false);
        LevelCmpltObj.SetActive(true);
    }

    public void VictoryScreen()
    {
        Time.timeScale = 0f;

        LevelCmpltObj.SetActive(false);

        ResetMenuObj.SetActive(false);

        GameCompleteObj.SetActive(true);

    }

    private void ResetHealth()
    {
        PlayerHP = 2;
    }

  
    // Update is called once per frame
    void Update()
    {
        Escape = Input.GetKeyDown(KeyCode.Escape);

       if( Escape )
        {
            Debug.Log("User Has pressed pause menu button");
            PauseMenu();
           
        }

       if(UtilityScript.GetCurrScene() > 1) {

            MainMenuObj.SetActive(false);
            
        }
       else
        {
            MainMenuObj.SetActive(true);
        }

    }
}
