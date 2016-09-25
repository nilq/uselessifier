using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayURLLoad : MonoBehaviour {

    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
    }
    
    // Update is called once per frame
    void Update ()
    {
        if (FileLoader.isLoadingURL)
        {
            text.text = Time.frameCount%3==0?".":"";
        }
        else if (!FileLoader.URLLoadSuccess)
        {
            text.text = "X";
        }
        else
        {
            text.text = "";
        }
    }
}
