using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class MyMenuScroller : MonoBehaviour {

    ScrollRect scrollRect;

    // Use this for initialization
    void Awake () {
        scrollRect = GetComponent<ScrollRect>();
    }
    
    // Update is called once per frame
    void Update ()
    {
        if (Time.timeSinceLevelLoad>0.1f)
            scrollRect.verticalNormalizedPosition = 1 + EventSystem.current.currentSelectedGameObject.GetComponent<RectTransform>().anchoredPosition.y/transform.GetChild(0).GetComponent<RectTransform>().rect.height;
    }
}
