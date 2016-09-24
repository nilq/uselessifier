using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Test : MonoBehaviour {

    public Text text;
    public int countPerFrame;
    public Image image;

    byte[] b;
    BitArray bits;
    int i = 0;

    // Use this for initialization
    void Start () {
        b = FileLoader.LoadAndGetFile("C:\\Users\\Stalhandske\\Dropbox\\Documents\\THIS IS NOT A FAX.pdf");
        //b = FileLoader.LoadFile(@"C:\Users\Stalhandske\Dropbox\Pictures\useless.jpg");
        
         bits = new BitArray(b);
    }
    
    // Update is called once per frame
    void Update ()
    {
        for (int y = 0; y < countPerFrame; y++)
        {
            //text.text = ""+b[i];
            if (text.text.Length > 5000)
                text.text = text.text.Substring(countPerFrame, text.text.Length - 1 - countPerFrame);

            if (b[i] < 32 && b[i]!=10)
                y--;
            else
                text.text += "" + (char)b[i];

            //image.color = new Color(b[i]/255f, b[i + 1] / 255f, b[i + 2] / 255f, 1);
            //Debug.Log((char)b[i]);

            //text.text += bits.Get(i) ? "1" : "0";
            i = (i + 1)%b.Length ;
            //i = (i + 3) % b.Length;
            //i = (i + 1) % bits.Length;

        }
    }
}
