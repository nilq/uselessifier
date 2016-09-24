using UnityEngine;
using System.Collections;

public class Gizmos2 : MonoBehaviour {

    Vector3 next;

    void Update()
    {
        if (Time.frameCount % 10 == 0)
        {
            next = FileLoader.NextVector3() / 255f - Vector3.one * 0.5f;
            //Debug.Log(next);
        }



        transform.up = Vector3.Slerp(transform.up, next, .3f);
    }
}
