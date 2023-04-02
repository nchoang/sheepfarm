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
        Vector2 mousePosWorld2D = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        GameObject result = GetHighestRaycastTarget(mousePosWorld2D);

        if (result != null)
            // Do Stuff example:
            Debug.Log($"Highest Layer: {result.GetComponent<SpriteRenderer>().sortingLayerID}");

        if (Input.GetMouseButtonDown(0)
            && result != null)
        {
            if (result.GetComponent<Card>() != null)
            {
                barn.AddCard(result.GetComponent<Card>());
            }
        }
    }

    // Get highest RaycastTarget based on the Sortinglayer
    // Note: If multiple Objects have the same SortingLayer (e.g. 42) and this is also the highest SortingLayer, then the Function will return the last one it found
    private GameObject GetHighestRaycastTarget(Vector2 mousePos)
    {
        GameObject topLayer = null;
        RaycastHit2D[] hit = Physics2D.RaycastAll(mousePos, Vector2.zero);

        foreach (RaycastHit2D ray in hit)
        {
            SpriteRenderer spriteRenderer = ray.transform.GetComponent<SpriteRenderer>();

            // Check if RaycastTarget has a SpriteRenderer and
            // Check if the found SpriteRenderer uses the relevant SortingLayer
            if (spriteRenderer != null)
            {
                if (topLayer == null)
                {
                    topLayer = spriteRenderer.transform.gameObject;
                }

                if (spriteRenderer.sortingLayerID >= topLayer.GetComponent<SpriteRenderer>().sortingLayerID)
                {
                    topLayer = ray.transform.gameObject;
                }
            }

        }
        return topLayer;
    }
}
