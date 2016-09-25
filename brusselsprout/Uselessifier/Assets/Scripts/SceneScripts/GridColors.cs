using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GridColors : MonoBehaviour {

    public GameObject linePrefab;

    public int maxGrids;

    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update ()
    {
        if (Time.frameCount % 3 != 0)
            return;

        GameObject lineGO = Instantiate(linePrefab);
        lineGO.transform.SetParent(transform, false);
        lineGO.GetComponent<Image>().color = FileLoader.NextColor();

        if (transform.childCount > maxGrids)
        {
            Destroy(transform.GetChild(1).gameObject);
        }
    }
}
