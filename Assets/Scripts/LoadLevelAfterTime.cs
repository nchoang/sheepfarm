using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelAfterTime : MonoBehaviour
{
    [SerializeField] private float delay = 2;
    [SerializeField] private string sceneNameToLoad;

    private float timeElapsed;

    void Start()
    {
        if (SavePlayerSystem.sharedInstance != null)
            sceneNameToLoad = "Level" + SavePlayerSystem.sharedInstance.currentLevel;
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > delay)
        {
            int buildIndex = SceneUtility.GetBuildIndexByScenePath(sceneNameToLoad);

            if (buildIndex != -1)
            {
                SceneManager.LoadScene(sceneNameToLoad);
            }
            else
            {
                ScenesManager.Instance.LoadNewGame();
            }
        }
    }
}