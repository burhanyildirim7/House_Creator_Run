using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ThrowController : MonoBehaviour
{
     public static ThrowController instance;

     private Vector3[] waypoints;

    public List<BaseCollectable> brickList;
   

       private void Awake()
    {
        if (instance == null) instance = this;
       
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag=="finish")
        {
            StartPlaceObjects();
        }
        
    } 

    private void StartPlaceObjects()
    {
   
       for (int i = 0; i < brickList.Count; i++)
        {
            if(brickList[i]!=null)
                brickList[i].transform.DOMove(Place.instance.brickObjectPosition[i].position,i+1);
        }
    }

    public void PlaceObjectAddMethod(BaseCollectable brick){
        brickList.Add(brick);

    }

    public void PlaceObjectRemoveMethod(BaseCollectable brick){
        brickList.Remove(brick);

    }


    
}
