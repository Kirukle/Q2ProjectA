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
            return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Main Menu")
        {
            if (!musicSource.isPlaying)
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