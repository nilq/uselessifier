using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ascii : MonoBehaviour {
    
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
            
            char c = (char)FileLoader.NextByte();
            if (c < 32 && c != 10)
                y--;
            else
                text.text += c;


        }

        text.text += "\n";
    }
}
