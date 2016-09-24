using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Bytes : MonoBehaviour {
    
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
        for (int y = 0; y < countPerFrame; y++)
        {
            if (text.text.Length > maxCharacters)
                text.text = text.text.Substring(countPerFrame*4+1, text.text.Length - 1 - countPerFrame*4);
            
            text.text += FileLoader.NextByte().ToString("000")+" ";

        }

        text.text += "\n";
    }
}
