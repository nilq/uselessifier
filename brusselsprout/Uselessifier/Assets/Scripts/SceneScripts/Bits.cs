using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Bits : MonoBehaviour {
    
    public int countPerFrame;
    public int maxCharacters;

    Text text;

    // Use this for initialization
    void Awake ()
    {
        text = GetComponent<Text>();
    }
    
    // Update is called once per frame
    void Update ()
    {
        if (Time.frameCount % 5 != 0)
            return;
        for (int y = 0; y < countPerFrame; y++)
        {
            if (text.text.Length > maxCharacters)
                text.text = text.text.Substring(countPerFrame+1, text.text.Length - 1 - countPerFrame);
            
            text.text += FileLoader.NextBit() ? "1" : "0";

        }

        text.text += "\n";
    }
}
