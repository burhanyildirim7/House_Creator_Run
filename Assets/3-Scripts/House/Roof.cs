using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class Roof : MonoBehaviour
{
    public static Roof instance;

    [SerializeField] private Text countText;

    public int roofCount;
    public int roofCountLimit;

    private void Awake()
    {
        if (instance == null) instance = this;

    }

    private void Update() {
        countText.text = roofCount+"/"+roofCountLimit;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="CollectableRoof"){
            
            GameObject gameObject = other.gameObject;
            
            Destroy(gameObject,0.2f);
            DOTween.Kill(gameObject);
           if(roofCount==roofCountLimit)
            return; 
           roofCount++;
           if(roofCount==roofCountLimit){
               GetComponent<MeshRenderer>().material.color = new Color(1,1,1,1);
               roofCount=roofCountLimit;
                House.instance.FinishHouse();
           }
        }

    }
}
