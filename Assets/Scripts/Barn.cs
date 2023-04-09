using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Barn : MonoBehaviour
{
    [SerializeField] private float restackCardSpeed = 10.0f;
    private List<Card> cards = new List<Card>();
    public List<GameObject> masks;

    public void AddCard(Card card)
    {
        cards.Add(card);

        foreach (GameObject mask in masks)
        {
            if (mask.transform.childCount == 0)
            {
                card.checkCardState = false;
                StartCoroutine(MoveCard(card, mask, restackCardSpeed));
                card.transform.parent = mask.transform;
                //card.transform.position = mask.transform.position;
                Debug.Log("coroutine add done");
                Debug.Log("added to barn");
                return;
            }
        }

        Debug.Log("added to barn failed");
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Dictionary<Sprite, int> sprites = CountSprites();

        List<Sprite> spritesToDelete = checkSpriteToDelete(sprites);

        DeleteCards(spritesToDelete);

        RestackCards();
    }

    private Dictionary<Sprite, int> CountSprites()
    {
        Dictionary<Sprite, int> sprites = new Dictionary<Sprite, int>();

        foreach (GameObject mask in masks)
        {
            if (mask.transform.childCount != 0)
            {
                Sprite sprite = mask.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
                if (sprites.ContainsKey(sprite))
                    sprites[sprite] = sprites[sprite] + 1;
                else
                    sprites.Add(sprite, 1);
            }
        }

        return sprites;
    }

    private List<Sprite> checkSpriteToDelete(Dictionary<Sprite, int> sprites)
    {
        List<Sprite> spritesToDelete = new List<Sprite>();

        foreach (var sprite in sprites)
        {
            if (sprite.Value >= 3)
            {
                spritesToDelete.Add(sprite.Key);
            }
        }

        return spritesToDelete;
    }

    private void DeleteCards(List<Sprite> spritesToDelete)
    {
        foreach (Sprite sprite in spritesToDelete)
        {
            int toDelete = 3;
            foreach (GameObject mask in masks)
            {
                if (mask.transform.childCount != 0)
                {
                    Sprite spriteOfMask = mask.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;

                    if (sprite == spriteOfMask)
                    {
                        Destroy(mask.transform.GetChild(0).gameObject);
                        toDelete--;
                    }
                }
            }
        }
    }

    private void RestackCards()
    {

        for (int i = 0; i < masks.Count; i++)
        {
            //Find empty slot mask
            if (masks[i].transform.childCount == 0)
            {
                for (int j = i + 1; j < masks.Count; j++)
                {
                    //Find unempty slot mask
                    if (masks[j].transform.childCount != 0)
                    {


                        //Select card in mask 
                        Card card = GetCardInMask(masks[j]);

                        //Move card to empty slot mask
                        StartCoroutine(MoveCard(card, masks[i], restackCardSpeed));
                        card.transform.parent = masks[i].transform;


                        break;
                    }

                }
            }

        }
    }

    private Card GetCardInMask(GameObject mask)
    {
        return mask.transform.GetChild(0).gameObject.GetComponent<Card>();
    }

    private IEnumerator MoveCard(Card card, GameObject mask, float speed)
    {
        float elapsedTime = 0.0f;

        while (elapsedTime < speed && card != null)
        {
            Vector3 moveDir = mask.transform.position;
            card.transform.position = Vector3.Lerp(card.transform.position, moveDir, elapsedTime / speed);
            Debug.Log(Time.deltaTime);
            elapsedTime += 0.016f;
            yield return null;

        }

    }









}
