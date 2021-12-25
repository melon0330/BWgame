using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    public void GoGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void Close()
    {
        Application.Quit();
    }

}
