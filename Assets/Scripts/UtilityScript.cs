using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class UtilityScript
{

    public static int GetCurrScene()
    {
        var currScene = SceneManager.GetActiveScene().buildIndex;

        return currScene;
    }
   

    public static void ChangeScene(int LevelInput)
    {
        
        SceneManager.LoadSceneAsync(LevelInput);
        

    }


    public static void ExitGame()
    {
        Application.Quit();
    }

    public static void UnloadScene(int currSceneIndex)
    {
        if(currSceneIndex != 0)
        SceneManager.UnloadSceneAsync(currSceneIndex);
    }

}
