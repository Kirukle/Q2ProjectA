using UnityEngine;
using UnityEngine.SceneManagement;

public class StopMusic : MonoBehaviour
{
    private void Start()
    {
        GameObject musicPlayer = GameObject.FindWithTag("MusicPlayer");
        if (musicPlayer != null)
        {
            Destroy(musicPlayer);
        }
    }
}