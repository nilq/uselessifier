using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DataLoadMenu : MonoBehaviour {

    public InputField inputURL;

    public AudioClip cancelClip;

    public Canvas ourCanvas;
    public CanvasGroup giveMeBackMyCanvasGroup;
    public Button selectMeButton;


    public void LoadURL()
    {
        if (inputURL.text!="")
            LoadURL(inputURL.text);
    }

    public void LoadURL(string url)
    {
        FileLoader.LoadURL(url);
    }



    public void LoadFile()
    {
        FileLoader.LoadFileIn(Application.persistentDataPath + "/FEEDME");
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            ourCanvas.gameObject.SetActive(false);
            giveMeBackMyCanvasGroup.interactable = true;
            selectMeButton.Select();
        }
    }
}
