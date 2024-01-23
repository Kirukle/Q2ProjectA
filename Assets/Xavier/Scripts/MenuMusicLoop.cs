using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusicLoop : MonoBehaviour
{
    public static MenuMusicLoop Instance { get; private set; }

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
        SceneManager.sceneLoaded += OnSceneLoaded; // SceneLoaded event
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Main Menu")
        {
            if (!musicSource.isPlaying) // Check if the music is not playing
            {
                musicSource.clip = musicStart;
                musicSource.Play();
            }
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Main Menu")
        {
            if (!musicSource.isPlaying) // Check if the music is not playing
            {
                musicSource.clip = musicStart;
                musicSource.Play();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}