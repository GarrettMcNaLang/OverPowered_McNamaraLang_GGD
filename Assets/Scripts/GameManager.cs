using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager: MonoBehaviour  
{

    bool Escape;

    

    public static GameManager Instance;

    void Awake()
    {
        if (Instance)
        {
            DestroyImmediate(Instance);
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
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
    }

    public void ReturnToMain()
    {
        UtilityScript.ChangeScene(0);
        //End Subscriptions
        //unload active scene
    }

    public void ExitGame()
    {
        Debug.Log("Exiting Level");
        UtilityScript.ExitGame();
    }
  

    public void PauseMenu()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Escape = Input.GetKeyDown(KeyCode.Escape);

       if( Escape )
        {
            PauseMenu();
        }

    }
}
