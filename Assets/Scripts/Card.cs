using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public bool checkCardState = true;

    //private Barn barn;

    // private Sprite img;
    // private float weight;
    // private float height;

    // private void OnMouseDown()
    // {
    //     Debug.Log("clicked");

    //     if (transform.parent.gameObject.CompareTag("Mask"))
    //     {
    //         return;
    //     }

    //     barn.AddCard(this);
    // }
    // Start is called before the first frame update
    void Start()
    {
        // img = this.GetComponent<SpriteRenderer>().sprite;
        //barn = BarnManager.sharedInstance.barn;
    }

    // Update is called once per frame
    void Update()
    {
        if (checkCardState)
        {
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<SpriteRenderer>().color = Color.white;

            Collider2D[] objs = Physics2D.OverlapBoxAll((Vector2)transform.position, GetComponent<BoxCollider2D>().size, 0);

            foreach (Collider2D obj in objs)
            {
                if (obj.gameObject.GetComponent<SpriteRenderer>().sortingLayerID > gameObject.GetComponent<SpriteRenderer>().sortingLayerID)
                {
                    GetComponent<BoxCollider2D>().enabled = false;
                    GetComponent<SpriteRenderer>().color = Color.grey;
                }
            }
        }
    }
}
