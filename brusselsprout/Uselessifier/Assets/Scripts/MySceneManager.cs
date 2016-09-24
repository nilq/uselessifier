using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MySceneManager : MonoBehaviour {

    public static MySceneManager instance;

    public GameObject menuCanvas;

    string currentScene;

    // Use this for initialization
    void Awake ()
    { 
        instance = this;
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            UnloadScene();
            menuCanvas.SetActive(true);
        }
    }
    
    public void LoadScene(string name)
    {
        currentScene = name;
        SceneManager.LoadScene(name,LoadSceneMode.Additive);
        menuCanvas.SetActive(false);
    }

    public void UnloadScene()
    {
        if (currentScene!="")
        {
            SceneManager.UnloadScene(currentScene);
            currentScene = "";
        }
    }
}
