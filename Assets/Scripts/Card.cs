using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public bool checkCardState = true;

    private SpriteRenderer mySpriteRenderer;
    private BoxCollider2D myBoxCollider2D;

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
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myBoxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkCardState)
        {
            myBoxCollider2D.enabled = true;
            mySpriteRenderer.color = Color.white;

            Collider2D[] objs = Physics2D.OverlapBoxAll((Vector2)transform.position, myBoxCollider2D.size, 0);

            foreach (Collider2D obj in objs)
            {
                if (obj.gameObject.GetComponent<SpriteRenderer>().sortingLayerName == mySpriteRenderer.sortingLayerName)
                    if (obj.gameObject.GetComponent<SpriteRenderer>().sortingOrder > mySpriteRenderer.sortingOrder)
                    {
                        myBoxCollider2D.enabled = false;
                        mySpriteRenderer.color = Color.grey;
                    }
            }
        }
        else
        {
            myBoxCollider2D.enabled = false;
        }
    }



}
