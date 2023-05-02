using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Text.RegularExpressions;

public class GameManager : MonoBehaviour
{
    List<GameObject> masks;
    public Board board;

    [HideInInspector]
    bool oldSystem = false;

    [SerializeField] private VideoPlayer winningVideo;
    [SerializeField] private GameObject winningRawImage;
    [SerializeField] private GameObject winningPopup;
    [SerializeField] private GameObject sheepLicking;
    [SerializeField] private GameObject pauseBtn;
    [SerializeField] private GameObject popUp;

    // Start is called before the first frame update
    void Start()
    {
        masks = BarnManager.sharedInstance.barn.masks;
        this.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (this.isActiveAndEnabled)
        {
            if (CheckEmptyAllGroup(board))
            {
                Debug.Log("win!");

                if (SavePlayerSystem.sharedInstance != null)
                    SavePlayerSystem.sharedInstance.SavePlayer(int.Parse(Regex.Match(SceneManager.GetActiveScene().name, @"\d+").Value) + 1);

                StartCoroutine(LoadNextScene());
                this.enabled = false;
            }
            else if (CheckFullCondition(masks))
            {
                Debug.Log("Lose");
                //lose popup
                popUp.SetActive(true);

                if (SavePlayerSystem.sharedInstance != null)
                    SavePlayerSystem.sharedInstance.SavePlayer(int.Parse(Regex.Match(SceneManager.GetActiveScene().name, @"\d+").Value));

                this.enabled = false;
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
                if (mask.transform.childCount > 0)
                {
                   
                    countFull++;
                    Debug.Log(countFull);

                }
                
            }
            if (countFull == masks.Count)
            {
                Dictionary<Sprite, int> sprites = CountSprites();
                if(checkSpriteToDelete(sprites))
                {
                    return false;
                }
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

    private bool checkSpriteToDelete(Dictionary<Sprite, int> sprites)
    {
        List<Sprite> spritesToDelete = new List<Sprite>();

        foreach (var sprite in sprites)
        {
            if (sprite.Value >= 3)
            {
                return true;
            }
        }

        return false;
    }

    //kiem tra cac group empty khong ? 
    public bool CheckEmptyAllGroup(Board board)
    {

        if (board.transform.childCount > 3)
        {
            oldSystem = true;
        }

        if (oldSystem)
        {
            if (board.transform.childCount == 0) return true;
            else return false;
        }
        else
        {
            bool winning = true;
            foreach (Transform child in board.transform)
            {
                if (child.childCount != 0 && child.gameObject.TryGetComponent<Layer>(out Layer temp) == true)
                {
                    winning = false;
                }
            }
            return winning;
        }
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
        sheepLicking.SetActive(false);
        pauseBtn.SetActive(false);

        winningVideo.gameObject.SetActive(true);
        winningRawImage.SetActive(true);
        winningVideo.Play();
        yield return new WaitForSeconds(Convert.ToSingle(winningVideo.length));
        winningRawImage.SetActive(false);
        winningVideo.gameObject.SetActive(false);
        winningVideo.Stop();
        winningPopup.SetActive(true);
        sheepLicking.SetActive(true);

        PauseGame();
    }


}
