using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class StackController : MonoBehaviour
{
    public static StackController instance;
    public GameObject CollectPoint;
    public List<BaseCollectable> _stackObjectsList = new List<BaseCollectable>();
    public List<BaseCollectable> StackObjectsList => _stackObjectsList;

    public bool triggerCheck;

    private void Awake()
    {
        if (instance == null) instance = this;

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "engel"&&!triggerCheck)
        {
            
            if (_stackObjectsList.Count > 0)
                DropObjectMethod(_stackObjectsList[_stackObjectsList.Count - 1]);
            triggerCheck=true;
        }
    }

    void OnTriggerExit(Collider other)
    {
         if (other.tag == "engel")
        {
           triggerCheck=false;
        }
    }

    public void StackObjectMethod(BaseCollectable baseObject)
    {

        if (_stackObjectsList.Count % 2 == 0 || _stackObjectsList.Count == 0)
        {
            double heightSqrt = Math.Sqrt(_stackObjectsList.Count);
            double height = Math.Floor(heightSqrt);
            
            baseObject.transform.DOMove(new Vector3(CollectPoint.transform.position.x + (baseObject.transform.localScale.x/2), CollectPoint.transform.position.y + ((float)height), CollectPoint.transform.position.z), 0).OnComplete(()=>{
                    baseObject.transform.DOLocalMoveX(baseObject.transform.localScale.x/2,0);
                    
                    baseObject.transform.DOLocalMoveZ(baseObject.transform.localScale.z,0);
                   
            });

        }
        else if (_stackObjectsList.Count % 2 == 1 || _stackObjectsList.Count == 1)
        {

             double heightSqrt = Math.Sqrt(_stackObjectsList.Count-1);
            double height = Math.Floor(heightSqrt);

            baseObject.transform.DOMove(new Vector3(CollectPoint.transform.position.x + (-baseObject.transform.localScale.x/2), CollectPoint.transform.position.y + ((float)height), CollectPoint.transform.position.z), 0).OnComplete(()=>{
                baseObject.transform.DOLocalMoveX(-baseObject.transform.localScale.x/2,0);
               
                baseObject.transform.DOLocalMoveZ(baseObject.transform.localScale.z,0);
            });
        }

        _stackObjectsList.Add(baseObject);
        baseObject.transform.parent = CollectPoint.transform;
    }


    public void DropObjectMethod(BaseCollectable baseObject)
    {
        Debug.Log(_stackObjectsList.Count);
        
        baseObject.transform.DOMove(new Vector3(baseObject.transform.position.x + (CheckPlayerPos()), baseObject.transform.position.y + 2f, baseObject.transform.position.z + 5f), 0.3f).OnComplete(() =>
        {
            baseObject.transform.DOMoveY(1, 0.3f);
        });
        baseObject.transform.parent = null;
        _stackObjectsList.Remove(baseObject);

    }

    private float CheckPlayerPos(){
        float left = -1.5f;
        float right = 1.5f;
        float direction = 0;
        if (transform.position.x < 0)
            direction = right;
        else if (transform.position.x > 0)
            direction = left;
        else
        {
            direction = right;
        }
        return direction;
    }


}
