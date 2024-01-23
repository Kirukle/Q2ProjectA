using UnityEngine;

public class GameMusicLoop : MonoBehaviour
{
    public static GameMusicLoop Instance { get; private set; }

    public AudioSource musicSource;
    public AudioClip musicStart;

    private void Awake()
    {
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
        musicSource.clip = musicStart;
        musicSource.loop = true; // Loop
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}