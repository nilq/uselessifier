using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MySceneManager : MonoBehaviour {

    public static MySceneManager instance;

    public GameObject menuCanvas;
    public CanvasGroup menuCanvasGroup;
    public AudioClip cancelClip;

    string currentScene=null;

    // Use this for initialization
    void Awake ()
    { 
        instance = this;
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel") && currentScene!=null)
        {
            UnloadScene();
            //menuCanvas.SetActive(true);
            menuCanvasGroup.alpha = 1;
            menuCanvasGroup.interactable = true;
            menuCanvasGroup.blocksRaycasts = true;
            SfxManager.sfxManager.PlayClip(cancelClip, 0.5f);
        }
    }
    
    public void LoadScene(string name)
    {
        if (currentScene != null)
            return;

        currentScene = name;
        SceneManager.LoadScene(name,LoadSceneMode.Additive);
        //menuCanvas.SetActive(false);
        menuCanvasGroup.alpha = 0;
        menuCanvasGroup.interactable = false;
        menuCanvasGroup.blocksRaycasts = false;
    }

    public void UnloadScene()
    {
        if (currentScene!=null)
        {
            SceneManager.UnloadScene(currentScene);
            currentScene = null;
        }
    }
}
