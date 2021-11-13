using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Slider LoadingBar;
    public Text LoadingText;
    public static bool LoadStatus;

    public void Loadlevel(int sceneIndex)
    {
        LoadingScreen.SetActive(true);
        StartCoroutine(LoadAsync(sceneIndex));
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (operation.isDone)
        {
            int progress = (int)Mathf.Clamp01(operation.progress / .9f);

            LoadingBar.value = progress;
            LoadingText.text = progress * 100 + "%";

            yield return null;
        }
    }
}
