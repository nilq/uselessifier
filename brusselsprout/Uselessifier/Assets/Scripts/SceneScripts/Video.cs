using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Video : MonoBehaviour {

    public bool bw;

    Texture2D tex;

    RawImage rawImage;
    Color[] colors;

    // Use this for initialization
    void Awake () {
        rawImage = GetComponent<RawImage>();
        tex = new Texture2D(80, 72,TextureFormat.RGBAFloat,false);
        colors = tex.GetPixels();
        rawImage.texture = tex;
        tex.filterMode = FilterMode.Point;
    }
    
    // Update is called once per frame
    void Update ()
    {
        float b;
        if (bw)
        {
            for (int i = 0; i < colors.Length; i++)
            {
                b = System.Convert.ToInt32( FileLoader.NextBit());
                colors[i] = new Color(b,b,b);
            }
        }
        else
        {
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = FileLoader.NextColor();
            }
        }

        tex.SetPixels(colors);
        tex.Apply();
    }
}
