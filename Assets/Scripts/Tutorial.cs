using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    void Update()
    {
        foreach(Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began)
            {
                gameObject.SetActive(false);
                BarnManager.sharedInstance.CheckCard = true;
            }
        }
        
    }
}
