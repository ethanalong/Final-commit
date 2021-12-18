using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneloader : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("South1"))
        { SceneManager.LoadScene(1); }
    }

    public void SceneLoader()
    {
        SceneManager.LoadScene(1);
    }
}