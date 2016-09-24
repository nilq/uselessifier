using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class SceneButton : MonoBehaviour, IPointerClickHandler, ISubmitHandler {
    
    public string sceneName;

    // Use this for initialization
    void Start () {
    
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
        MySceneManager.instance.LoadScene(sceneName);
    }
}
