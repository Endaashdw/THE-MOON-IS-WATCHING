using UnityEngine;
using System.Collections;

public class RandomSounds : MonoBehaviour
{
    public AudioSource theAudios;
    [SerializeField] public AudioClip[] audioClips;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(PlayRandomSounds());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator PlayRandomSounds (){
        while (true){
            AudioClip randomClip = audioClips[Random.Range(0, audioClips.Length)];
            theAudios.PlayOneShot(randomClip);
            
            float randomDelay = Random.Range(24f, 48f);
            yield return new WaitForSeconds(randomDelay);
        }
    }
}
