using UnityEngine;
using System.Collections;

public class Morse : MonoBehaviour {

    Sinus sinus;

    // Use this for initialization
    void Awake () {
        sinus = GetComponent<Sinus>();
    }
    
    // Update is called once per frame
    void Update ()
    {

        sinus.SetOn(FileLoader.NextBit());
        //sinus.SetOn(true);
    }
}
