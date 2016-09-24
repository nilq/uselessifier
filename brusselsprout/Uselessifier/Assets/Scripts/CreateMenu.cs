using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreateMenu : MonoBehaviour {

    public GameObject buttonPrefab;
    public string[] sceneNames;

    bool didSelect = false;

    // Use this for initialization
    void Awake ()
    {
        //Destroy(transform.GetChild(0).gameObject);
        
        for (int i = 0; i < sceneNames.Length; i ++)
        {
            string s = sceneNames[i];
            GameObject buttonGO = Instantiate(buttonPrefab);
            buttonGO.transform.SetParent(transform, false);
            buttonGO.GetComponentInChildren<Text>().text = i.ToString("00") + "-" + s;
            buttonGO.GetComponent<SceneButton>().sceneName = s;
        }
    }
    
    // Update is called once per frame
    void Update () {
        if (!didSelect)
        {
            GetComponentInChildren<Button>().Select();
            didSelect = true;
        }
    }
}
