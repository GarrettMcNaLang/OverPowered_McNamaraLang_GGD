using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class UtilityScript
{
    private static CoroutineManager instance;
    
    public static void AccessMono()
    {
        
            instance = GameObject.Find("MonoReference").AddComponent<CoroutineManager>();

        if (instance == null)
            Debug.Log("MonoBehavior instance empty");
        
    }

    public static int GetCurrScene()
    {
        var currScene = SceneManager.GetActiveScene().buildIndex;

        return currScene;
    }
   

    public static void ChangeScene(int LevelInput)
    {
        

        instance.StartCoroutine(LoadOp(LevelInput));
        

    }


    public static void ExitGame()
    {
        Application.Quit();
    }

    public static void UnloadScene(int currSceneIndex)
    {
        if(currSceneIndex != 0)
        instance.StartCoroutine(UnloadOp(currSceneIndex));
        
       
    }

    static IEnumerator UnloadOp(int currSceneIndex)
    {
        yield return null;

        if(currSceneIndex != 0)
        {
            AsyncOperation asyncOp = SceneManager.UnloadSceneAsync(currSceneIndex);

            asyncOp.allowSceneActivation = false;

            while (!asyncOp.isDone)
            {

                Debug.Log(asyncOp.progress * 100);
            }


            asyncOp.allowSceneActivation = true;

        }



    }

   static IEnumerator LoadOp(int currSceneIndex)
    {
        yield return null;

        AsyncOperation asyncOp = SceneManager.LoadSceneAsync(currSceneIndex);

        asyncOp.allowSceneActivation = false;

        while (!asyncOp.isDone)
        {

            Debug.Log(asyncOp.progress * 100);
        }

        asyncOp.allowSceneActivation = true;
    }

}
