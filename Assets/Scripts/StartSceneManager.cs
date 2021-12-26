using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    public void GoGameScene()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void Close()
    {
        Application.Quit();
    }

}
