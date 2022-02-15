using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class Ground : MonoBehaviour
{
    public static Ground instance;

    [SerializeField] private Text countText;

    public int groundCount;
    public int groundCountLimit;



    private void Awake()
    {
        if (instance == null) instance = this;

    }

    private void Update()
    {
        countText.text = groundCount + "/" + groundCountLimit;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectable")
        {
            GameObject gameObject = other.gameObject;
            Destroy(gameObject, 0.2f);
            ThrowController.instance.throwObjectList.Remove(gameObject.transform.GetComponent<BaseCollectable>());
            DOTween.Kill(gameObject);
            if (groundCount == groundCountLimit)
            {
               
                Wall.instance.wallCount++;

                return;
            }


            groundCount++;
            if (groundCount == groundCountLimit)
            {
                GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1);
                groundCount = groundCountLimit;
                StartCoroutine(OpenWall());
                
                GetComponent<BoxCollider>().enabled=false;
            }
        }

    }

    private IEnumerator OpenWall()
    {
        yield return new WaitForSeconds(0.3f);
       /*  House.instance.OpenWall(); */

    }



}
