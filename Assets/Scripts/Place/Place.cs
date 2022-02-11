using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place : MonoBehaviour
{
    public static Place instance;
    public List<Transform> brickObjectPosition = new List<Transform>();

         private void Awake()
    {
        if (instance == null) instance = this;
       
    }



}
