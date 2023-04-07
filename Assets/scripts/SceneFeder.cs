using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFeder : MonoBehaviour
{
    public Image _image;
    public AnimationCurve _curve;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }

    public void FadeTo(int sceneIndex)
    {
        StartCoroutine(FadeOut(sceneIndex));
    }

    private IEnumerator FadeIn()
    {
        float time = 1f;
        while(time > 0f)
        {
            time -= Time.deltaTime;
            float alphaChColor = _curve.Evaluate(time);
            _image.color = new Color(0f, 0f, 0f, alphaChColor);
            yield return 0;
        }
    }

    private IEnumerator FadeOut(string sceneName)
    {
        float time = 0f;
        while (time < 1f)
        {
            time += Time.deltaTime;
            float alphaChColor = _curve.Evaluate(time);
            _image.color = new Color(0f, 0f, 0f, alphaChColor);
            yield return 0;
        }

        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator FadeOut(int sceneIndex)
    {
        float time = 0f;
        while (time < 1f)
        {
            time += Time.deltaTime;
            float alphaChColor = _curve.Evaluate(time);
            _image.color = new Color(0f, 0f, 0f, alphaChColor);
            yield return 0;
        }

        SceneManager.LoadScene(sceneIndex);
    }
}
