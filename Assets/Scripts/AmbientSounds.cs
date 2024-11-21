using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSounds : MonoBehaviour
{
    [SerializeField] private AudioClip[] ambients;
    [SerializeField] private AudioSource source;
    private void Start()
    {
        StartCoroutine(SoundDelay(5f));
    }

    private void PlaySound()
    {
        int random = Random.Range(0, ambients.Length);
        source.PlayOneShot(ambients[random]);
        StartCoroutine(SoundDelay(ambients[random].length));
    }

    IEnumerator SoundDelay(float duration)
    {
        yield return new WaitForSeconds(duration);
        PlaySound();
    }

}
