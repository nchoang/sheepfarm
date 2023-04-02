using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarnManager : MonoBehaviour
{
    public static BarnManager sharedInstance = null;

    public Barn barn;

    void Awake()
    {
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

    }

    // Update is called once per frame
    void Update()
    {

    }
}
