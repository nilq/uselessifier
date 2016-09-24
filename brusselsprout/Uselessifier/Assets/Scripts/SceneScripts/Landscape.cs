using UnityEngine;
using System.Collections;

public class Landscape : MonoBehaviour {
    

    MeshFilter meshFilter;
    Mesh mesh;

    Vector3[] newVertices;

    int y;

    // Use this for initialization
    void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        mesh = meshFilter.mesh;
        newVertices = mesh.vertices;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3[] vs = mesh.vertices;
        //for (int i = 0; i < mesh.vertexCount; i++)
        //{
        //    v[i] = FileLoader.NextVector3()/255f-Vector3.one*0.5f;
        //}
        for (int i = 0; i < 10; i++)
        {
            y = (y + 1) % mesh.vertexCount;
            Vector3 v = newVertices[y];
            v.y = FileLoader.NextByte() / 100f;
            newVertices[y] = v;
        }

        for (int i = 0; i < vs.Length; i++)
        {
            Vector3 v = vs[i];
            v.y = Mathf.Lerp(v.y,newVertices[i].y,0.2f);
            vs[i] = v;
        }

        mesh.vertices = vs;

        GetComponent<MeshCollider>().sharedMesh = mesh;

        transform.Rotate(0, .2f, 0);
    }
}
