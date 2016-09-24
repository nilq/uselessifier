using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GridColors : MonoBehaviour {

    public GameObject linePrefab;

    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update ()
    {
        GameObject lineGO = Instantiate(linePrefab);
        lineGO.transform.SetParent(transform, false);
        lineGO.GetComponent<Image>().color = FileLoader.NextColor();

        if (transform.childCount > 100)
        {
            Destroy(transform.GetChild(1).gameObject);
        }
    }
}
