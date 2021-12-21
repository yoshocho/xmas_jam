using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeSceneManager : MonoBehaviour
{
    [SerializeField] Image fadePanel = default;

    public void FadeScene(string sceneName, float fadeTime = 0.5f)
    {
        StartCoroutine(FadeSceneAsync(sceneName,fadeTime));
    }
    
    IEnumerator FadeSceneAsync(string sceneName, float fadeTime = 0.5f)
    {
        float timer = 0f;
        Color panelColor = fadePanel.color;
        float alpha = 0f;
        while (timer < fadeTime)
        {
            timer += Time.deltaTime;
            alpha += Time.deltaTime;
            panelColor.a = alpha;
            fadePanel.color = panelColor;
            yield return null;
        }
        if (sceneName.Length < 0)
        {
            SceneManager.LoadSceneAsync(sceneName);
        }
        else
        {
            Debug.LogWarning("指定されたsceneがありません");
        }
    }
}
