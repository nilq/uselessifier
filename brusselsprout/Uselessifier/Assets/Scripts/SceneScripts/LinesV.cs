using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LinesV : MonoBehaviour {

    public GameObject linePrefab;

    public int maxLines;

    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update ()
    {
        GameObject lineGO = Instantiate(linePrefab);
        lineGO.transform.SetParent(transform, false);
        lineGO.GetComponent<Image>().color = FileLoader.NextColor();

        if (transform.childCount > maxLines)
        {
            Destroy(transform.GetChild(1).gameObject);
        }
    }
}
