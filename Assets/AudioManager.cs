using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayBackgroundMusic(AudioClip music)
    {
        GetComponent<AudioSource>().clip = music;
        GetComponent<AudioSource>().Play();
    }
}
