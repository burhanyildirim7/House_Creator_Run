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
        if (other.tag == "CollectableGround")
        {
            GameObject gameObject = other.gameObject;
            Destroy(gameObject, 0.2f);
            // DOTween.Kill(gameObject);
            if (groundCount == groundCountLimit)
            {
                DOTween.Pause(gameObject);
                Wall.instance.wallCount++;

                return;
            }


            groundCount++;
            if (groundCount == groundCountLimit)
            {
                GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1);
                groundCount = groundCountLimit;
                House.instance.OpenWall();
            }
        }

    }




}
