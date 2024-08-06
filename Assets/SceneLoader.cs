using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void LoadScene(int Scene) {
        SceneManager.LoadScene(Scene);
    }

    public void LoadScene(string Scene) {
        SceneManager.LoadScene(Scene);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
