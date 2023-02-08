using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public Slider progressbar;
    
    public static string scenePath = null;

    public static void LoadScene(string sceneName)
    {
        scenePath = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    private void Start()
    {
        Time.timeScale = 1;
        Cursor.visible = true;
        StartCoroutine(LoadSceneStart());
     
    }
    IEnumerator LoadSceneStart()
    {
        if (string.IsNullOrEmpty(scenePath)) yield break;

        AsyncOperation operation = SceneManager.LoadSceneAsync(scenePath);
                                                                          
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            if (progressbar.value < 1f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 1f, Time.deltaTime);
            }
            if (progressbar.value > 0.9f && operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }
            yield return null;
        }
        scenePath = null;
    }

}
