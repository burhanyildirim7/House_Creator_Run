using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class House : MonoBehaviour
{
    public static House instance;
    [SerializeField] private GameObject ground,wall,roof;

   
    void Awake()
    {
         if (instance == null) instance = this;
         wall.SetActive(false);
         roof.SetActive(false);

    }



    public void OpenWall()
    {
       wall.SetActive(true);
    }

      public void OpenRoof()
    {
        roof.SetActive(true);
    }
    
    public void FinishHouse()
    {
        transform.DORotate(new Vector3(0,360,0),5,RotateMode.FastBeyond360);
    }
}
