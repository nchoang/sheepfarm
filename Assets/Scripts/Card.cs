using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private Barn barn;

    // private Sprite img;
    // private float weight;
    // private float height;

    private void OnMouseDown()
    {
        Debug.Log("clicked");

        if (transform.parent.gameObject.CompareTag("Mask"))
        {
            return;
        }

        barn.AddCard(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        // img = this.GetComponent<SpriteRenderer>().sprite;
        barn = BarnManager.sharedInstance.barn;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
