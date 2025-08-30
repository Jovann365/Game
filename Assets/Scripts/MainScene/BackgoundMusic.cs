using System.Collections;
using UnityEngine;

public class BackgoundMusic : MonoBehaviour
{
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        StartCoroutine(Fade(true, source, 2f, 1f));
        StartCoroutine(Fade(false, source, 2f, 0f));


    }

    public IEnumerator Fade(bool fadeIn, AudioSource source, float duration, float targetVolume)
    {
        if (!fadeIn)
        {
            double lengthOfSource = (double)source.clip.samples / source.clip.frequency;
            yield return new WaitForSecondsRealtime((float)(lengthOfSource - duration));
        }

        float time = 0f;
        float startVolume = source.volume;
        while (time < duration)
        {
            time += Time.deltaTime;
            source.volume = Mathf.Lerp(startVolume, targetVolume, time / duration);

            yield return null;
        }
        {

        }
    }
}
