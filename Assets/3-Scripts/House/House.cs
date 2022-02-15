using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
using UnityEngine.UI;

public class House : MonoBehaviour
{
    public static House instance;
    [SerializeField] private GameObject ground, wall, roof;
    [SerializeField] private Text groundText, wallText, roofText;
    public int groundCount, wallCount, roofCount;
    public int groundCountLimit, wallCountLimit, roofCountLimit;

    void Awake()
    {
        if (instance == null) instance = this;
        wall.SetActive(false);
        roof.SetActive(false);

    }
    private void Update()
    {
        groundText.text = groundCount + "/" + groundCountLimit;
        wallText.text = wallCount + "/" + wallCountLimit;
        roofText.text = roofCount + "/" + roofCountLimit;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectable")
        {

            GameObject gameObject = other.gameObject;
            Destroy(gameObject, 0.2f);
            ThrowController.instance.throwObjectList.Remove(gameObject.transform.GetComponent<BaseCollectable>());
            DOTween.Kill(gameObject);
            if (groundCount != groundCountLimit)
            {
                groundCount++;

            }
            else if (groundCount == groundCountLimit && wallCount != wallCountLimit)
            {
                wallCount++;

            }

            else if (wallCount == wallCountLimit && roofCount != roofCountLimit)
            {

                roofCount++;
                CheckObjects();
            }


            CheckObjects();


        }
    }

    private void CheckObjects()
    {

        if (groundCount == groundCountLimit)
        {
            ground.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1);

            OpenWall();
        }
        if (wallCount == wallCountLimit)
        {
            wall.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1);

            OpenRoof();
        }
        if (roofCount == roofCountLimit)
        {
            roof.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1);
        
            FinishHouse();
            DestroyAllObject();
            
       

        }
    }

    private void OpenWall()
    {

        wall.SetActive(true);

    }


    public void OpenRoof()
    {
        roof.SetActive(true);
    }

    public void FinishHouse()
    {
        transform.DORotate(new Vector3(0, 360, 0), 5, RotateMode.FastBeyond360);
        
    }
    public void DestroyAllObject()
    {

        foreach (var item in GameObject.FindGameObjectsWithTag("Collectable"))
        {
            GameObject gameObject = item.gameObject;
            Destroy(gameObject);
            
        }
       
    }

}
