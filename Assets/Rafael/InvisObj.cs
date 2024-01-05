using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisObj : MonoBehaviour
{
    [SerializeField] private Material wallMaterial;
    [SerializeField] private Renderer wallModel;

    // Start is called before the first frame update
   private  void Start()
    {

        Color color = wallModel.material.color;
        color.a = 0;
        wallModel.material.color = color;


    }

    
}
