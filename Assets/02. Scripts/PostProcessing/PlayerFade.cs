using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerFade : MonoBehaviour
{
    public static PlayerFade instance;

    [SerializeField]
    private PostProcessingManager postProcessingManager;
    [SerializeField]
    private float fadeDuration = 1f;
    [SerializeField]
    private float unfadeDuration = 1f;
    [SerializeField]
    private float timeBetweenFade = 0.5f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Fade(UnityEvent onFadeEvent, UnityEvent onUnfadeEvent)
    {
        StartCoroutine(FadeCoroutine(onFadeEvent, onUnfadeEvent));
    }

    private void Unfade(UnityEvent onFadeEvent, UnityEvent onUnfadeEvent)
    {
        StartCoroutine(UnfadeCoroutine(onFadeEvent, onUnfadeEvent));
    }

    private IEnumerator FadeCoroutine(UnityEvent onFadeEvent, UnityEvent onUnfadeEvent)
    {
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            postProcessingManager.SetFade(timer / fadeDuration);
            yield return null;
        }
        onFadeEvent.Invoke();
        yield return new WaitForSeconds(timeBetweenFade);
        Unfade(onFadeEvent, onUnfadeEvent);
    }

    private IEnumerator UnfadeCoroutine(UnityEvent onFadeEvent, UnityEvent onUnfadeEvent)
    {
        float timer = unfadeDuration;
        while (timer > 0f)
        {
            timer -= Time.deltaTime;
            postProcessingManager.SetFade(timer / fadeDuration);
            yield return null;
        }
        onUnfadeEvent.Invoke();
    }
}
