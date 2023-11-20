using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }
    static private SceneLoader _instance;
    public void LoadNewScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
    
}
