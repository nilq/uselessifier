using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;
using System.IO;

public class OpenMouth : MonoBehaviour, IPointerClickHandler, ISubmitHandler, ISelectHandler {

    public DataLoadMenu dataLoadMenu;
    public AudioClip onSelectClip;
    public AudioClip onSubmitClip;

    // Use this for initialization
    void Start () {
        
    }

    void OnEnable()
    {
        GetComponent<Button>().Select();
    }
    
    // Update is called once per frame
    void Update () {
    
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Directory.CreateDirectory(Application.persistentDataPath + "/FEEDME");
        System.Diagnostics.Process.Start(Application.persistentDataPath + "/FEEDME");
        dataLoadMenu.LoadFile();
        SfxManager.sfxManager.PlayClip(onSubmitClip, 0.5f);
    }

    public void OnSubmit(BaseEventData eventData)
    {
        Directory.CreateDirectory(Application.persistentDataPath + "/FEEDME");
        System.Diagnostics.Process.Start(Application.persistentDataPath + "/FEEDME");
        dataLoadMenu.LoadFile();
        SfxManager.sfxManager.PlayClip(onSubmitClip, 0.5f);

    }

    public void OnSelect(BaseEventData eventData)
    {
        SfxManager.sfxManager.PlayClip(onSelectClip, 0.5f);
    }
}
