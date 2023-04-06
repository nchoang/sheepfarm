using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadLevel(int level)
    {
        SavePlayerSystem.sharedInstance.currentLevel = level;
        SceneManager.LoadScene("Loading");
    }
}