using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class StackController : MonoBehaviour
{
    public static StackController instance;
    public GameObject CollectPoint;
    public List<BaseCollectable> stackObjectsList = new List<BaseCollectable>();
    public List<BaseCollectable> StackObjectsList => stackObjectsList;
    [HideInInspector]
    public bool triggerCheck;

    private void Awake()
    {
        if (instance == null) instance = this;

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "engel" && !triggerCheck)
        {

            if (stackObjectsList.Count > 0)
                DropObjectMethod(stackObjectsList[stackObjectsList.Count - 1]);
            triggerCheck = true;
        }

        if (other.tag == "finish")
        {
            stackObjectsList.Clear();
           
        }


    }



    void OnTriggerExit(Collider other)
    {
        if (other.tag == "engel")
        {
            triggerCheck = false;
        }
    }

    public void StackObjectMethod(BaseCollectable baseObject)
    {

        if (stackObjectsList.Count % 2 == 0 || stackObjectsList.Count == 0)
        {
            double heightSqrt = stackObjectsList.Count / 2;
            double height = Math.Floor(heightSqrt);

            baseObject.transform.DOMove(new Vector3(CollectPoint.transform.position.x + (baseObject.transform.localScale.x / 2), CollectPoint.transform.position.y + ((float)height), CollectPoint.transform.position.z), 0).OnComplete(() =>
            {
                baseObject.transform.DOLocalMoveX(baseObject.transform.localScale.x / 2, 0);

                baseObject.transform.DOLocalMoveZ(baseObject.transform.localScale.z, 0);

            });
            baseObject.transform.DORotate(new Vector3(0, 0, 0), 0);
        }
        else if (stackObjectsList.Count % 2 == 1 || stackObjectsList.Count == 1)
        {

            double heightSqrt = stackObjectsList.Count / 2;
            double height = Math.Floor(heightSqrt);

            baseObject.transform.DOMove(new Vector3(CollectPoint.transform.position.x + (-baseObject.transform.localScale.x / 2), CollectPoint.transform.position.y + ((float)height), CollectPoint.transform.position.z), 0).OnComplete(() =>
            {
                baseObject.transform.DOLocalMoveX(-baseObject.transform.localScale.x / 2, 0);

                baseObject.transform.DOLocalMoveZ(baseObject.transform.localScale.z, 0);
            });
            baseObject.transform.DORotate(new Vector3(0, 0, 0), 0);
        }

        stackObjectsList.Add(baseObject);
        baseObject.transform.parent = CollectPoint.transform;
    }


    public void DropObjectMethod(BaseCollectable baseObject)
    {
        baseObject.gameObject.AddComponent<Rigidbody>().useGravity = true;

        baseObject.gameObject.GetComponent<BoxCollider>().isTrigger = false;
/*         baseObject.transform.DOMove(new Vector3(transform.position.x,transform.position.y+5,transform.position.z+5), 0.5f).OnComplete(()=>{

        }); */

        
        baseObject.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(CheckPlayerPos(),7,7)*50f); 

        baseObject.transform.parent = null;

        stackObjectsList.Remove(baseObject);
        BrickController.instance.PlaceObjectRemoveMethod(baseObject);
    }

    private float CheckPlayerPos()
    {
        float left = -1.5f;
        float right = 1.5f;
        float direction = 0;
        if (transform.position.x < 0)
            direction = left;
        else if (transform.position.x > 0)
            direction = right;
        else
        {
            direction = right;
        }
        return direction;
    }


}
