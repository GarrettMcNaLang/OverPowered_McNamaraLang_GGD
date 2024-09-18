using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteScript : MonoBehaviour
{
    private GameManager GMObj;

    public bool isFinalExit;
    void OnEnable()
    {
        GMObj = GameObject.Find("GM").GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            GMObj.LevelComplete();
        }

        if (isFinalExit)
        {
            DestroyImmediate(collision.gameObject);
            GMObj.VictoryScreen();
        }
    }
}
