using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanable : MonoBehaviour
{
    public bool activated, important, readObj, walkObj, runObj, jumpObj, climbObj;
    public GameObject textPrefab, player, spawnedText;
   
    public float scanTime, destroyTime;
    public string TextName;
    public Transform playerLoc;

    // Update is called once per frame
    void Update()
    {
        if (activated == true)
        {
            Instantiate(textPrefab).GetComponent<TMPro.TMP_Text>().SetText(TextName);
            
        }
      
        if(important == true)
        {
            if(readObj == true)
            {
               
            }
            if (walkObj == true)
            {
                player.GetComponent<ThirdMover>().CanMove = true;
            }
            if(runObj == true)
            {
                player.GetComponent<ThirdMover>().CanSprint = true;
            }
            if (jumpObj == true)
            {
                player.GetComponent<Jumpy>().canJump = true;
            }
            if(climbObj == true)
            {

            }
        }
    }
}