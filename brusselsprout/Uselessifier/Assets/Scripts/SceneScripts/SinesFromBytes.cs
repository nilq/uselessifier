using UnityEngine;
using System.Collections;

public class SinesFromBytes : MonoBehaviour {

    public int waitFrames=1;

    Sinus sinus;

    // Use this for initialization
    void Awake()
    {
        sinus = GetComponent<Sinus>();
        sinus.SetOn(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % waitFrames != 0)
            return;
        sinus.frequency = 220+FileLoader.NextByte();
        
    }
}
