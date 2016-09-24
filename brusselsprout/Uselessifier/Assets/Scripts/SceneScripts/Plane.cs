using UnityEngine;
using System.Collections;

public class Plane : MonoBehaviour {

    MeshFilter meshFilter;
    Mesh mesh;

    int y;

    // Use this for initialization
    void Awake ()
    {
        meshFilter = GetComponent<MeshFilter>();
        mesh = meshFilter.mesh;
    }
    
    // Update is called once per frame
    void Update ()
    {
        Vector3[] v = mesh.vertices;
        //for (int i = 0; i < mesh.vertexCount; i++)
        //{
        //    v[i] = FileLoader.NextVector3()/255f-Vector3.one*0.5f;
        //}

        y = (y + 1) % mesh.vertexCount;
        v[y] = FileLoader.NextVector3() / 255f - Vector3.one * 0.5f;
        mesh.vertices = v;

        transform.Rotate(0, 1, 0);
    }
}
