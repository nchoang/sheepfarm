using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerManager : MonoBehaviour
{
    [SerializeField] private Board board;


    void Start()
    {  
        SetLayerOrder();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetLayerOrder()
    {
        if (board.transform.childCount != 0)
        {

            for (int i = 0; i < board.layers.Count; i++)
            {
                Layer layer = board.transform.GetChild(i).gameObject.GetComponent<Layer>();
                
                for(int j = 0; j < layer.transform.childCount; j++)
                {
                    
                    Card card = layer.transform.GetChild(j).GetComponent<Card>();    
                    card.GetComponent<SpriteRenderer>().sortingOrder = i;
                    

                }
                

            }
        }
       
    }

}
