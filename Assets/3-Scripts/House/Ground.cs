using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ground : MonoBehaviour
{
    public static Ground instance;


    private void Awake()
    {
        if (instance == null) instance = this;

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="CollectableGround"){
            
            GameObject gameObject = other.gameObject;
            
            Destroy(gameObject,1.5f);
           
        }

    }

   

}
