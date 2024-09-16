using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    bool Escape;

    private GameObject PlayerSpawn;

    private GameObject playerPrefab;

    public static GameManager Instance;

    public GameObject PauseMenuObj;

    public GameObject ResetMenuObj;

    public GameObject MainMenuObj;

    public Canvas canvasObj;

    public EventSystem eventSystemObj;

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

            if (_PlayerHP <= 0)
            {

                Debug.LogFormat("Player has Died. Lives {0}", PlayerHP);
                Destroy(GameObject.Find("Player"));
                Time.timeScale = 0f;
                ResetMenuObj.SetActive(true);
            }
        }
    }

    public void NextLevel()
    {
        UtilityScript.UnloadScene(UtilityScript.GetCurrScene());

        UtilityScript.ChangeScene(UtilityScript.GetCurrScene() + 1);



    }

    public void ResetLevel()
    {
        UtilityScript.ChangeScene(UtilityScript.GetCurrScene());

        Resume();
    }

    public void ReturnToMain()
    {
        UtilityScript.UnloadScene(UtilityScript.GetCurrScene());

        UtilityScript.ChangeScene(0);

        Resume();
        //End Subscriptions
        //unload active scene
    }

    public void ExitGame()
    {
        Debug.Log("Exiting Level");
        UtilityScript.ExitGame();
    }

    public void Resume()
    {
        PauseMenuObj.SetActive(false);

        Time.timeScale = 1f;
    }

    public void PauseMenu()
    {
        Time.timeScale = 0f;

        PauseMenuObj.SetActive(true);


    }



    // Start is called before the first frame update
    void Start()
    {
        PauseMenuObj.SetActive(false);
        ResetMenuObj.SetActive(false);


    }

    private void PlayerSpawner()
    {
        
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

       if(UtilityScript.GetCurrScene() > 0) {

            MainMenuObj.SetActive(false);
        }

    }
}
