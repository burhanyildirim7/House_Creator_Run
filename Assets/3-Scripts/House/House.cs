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
            StartCoroutine(DestroyObjects(other));

        }
    }

    private IEnumerator DestroyObjects(Collider other)
    {
        yield return new WaitForSeconds(0.5f);
        
        if (gameObject != null)
        {
            GameObject gameObject = other.gameObject;
            Destroy(gameObject);
            ThrowController.instance.throwObjectList.Remove(gameObject.transform.GetComponent<BaseCollectable>());
            DOTween.Kill(gameObject);
        }

    }

    private void CheckObjects()
    {

        if (groundCount == groundCountLimit && groundCount != 0)
        {
            ground.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1);

            OpenWall();
        }
        if (wallCount == wallCountLimit && wallCount != 0)
        {
            wall.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1);

            OpenRoof();
        }
        if (roofCount == roofCountLimit && roofCount != 0)
        {
            roof.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1);

            FinishHouse();
            



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
   

}
