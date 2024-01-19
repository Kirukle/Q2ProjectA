using UnityEngine;

public class MusicLoop : MonoBehaviour
{
    public static MusicLoop Instance { get; private set; }

    public AudioSource musicSource;
    public AudioClip musicStart;

    private void Awake()
    {
        // Make this game object a singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        musicSource.PlayOneShot(musicStart);
        musicSource.PlayScheduled(AudioSettings.dspTime + musicStart.length);
    }

    // Update is called once per frame
    void Update()
    {

    }
}