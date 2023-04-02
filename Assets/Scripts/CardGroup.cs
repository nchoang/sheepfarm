using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGroup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Transform[] childs = gameObject.GetComponentsInChildren<Transform>();

        if (childs.Length != 1)
        {
            childs[1].gameObject.GetComponent<BoxCollider2D>().enabled = true;
            for (int i = 2; i < childs.Length; i++)
            {
                childs[i].gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }

    }
}
