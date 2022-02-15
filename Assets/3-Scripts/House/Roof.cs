using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class Roof : MonoBehaviour
{
    public static Roof instance;

    [SerializeField] private Text countText;

    public int roofCount;
    public int roofCountLimit;

    private void Awake()
    {
        if (instance == null) instance = this;

    }

    private void Update()
    {
        countText.text = roofCount + "/" + roofCountLimit;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectable")
        {

            GameObject gameObject = other.gameObject;
            Destroy(gameObject, 0.2f);
            ThrowController.instance.throwObjectList.Remove(gameObject.transform.GetComponent<BaseCollectable>());

            DOTween.Kill(gameObject);
            if (roofCount == roofCountLimit)
            {
                return;

            }
            roofCount++;
            if (roofCount == roofCountLimit)
            {
                GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1);
                roofCount = roofCountLimit;
                House.instance.FinishHouse();
                GetComponent<BoxCollider>().enabled = false;
            }
        }

    }

}
