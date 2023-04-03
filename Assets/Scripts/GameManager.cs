using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    List<GameObject> masks;
    public Board board;


    [SerializeField] private VideoPlayer winningVideo;
    [SerializeField] private GameObject winningRawImage;
    [SerializeField] private GameObject pauseScreen;

   
    

    // Start is called before the first frame update
    void Start()
    {
        masks = BarnManager.sharedInstance.barn.masks;
        this.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.isActiveAndEnabled)
        {
            if (CheckEmptyAllGroup(board))
            {
                Debug.Log("win!");
                StartCoroutine(LoadNextScene());
                this.enabled = false;
            }
            else if (CheckFullCondition(masks))
            {
                Debug.Log("Lose");
            }
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
        //List<GameObject> cardGroups = board.cardGroups;
        if (board.transform.childCount == 0) return true;
        else return false;
        // int countEmptyGroup = 0;
        // foreach (GameObject cardGroup in cardGroups)
        // {
        //     if (cardGroup.transform.childCount == 0)
        //     {
        //         countEmptyGroup++;
        //     }
        // }
        // if (countEmptyGroup == board.cardGroups.Count)
        // {
        //     return true;
        // }
        // return false;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    IEnumerator LoadNextScene()
    {
        winningVideo.gameObject.SetActive(true);
        winningRawImage.SetActive(true);
        winningVideo.Play();
        yield return new WaitForSeconds(Convert.ToSingle(winningVideo.length));
        winningRawImage.SetActive(false);
        winningVideo.gameObject.SetActive(false);
        winningVideo.Stop();
        pauseScreen.SetActive(true);

    }


}
