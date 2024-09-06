using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager: MonoBehaviour  
{
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

    

    private float _EnemyLives = 1;

    public float EnemyLives
    {
        get { return _EnemyLives; }

        set
        {
            _EnemyLives = value;

            if (_EnemyLives <= 0)
            {
                Debug.LogFormat("Enemy has died. Lives: {0}", _EnemyLives);
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
            }
        }
    }

    private void Unsubscribe()
    {

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
