using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarnManager : MonoBehaviour
{
    public static BarnManager sharedInstance = null;

    public string LayerNameToCheck = "LayerCard";

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
        foreach (Touch touch in Input.touches)
        {
            Vector2 mousePosWorld2D = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0));

            GameObject result = GetHighestRaycastTarget(mousePosWorld2D, LayerNameToCheck);

            if (result != null)
                // Do Stuff example:
                Debug.Log($"Highest Layer: {result.GetComponent<SpriteRenderer>().sortingLayerName}, Order: {result.GetComponent<SpriteRenderer>().sortingOrder}");

            if (touch.phase == TouchPhase.Began
                && result != null)
            {
                if (result.GetComponent<Card>() != null)
                {
                    if (result.GetComponent<Card>().clickable)
                        barn.AddCard(result.GetComponent<Card>());
                }
            }
        }
    }

    // Get highest RaycastTarget based on the Sortinglayer
    // Note: If multiple Objects have the same SortingLayer (e.g. 42) and this is also the highest SortingLayer, then the Function will return the last one it found
    private GameObject GetHighestRaycastTarget(Vector2 mousePos, string LayerNameToCheck)
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
                if (spriteRenderer.sortingLayerName == LayerNameToCheck)
                {
                    if (topLayer == null)
                    {
                        topLayer = spriteRenderer.transform.gameObject;
                    }

                    if (spriteRenderer.sortingOrder >= topLayer.GetComponent<SpriteRenderer>().sortingOrder)
                    {
                        topLayer = ray.transform.gameObject;
                    }
                }
            }

        }
        return topLayer;
    }
}
