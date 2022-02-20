using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class StackController : MonoBehaviour
{
    public static StackController instance;
    public GameObject CollectPoint;
    public List<GameObject> stackObjectsList = new List<GameObject>();
    public List<GameObject> StackObjectsList => stackObjectsList;
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
                DropObjectMethod(stackObjectsList[stackObjectsList.Count - 1], other);

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

    public void StackObjectMethod(GameObject baseObject)
    {

        if (stackObjectsList.Count % 2 == 0 || stackObjectsList.Count == 0)
        {
            double heightSqrt = stackObjectsList.Count / 2;
            double height = heightSqrt / 6;

            baseObject.transform.DOMove(new Vector3(CollectPoint.transform.position.x, CollectPoint.transform.position.y + ((float)height), CollectPoint.transform.position.z + (baseObject.transform.localScale.z / 2)), 0).OnComplete(() =>
            {
                //baseObject.transform.DOLocalMoveX(baseObject.transform.localScale.x / 2, 0);

                //baseObject.transform.DOLocalMoveZ(baseObject.transform.localScale.z, 0);

            });
            baseObject.transform.DORotate(new Vector3(0, 0, 0), 0);
        }
        else if (stackObjectsList.Count % 2 == 1 || stackObjectsList.Count == 1)
        {

            double heightSqrt = stackObjectsList.Count / 2;
            double height = heightSqrt / 6;

            baseObject.transform.DOMove(new Vector3(CollectPoint.transform.position.x, CollectPoint.transform.position.y + ((float)height), CollectPoint.transform.position.z + (-baseObject.transform.localScale.z / 2)), 0).OnComplete(() =>
            {
                //baseObject.transform.DOLocalMoveX(-baseObject.transform.localScale.x / 2, 0);

                //baseObject.transform.DOLocalMoveZ(baseObject.transform.localScale.z, 0);
            });
            baseObject.transform.DORotate(new Vector3(0, 0, 0), 0);
        }

        stackObjectsList.Add(baseObject);
        baseObject.transform.parent = CollectPoint.transform;
    }


    public void DropObjectMethod(GameObject baseObject, Collider other)
    {
        baseObject.AddComponent<Rigidbody>().useGravity = true;

        baseObject.GetComponent<BoxCollider>().isTrigger = false;



        baseObject.GetComponent<Rigidbody>().AddForce(new Vector3(CheckObstacleHitPos(other), 7, 7) * 50f);

        baseObject.transform.parent = null;

        stackObjectsList.Remove(baseObject);
        ThrowController.instance.PlaceObjectRemoveMethod(baseObject);
    }


    private float CheckObstacleHitPos(Collider other)
    {
        RaycastHit hit;
        Vector3 localHit;
        float direction = 1.5f;
        float left = -1.5f;
        float right = 1.5f;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            localHit = other.transform.InverseTransformPoint(hit.point);
            // Debug.Log(localHit);

            if (localHit.x < 0)
                direction = left;
            else if (localHit.x > 0)
                direction = right;
            else
            {
                direction = right;
            }
            return direction;


        }
        else
        {
            return direction;
        }



    }

}
