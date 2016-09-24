using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class SceneButton : MonoBehaviour, IPointerClickHandler, ISubmitHandler, ISelectHandler, IDeselectHandler {

    Button button;

    public string sceneName;
    public AudioClip selectClip;
    public AudioClip submitClip;
    bool isSelected;

    // Use this for initialization
    void Start () {
        button = GetComponent<Button>();
    }
    
    // Update is called once per frame
    void Update () {
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Submit();
    }

    public void OnSubmit(BaseEventData eventData)
    {
        Submit();
    }

    void Submit()
    {
        if (sceneName == "")
            return;
        SfxManager.sfxManager.PlayClip(submitClip, .5f);
        MySceneManager.instance.LoadScene(sceneName);
    }

    public void OnSelect(BaseEventData eventData)
    {
        SfxManager.sfxManager.PlayClip(selectClip, .5f);
        isSelected = true;
    }

    void OnEnable()
    {
        if (isSelected)
        {
            button.colors = button.colors;
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        isSelected = false;
    }
}
