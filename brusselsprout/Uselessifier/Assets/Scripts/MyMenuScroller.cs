using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class MyMenuScroller : MonoBehaviour {
    

    // Use this for initialization
    void Awake () {
    }
    
    // Update is called once per frame
    void Update ()
    {
        Vector3 pos =         transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition;
        pos.y = 16*EventSystem.current.currentSelectedGameObject.transform.GetSiblingIndex() - 5*16;
        pos.y = Mathf.Clamp(pos.y, 0, EventSystem.current.currentSelectedGameObject.transform.parent.childCount * 16-16*9);
        transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = pos;
    }
}
