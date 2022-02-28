using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    [SerializeField] private Text _tuglaText, _cimentoText, _tahtaText;

    [SerializeField] private ParticleSystem _tozEfekti;

    private Transform _collectPointTransform;

    private int _tahtaSayisi, _cimentoSayisi, _tuglaSayisi;

    private void Awake()
    {
        if (instance == null) instance = this;

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "engel" && !triggerCheck)
        {

            if (StackObjectsList[stackObjectsList.Count - 1].GetComponent<ParcalarScript>()._tahta)
            {
                _tahtaSayisi--;
                _tahtaText.text = _tahtaSayisi.ToString();
            }
            else if (StackObjectsList[stackObjectsList.Count - 1].GetComponent<ParcalarScript>()._cimento)
            {
                _cimentoSayisi--;
                _cimentoText.text = _cimentoSayisi.ToString();
            }
            else if (StackObjectsList[stackObjectsList.Count - 1].GetComponent<ParcalarScript>()._tugla)
            {
                _tuglaSayisi--;
                _tuglaText.text = _tuglaSayisi.ToString();
            }
            else
            {

            }

            if (stackObjectsList.Count > 0)
                DropObjectMethod(stackObjectsList[stackObjectsList.Count - 1], other);



            triggerCheck = true;
        }

        if (other.tag == "finish")
        {
            stackObjectsList.Clear();

        }


    }




    public void SayiSifirla()
    {
        _tahtaSayisi = 0;
        _cimentoSayisi = 0;
        _tuglaSayisi = 0;

        _tahtaText.text = _tahtaSayisi.ToString();
        _cimentoText.text = _cimentoSayisi.ToString();
        _tuglaText.text = _tuglaSayisi.ToString();
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

        if (baseObject.GetComponent<ParcalarScript>()._tahta)
        {
            _tahtaSayisi++;
            _tahtaText.text = _tahtaSayisi.ToString();
        }
        else if (baseObject.GetComponent<ParcalarScript>()._cimento)
        {
            _cimentoSayisi++;
            _cimentoText.text = _cimentoSayisi.ToString();
        }
        else if (baseObject.GetComponent<ParcalarScript>()._tugla)
        {
            _tuglaSayisi++;
            _tuglaText.text = _tuglaSayisi.ToString();
        }
        else
        {

        }

        if (stackObjectsList.Count % 2 == 0 || stackObjectsList.Count == 0)
        {
            double heightSqrt = stackObjectsList.Count / 2;
            double height = heightSqrt / 6;

            baseObject.transform.DOLocalMove(new Vector3(CollectPoint.transform.localPosition.x, CollectPoint.transform.localPosition.y + ((float)height), 0 + (baseObject.transform.localScale.z / 2)), 0.5f).OnComplete(() =>
            {
                //baseObject.transform.DOLocalMoveX(baseObject.transform.localScale.x / 2, 0);

                //baseObject.transform.DOLocalMoveZ(baseObject.transform.localScale.z, 0);

                _tozEfekti.gameObject.transform.localPosition = new Vector3(CollectPoint.transform.localPosition.x, CollectPoint.transform.localPosition.y + ((float)height), 0 + (baseObject.transform.localScale.z / 2));
                _tozEfekti.Play();

            });
            baseObject.transform.DORotate(new Vector3(0, 0, 0), 1);
        }
        else if (stackObjectsList.Count % 2 == 1 || stackObjectsList.Count == 1)
        {

            double heightSqrt = stackObjectsList.Count / 2;
            double height = heightSqrt / 6;

            baseObject.transform.DOLocalMove(new Vector3(CollectPoint.transform.localPosition.x, CollectPoint.transform.localPosition.y + ((float)height), 0 + (-baseObject.transform.localScale.z / 2)), 0.5f).OnComplete(() =>
            {
                //baseObject.transform.DOLocalMoveX(-baseObject.transform.localScale.x / 2, 0);

                //baseObject.transform.DOLocalMoveZ(baseObject.transform.localScale.z, 0);

                _tozEfekti.gameObject.transform.localPosition = new Vector3(CollectPoint.transform.localPosition.x, CollectPoint.transform.localPosition.y + ((float)height), 0 + (-baseObject.transform.localScale.z / 2));
                _tozEfekti.Play();
            });
            baseObject.transform.DORotate(new Vector3(0, 0, 0), 1);
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
