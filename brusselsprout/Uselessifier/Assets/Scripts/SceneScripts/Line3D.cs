using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Line3D : MonoBehaviour {

    public int vertices;

    LineRenderer lineRenderer;

    List<Vector3> vs;

    // Use this for initialization
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        
        vs = new List<Vector3>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vs.Count == 0)
        {
            lineRenderer.SetVertexCount(vertices+1);
            for (int i = 0; i < vertices; i++)
            {
                vs.Add(FileLoader.NextVector3().normalized-Vector3.one*0.5f);
            }
        }

        for (int i = 0; i < vertices+1; i++)
        {
            lineRenderer.SetPosition(i, Vector3.Lerp(vs[(i+1) % vertices], vs[i%vertices], (Time.frameCount % 100)/99f));
        }

        if (Time.frameCount % 100 == 0)
        {
            vs.RemoveAt(0);
            vs.Add(FileLoader.NextVector3().normalized - Vector3.one * 0.5f);
        }
    }
}
