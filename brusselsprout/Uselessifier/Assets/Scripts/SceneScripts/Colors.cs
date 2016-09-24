using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Colors : MonoBehaviour {

    Image image;

    // Use this for initialization
    void Awake () {
        image = GetComponent<Image>();
    }
    
    // Update is called once per frame
    void Update ()
    {
        image.color = FileLoader.NextColor();
    }
}
