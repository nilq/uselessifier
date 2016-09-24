using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class LoadDataButton : MonoBehaviour, IPointerClickHandler, ISubmitHandler, ISelectHandler{

    public DataLoadMenu dataLoadMenu;
    public string url;
    public AudioClip onSelectClip;
    public AudioClip onSubmitClip;

    public void OnPointerClick(PointerEventData eventData)
    {
        dataLoadMenu.LoadURL(url);
        SfxManager.sfxManager.PlayClip(onSubmitClip, 0.5f);
    }

    public void OnSelect(BaseEventData eventData)
    {
        SfxManager.sfxManager.PlayClip(onSelectClip, 0.5f);
    }

    public void OnSubmit(BaseEventData eventData)
    {
        dataLoadMenu.LoadURL(url);
        SfxManager.sfxManager.PlayClip(onSubmitClip, 0.5f);
    }
}
