using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [HideInInspector]
    public bool checkCardState = true;
    [HideInInspector]
    public bool clickable = true;

    private SpriteRenderer mySpriteRenderer;
    private BoxCollider2D myBoxCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myBoxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkCardState)
        {
            clickable = true;
            mySpriteRenderer.color = Color.white;

            Collider2D[] objs = Physics2D.OverlapBoxAll((Vector2)transform.position, myBoxCollider2D.size, 0);

            foreach (Collider2D obj in objs)
            {
                if (obj.gameObject.GetComponent<SpriteRenderer>().sortingLayerName == mySpriteRenderer.sortingLayerName)
                    if (obj.gameObject.GetComponent<SpriteRenderer>().sortingOrder > mySpriteRenderer.sortingOrder)
                    {
                        clickable = false;
                        mySpriteRenderer.color = Color.grey;
                    }
            }
        }
        else
        {
            clickable = false;
            mySpriteRenderer.color = Color.white;
        }
    }



}
