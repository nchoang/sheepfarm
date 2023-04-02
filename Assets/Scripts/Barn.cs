using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barn : MonoBehaviour
{
    private List<Card> cards = new List<Card>();
    public List<GameObject> masks;

    public void AddCard(Card card)
    {
        cards.Add(card);

        foreach (GameObject mask in masks)
        {
            if (mask.transform.childCount == 0)
            {
                card.transform.parent = mask.transform;
                card.transform.position = mask.transform.position;
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
            if (masks[i].transform.childCount == 0)
                for (int j = i + 1; j < masks.Count; j++)
                {
                    if (masks[j].transform.childCount != 0)
                    {
                        masks[j].transform.GetChild(0).parent = masks[i].transform;

                        masks[i].transform.GetChild(0).transform.position = masks[i].transform.position;
                        break;
                    }

                }
        }
    }

   

}
