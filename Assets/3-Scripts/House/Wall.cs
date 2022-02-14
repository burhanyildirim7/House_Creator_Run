using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class Wall : MonoBehaviour
{
     public static Wall instance;

    [SerializeField] private Text countText;

    public int wallCount;
    public int wallCountLimit;


    private void Awake()
    {
        if (instance == null) instance = this;

    }

    private void Update() {
        countText.text = wallCount+"/"+wallCountLimit;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="CollectableWall"){
            
            GameObject gameObject = other.gameObject;
            
            Destroy(gameObject,0.2f);
            DOTween.Kill(gameObject);
           if(wallCount==wallCountLimit){
                Roof.instance.roofCount++;
                return; 
           }
            
           wallCount++;
           if(wallCount==wallCountLimit){
               GetComponent<MeshRenderer>().material.color = new Color(1,1,1,1);
               wallCount=wallCountLimit;
               House.instance.OpenRoof();
           }
        }

    }
}
