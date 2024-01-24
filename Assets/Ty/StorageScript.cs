using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StorageScript : MonoBehaviour
{
    public int Collectors;
    public Canvas EndingScene;
    public bool CollectedAll;
    public GameObject Music;
    public GameObject Camera;
    public GameObject Player;
    public GameObject EndingCamera;
    public GameObject Storage;
    // Update is called once per frame
    void Update()
    {
        if (Collectors > 3)
        {
            Debug.Log("Completed");
            CollectedAll = true;
        }
        if (CollectedAll == true)
        {
            Storage.SetActive(false);
            EndingScene.gameObject.SetActive(true);
            Music.SetActive(false);
            Camera.SetActive(false);
            Player.SetActive(false);
            EndingCamera.SetActive(true);
            


        }
    }
}
