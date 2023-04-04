using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayerSystem : MonoBehaviour
{

    public static SavePlayerSystem sharedInstance = null;

    public int currentLevel;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

        if (sharedInstance != null && sharedInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            sharedInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadPlayer();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadPlayer()
    {
        if (SaveSystem.LoadPlayer() != null)
        {
            currentLevel = SaveSystem.LoadPlayer().level;
        }
    }

    public void SavePlayer(int level)
    {
        currentLevel = level;
        SaveSystem.SavePlayer(currentLevel);
    }
}
