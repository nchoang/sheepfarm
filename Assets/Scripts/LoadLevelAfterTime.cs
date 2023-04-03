using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelAfterTime : MonoBehaviour
{
    [SerializeField] private float delay = 2;
    [SerializeField] private string sceneNameToLoad;

    private float timeElapsed;

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > delay)
        {
            SceneManager.LoadScene(sceneNameToLoad);
        }
    }
}