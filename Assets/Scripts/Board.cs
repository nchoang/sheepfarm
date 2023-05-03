using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Board : MonoBehaviour
{
    public List<Layer> layers;
    [SerializeField] private List<GameObject> cards;
    private List<int> indices;
    private int[] frequencies;
    private int[] cardReplaceFreq;

    


    private void Start()
    {
        frequencies = new int[cards.Count];
        
        while(FindSumFreq(frequencies) != GetNumOfCardInBoard())
        {
            frequencies = RandomFrequency(frequencies);
        }
        

        foreach(int i in frequencies)
        {
            Debug.Log(i);
        }
     
        indices = FindIndexWithSum(frequencies, GetNumOfCardInBoard());
       
        cardReplaceFreq = new int[cards.Count];

        for (int i = 0; i < layers.Count; i++)
        {
            Layer layer = layers[i];
            ReplaceCard(layer, frequencies, indices, cardReplaceFreq);
            
        }
        
        
    }

    private void Update()
    {
        foreach(Layer layer in layers)
        {
            if(layer.gameObject.transform.childCount == 0)
            {
                Destroy(layer.gameObject);
                layers.Remove(layer);
            }
        }
    }

    private void ReplaceCard(Layer layer1, int[] frequencies1, List<int> indices1, int[] cardReplaceFreq1)
    {
        Layer layer = layer1;
        int[] frequencies = frequencies1;
        List<int> indices = indices1;
        int[] cardReplaceFreq = cardReplaceFreq1;

        

        List<GameObject> cardsToReplace = GetAllChildCard(layer);
        for(int i = 0; i < cardsToReplace.Count; i++)
        {
           
            bool foundReplacement = false;
            GameObject card = cardsToReplace[i];
            int randomIndex;
            Debug.Log(indices.Count);
            Debug.Log(foundReplacement);
            while (!foundReplacement && indices.Count > 0)
            {
                Debug.Log("Done");
               
                randomIndex = UnityEngine.Random.Range(indices.Min(), indices.Max() + 1);
                
                if (cardReplaceFreq[randomIndex] < frequencies[randomIndex])
                {
                    
                    GameObject cardReplace = cards[randomIndex];
                    cardReplaceFreq[randomIndex] += 1;
                    card.GetComponent<SpriteRenderer>().sprite = cardReplace.GetComponent<SpriteRenderer>().sprite;
                    foundReplacement = true;
                    
                }

                else
                {
                    indices.Remove(randomIndex);
                   
                }
            }
            
            

        }
       
        
    }
    private List<GameObject> GetAllChildCard(Layer layer)
    {
        List<GameObject> cards = new List<GameObject>();
        if (layer.transform.childCount > 0)
        {
            for (int i = 0; i < layer.transform.childCount; i++)
            {
                Transform card = layer.transform.GetChild(i);
                //Debug.Log("Get card " + card.name);
                cards.Add(card.gameObject);

            }



        }
        return cards;
    }

    private int GetNumOfCardInBoard()
    {
        int totalNumOfCards = 0;
        foreach(Layer layer in layers)
        {
            totalNumOfCards += layer.GetCountChild();
        }

        //Debug.Log(totalNumOfCards);
        return totalNumOfCards;
    }

    private int[] RandomFrequency(int[] frequencies)
    {
        int[] newFreq = frequencies;
        for(int i = 0; i < newFreq.Length; i++)
        {
            do
            {
                newFreq[i] = UnityEngine.Random.Range(3, 7);
            }
            while (newFreq[i] % 3 != 0);
            
        }
       
        return newFreq;
    }

  

    private List<int> FindIndexWithSum(int[] frequencies, int sum)
    {
        Debug.Log(sum);
        List<int> ans = new List<int>();
        if (sum % 3 == 0)
        {
            int sum_tmp = 0;
            int left = 0;
            for (int right = 0; right < frequencies.Length; right++)
            {
                sum_tmp += frequencies[right];
                Debug.Log(sum_tmp);
                while (sum_tmp > sum)
                {
                    sum_tmp -= frequencies[left];
                    Debug.Log(sum_tmp);
                    left++;
                }
                
                if (sum_tmp == sum)
                {
                    Debug.Log(sum_tmp);
                    for (int i = left; i <= right; i++)
                    {
                        ans.Add(i);
                    }
                    break;

                }
                




            }
           
        }
        return ans;
    }

    private int FindSumFreq(int[] frequencies)
    {
        int sum = 0;
        foreach(int freq in frequencies)
        {
            sum += freq;    
        }
        return sum;
    }

   

    


}
