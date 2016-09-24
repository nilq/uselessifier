using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GangstaLoremIpsum : MonoBehaviour {

    public string loremIpsum;
    public int countPerFrame;
    public int maxCharacters;

    string[] words;
    Text text;

    // Use this for initialization
    void Awake () {
        words = loremIpsum.Split(' ');
        text = GetComponent<Text>();
    }
    
    // Update is called once per frame
    void Update ()
    {
        for (int y = 0; y < countPerFrame; y++)
        {
            if (text.text.Length > maxCharacters)
                text.text = text.text.Substring(text.text.IndexOf(' ')+1, text.text.Length - text.text.IndexOf(' ')-1);
            
            
            text.text += words[FileLoader.NextByte()%words.Length]+" ";


        }
    }
}
