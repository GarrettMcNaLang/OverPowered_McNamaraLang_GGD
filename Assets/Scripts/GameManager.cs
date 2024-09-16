using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager: MonoBehaviour  
{

    bool Escape;

    bool MoreThanLevel0;

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
            }
        }
    }

   public void NextLevel()
    {
        UtilityScript.ChangeScene(UtilityScript.GetCurrScene() + 1);
        
    }

    public void ResetLevel()
    {
        UtilityScript.ChangeScene(UtilityScript.GetCurrScene());

        Resume();
    }

    public void ReturnToMain()
    {
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
