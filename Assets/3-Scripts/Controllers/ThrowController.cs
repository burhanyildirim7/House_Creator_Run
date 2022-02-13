using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ThrowController : MonoBehaviour
{
    public static ThrowController instance;

    [SerializeField] private Transform waypoint1,wayPoint2,wayPoint3;

    public List<BaseCollectable> throwObjectList;


    private void Awake()
    {
        if (instance == null) instance = this;

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "finish")
        {
           StartCoroutine(StartPlaceObjects());
        }
       

    }

    private IEnumerator StartPlaceObjects()
    {

        for (int i = throwObjectList.Count - 1; i >= 0; i--)
        {
            yield return new WaitForSeconds(0.1f);
            throwObjectList[i].transform.DOMoveY(throwObjectList[i].transform.position.y + waypoint1.position.y, 0.5f);          
        }

        for (int i = throwObjectList.Count-1; i >=0 ; i--)
        {
            throwObjectList[i].transform.DOMoveZ(wayPoint2.position.z, 0.5f);
        }

        for (int i = throwObjectList.Count-1; i >=0 ; i--)
        {
             yield return new WaitForSeconds(0.1f);
            throwObjectList[i].transform.DOMoveY(wayPoint3.position.y, 0.5f); 
        }



    }

    public void PlaceObjectAddMethod(BaseCollectable brick)
    {
        throwObjectList.Add(brick);

    }

    public void PlaceObjectRemoveMethod(BaseCollectable brick)
    {
        throwObjectList.Remove(brick);

    }



}
