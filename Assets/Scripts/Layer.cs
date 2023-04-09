using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using System.IO;
using System.Linq;

public class Layer : MonoBehaviour
{
    [SerializeField] private List<GameObject> cards;
    
    private void Start()
    {
        ReplaceCard();

    }

    //private void CreateCards(int numberOfCards)
    //{
    //    for(int i = 0; i < numberOfCards; i++)
    //    {
    //        Instantiate(cardToInit, this.transform);
    //    }
    //}


  

    private void ReplaceCard()
    {
        Debug.Log(cards.Count);
        List<GameObject> cardsToReplace = GetAllChildCard();
        foreach (GameObject card in cardsToReplace) 
        {
            int randomIndex = Random.Range(0, cards.Count - 1);
            GameObject cardReplace = cards[randomIndex];
            card.GetComponent<SpriteRenderer>().sprite = cardReplace.GetComponent<SpriteRenderer>().sprite; 
        }
    }

    private List<GameObject> GetAllChildCard()
    {
        List<GameObject> cards = new List<GameObject>();
        if (this.transform.childCount > 0)
        {
            for(int i = 0; i < this.transform.childCount; i++)
            {
                Transform card = this.transform.GetChild(i);
                Debug.Log("Get card " + card.name);
                cards.Add(card.gameObject);   
                
            }



        }
        return cards;
    }



    

}
