using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Ground : MonoBehaviour
{
    public static Ground instance;

    [SerializeField] private Text countText;

    private int groundCount;


    private void Awake()
    {
        if (instance == null) instance = this;

    }

    private void Update() {
        countText.text = groundCount+"/100";
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="CollectableGround"){
            
            GameObject gameObject = other.gameObject;
            
            Destroy(gameObject,1f);
           groundCount++;
           if(groundCount==100){
               GetComponent<MeshRenderer>().material.color = new Color(1,1,1,1f);
           }
        }

    }


   

}
