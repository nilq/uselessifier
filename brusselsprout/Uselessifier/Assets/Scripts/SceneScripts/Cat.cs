using UnityEngine;
using System.Collections;

public class Cat : MonoBehaviour {

    Sprite[] sprites;
    SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start () {
        sprites = Resources.LoadAll<Sprite>("Cat");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    // Update is called once per frame
    void Update () {
        if (Time.frameCount%5==0)
            spriteRenderer.sprite = sprites[FileLoader.NextByte()%sprites.Length];
    }
}
