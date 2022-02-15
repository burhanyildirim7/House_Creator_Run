using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class Wall : MonoBehaviour
{
    public static Wall instance;

    [SerializeField] private Text countText;

    public int wallCount;
    public int wallCountLimit;


    private void Awake()
    {
        if (instance == null) instance = this;

    }

    private void Update()
    {
        countText.text = wallCount + "/" + wallCountLimit;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectable")
        {

            GameObject gameObject = other.gameObject;
            Destroy(gameObject, 0.2f);
            ThrowController.instance.throwObjectList.Remove(gameObject.transform.GetComponent<BaseCollectable>());

            DOTween.Kill(gameObject);

            if (wallCount == wallCountLimit)
            {
                
                Roof.instance.roofCount++;
                return;
            }

            wallCount++;
            if (wallCount == wallCountLimit)
            {
                GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1);
                wallCount = wallCountLimit;
                StartCoroutine(OpenRoof());
                GetComponent<BoxCollider>().enabled = false;
            }
        }

    }

    private IEnumerator OpenRoof()
    {
        yield return new WaitForSeconds(0.3f);
        House.instance.OpenRoof();
    }

 
}
