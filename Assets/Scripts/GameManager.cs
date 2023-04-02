using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<GameObject> masks;
    public Board board;
<<<<<<< Updated upstream
=======
    

    [SerializeField] private VideoPlayer winningVideo;
    [SerializeField] private GameObject winningRawImage;
    [SerializeField] private GameObject pauseScreen;

>>>>>>> Stashed changes

    // Start is called before the first frame update
    void Start()
    {
        masks = BarnManager.sharedInstance.barn.masks;
<<<<<<< Updated upstream
=======
        

>>>>>>> Stashed changes
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

    public void PauseGame()
    {
<<<<<<< Updated upstream
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
=======
        winningVideo.gameObject.SetActive(true);
        winningRawImage.SetActive(true);
        winningVideo.Play();
        yield return new WaitForSeconds(Convert.ToSingle(winningVideo.length));
        //SceneManager.LoadScene("MainMenu");
        pauseScreen.SetActive(true);
        
>>>>>>> Stashed changes
    }

}
