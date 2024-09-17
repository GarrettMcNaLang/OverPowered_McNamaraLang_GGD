using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitDeath : MonoBehaviour
{
    
    private GameManager GMObj;
    void OnEnable()
    {
        GMObj = GameObject.Find("GM").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            GMObj.PlayerHP = 0;
        }
    }
}
