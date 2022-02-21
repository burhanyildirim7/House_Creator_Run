using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ThrowController : MonoBehaviour
{
    public static ThrowController instance;

    [SerializeField] private Transform waypoint1, wayPoint2;

    public List<GameObject> throwObjectList;


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

        for (int i = throwObjectList.Count - 1; i >= 0; i--)
        {
            throwObjectList[i].transform.DOMoveZ(wayPoint2.position.z, 0.5f);
        }


        if (House.instance.roofCount != House.instance.roofCountLimit)
        {
            yield return new WaitForSeconds(0.5f);


            //Debug.Log("birinci if");

            for (int i = 0; i < throwObjectList.Count; i++)
            {
                if (House.instance.roofCount != House.instance.roofCountLimit)
                {
                    yield return new WaitForSeconds(0.1f);

                    throwObjectList[i].transform.DOMove(House.instance.transform.position, 0.5f);

                }
                else
                {

                    GameController.instance.DestroyAllObject();
                    throwObjectList.Clear();
                }

            }

            if (House.instance.roofCount != House.instance.roofCountLimit)
            {
                PlayerController.instance.WinBaslat(2);
                GameController.instance.DestroyAllObject();
                throwObjectList.Clear();
            }
            else
            {
                PlayerController.instance.WinBaslat(6);

            }


            /*
            yield return new WaitForSeconds(2f);

            if (House.instance.wallCount != House.instance.wallCountLimit)
            {
                Debug.Log("ikinci if");
                CheckThrowObject();
                for (int i = 0; i < CheckThrowObject(); i++)
                {
                    if (House.instance.roofCount != House.instance.roofCountLimit)
                    {
                        yield return new WaitForSeconds(0.1f);

                        throwObjectList[i].transform.DOMove(House.instance.transform.position, 0.5f);

                    }
                    else
                    {
                        GameController.instance.DestroyAllObject();
                        throwObjectList.Clear();
                    }

                }
            }
            else
            {
                CheckThrowObject();
            }

            yield return new WaitForSeconds(2f);

            if (House.instance.roofCount != House.instance.roofCountLimit)
            {
                Debug.Log("ucuncu if");
                CheckThrowObject();
                for (int i = 0; i < CheckThrowObject(); i++)
                {
                    if (House.instance.roofCount != House.instance.roofCountLimit)
                    {
                        yield return new WaitForSeconds(0.1f);

                        throwObjectList[i].transform.DOMove(House.instance.transform.position, 0.5f);

                    }
                    else
                    {
                        GameController.instance.DestroyAllObject();
                        throwObjectList.Clear();
                    }

                }
            }
            else
            {
                CheckThrowObject();
            }
            */

        }
        else
        {

        }

        //CheckThrowObject();


    }




    //yield return new WaitForSeconds(1.5f);

    /*
    for (int i = throwObjectList.Count - 1; i >= 0; i--)
    {
        yield return new WaitForSeconds(0.1f);
        throwObjectList[i].transform.DOMove(GameObject.FindGameObjectWithTag("House").gameObject.transform.position, 0.5f);
    }


    foreach (var item in throwObjectList)
    {

        if (item != null)
        {
            yield return new WaitForSeconds(0.1f);
            item.transform.DOMove(House.instance.transform.position, 0.5f);
        }

    }

    */






    public int CheckThrowObject()
    {
        int tempGround = House.instance.groundCount;
        int tempWall = House.instance.wallCount;
        int tempRoof = House.instance.roofCount;

        int tempGroundLimit = House.instance.groundCountLimit;
        int tempWallLimit = House.instance.wallCountLimit;
        int tempRoofLimit = House.instance.roofCountLimit;

        int tempObject = throwObjectList.Count;

        int tempGroundNet = tempGroundLimit - tempGround;
        int tempWallNet = tempWallLimit - tempWall;
        int tempRoofNet = tempRoofLimit - tempRoof;


        if (tempGround != tempGroundLimit && tempObject > tempGroundNet)
        {
            Debug.Log("birinci hesap if");
            return tempGroundNet;
        }
        else if (tempGround != 0 && tempGround == tempGroundLimit && tempRoof == 0 && tempObject > tempWallNet)
        {
            Debug.Log("ikinci hesap if");
            return tempWallNet;
        }

        else
        {
            Debug.Log("ikinci hesap if");
            return tempObject;
        }





    }



    public void PlaceObjectAddMethod(GameObject brick)
    {
        throwObjectList.Add(brick);

    }

    public void PlaceObjectRemoveMethod(GameObject brick)
    {
        throwObjectList.Remove(brick);

    }



}
