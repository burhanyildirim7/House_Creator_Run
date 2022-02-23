using System.Diagnostics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : MonoBehaviour
{

    public static HouseController instance;
    public List<GameObject> houseList;

    private GameObject currentLevelObj;

    private void Awake()
    {
        if (instance == null) instance = this;

        EvOlustur();
    }

    private void Start()
    {

    }

    public void OpenHouse(int index)
    {

        currentLevelObj = Instantiate(houseList[index].gameObject, new Vector3(0, 0, 250f), Quaternion.identity);
    }

    public void EvOlustur()
    {
        //house.transform.position = GameObject.FindGameObjectWithTag("EvSpawnPoint").transform.position;
        HouseController.instance.OpenHouse(0);
    }



    public void DestroyHouse(GameObject house)
    {
        GameObject gameObject = house.gameObject;
        houseList.Remove(gameObject);
        Destroy(gameObject);

    }

}
