using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Layer : MonoBehaviour
{
    public List<Card> cards;

    private void Update()
    {
       
    }

    private void Start()
    {
      
        foreach (Card card in cards) 
        { 
            Instantiate(card, this.gameObject.transform, true);
        }
        

    }

    

}
