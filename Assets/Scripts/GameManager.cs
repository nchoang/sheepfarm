using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<GameObject> masks;
    public Board board;

    // Start is called before the first frame update
    void Start()
    {
        masks = BarnManager.sharedInstance.barn.masks;
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckEmptyAllGroup(board))
        {
            Debug.Log("win!");
        }
        else if (CheckFullCondition(masks))
        {
            Debug.Log("Lose");
        }
    }

    //kiem tra cac barn full khong ? 
    public bool CheckFullCondition(List<GameObject> masks)
    {
        if (masks != null)
        {
            int countFull = 0;
            foreach (GameObject mask in masks)
            {
                if (mask.transform.childCount != 0)
                {
                    countFull++;
                }
            }
            if (countFull == masks.Count)
            {
                return true;
            }
            return false;
        }
        else
        {
            Debug.Log("MASK NULL");
        }
        return false;
    }

    //kiem tra cac group empty khong ? 
    public bool CheckEmptyAllGroup(Board board)
    {
        List<GameObject> cardGroups = board.cardGroups;
        int countEmptyGroup = 0;
        foreach(GameObject cardGroup in cardGroups)
        {
            if(cardGroup.transform.childCount == 0)
            {
                countEmptyGroup++;
            }
        }
        if(countEmptyGroup == board.cardGroups.Count)
        {
            return true;
        }
        return false;
    }
}
