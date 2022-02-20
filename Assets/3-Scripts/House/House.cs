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
    [SerializeField] private GameObject zeminSeffaf, zeminAnim, duvarSeffaf, duvarAnim, catiSeffaf, catiAnim, ekObjeler;
    [SerializeField] private Text groundText, wallText, roofText;

    public Animator zeminAnimator, duvarAnimator, catiAnimator, ekObjelerAnimator;
    public int groundCount, wallCount, roofCount;
    public int groundCountLimit, wallCountLimit, roofCountLimit;

    void Awake()
    {
        if (instance == null) instance = this;




    }

    private void Start()
    {
        zeminSeffaf.gameObject.SetActive(true);
    }
    private void Update()
    {
        /*   groundText.text = groundCount + "/" + groundCountLimit;
          wallText.text = wallCount + "/" + wallCountLimit;
          roofText.text = roofCount + "/" + roofCountLimit; */
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectable")
        {


            if (groundCount != groundCountLimit)
            {
                groundCount++;
                SetScore();


            }
            else if (groundCount == groundCountLimit && wallCount != wallCountLimit)
            {
                wallCount++;

                SetScore();

            }

            else if (wallCount == wallCountLimit && roofCount != roofCountLimit)
            {

                roofCount++;
                SetScore();

                CheckObjects();


            }


            CheckObjects();
            StartCoroutine(DestroyObjects(other));

        }
    }

    private void SetScore()
    {
        GameController.instance.SetScore(PlayerController.instance.collectibleDegeri);
    }

    private IEnumerator DestroyObjects(Collider other)
    {
        yield return new WaitForSeconds(0.5f);

        if (gameObject != null)
        {
            GameObject gameObject = other.gameObject;
            Destroy(gameObject);
            ThrowController.instance.throwObjectList.Remove(gameObject.transform.GetComponent<GameObject>());
            DOTween.Kill(gameObject);
        }

    }

    private void CheckObjects()
    {

        if (groundCount == groundCountLimit && groundCount != 0)
        {

            OpenZeminAnim();

        }
        if (wallCount == wallCountLimit && wallCount != 0)
        {


            OpenDuvarAnim();
        }
        if (roofCount == roofCountLimit && roofCount != 0)
        {


            FinishHouse();




        }
    }

    private void OpenZeminAnim()
    {
        zeminAnim.SetActive(true);
        zeminAnimator.Play("ZeminAnimation");
        duvarSeffaf.SetActive(true);

    }


    public void OpenDuvarAnim()
    {
        duvarAnim.SetActive(true);
        duvarAnimator.Play("DuvarAnimation");
        catiSeffaf.SetActive(true);
    }

    public void FinishHouse()
    {
        catiAnim.SetActive(true);
        catiAnimator.Play("CatiAnimation");
        /*  transform.DORotate(new Vector3(0, 360, 0), 5, RotateMode.FastBeyond360); */
        /* HouseController.instance.DestroyHouse(this); */
        StartCoroutine(StartEkObjeler());
    }

    private IEnumerator StartEkObjeler()
    {
        yield return new WaitForSeconds(1);
        ekObjeler.SetActive(true);
        ekObjelerAnimator.Play("ParkeAnimation");
        StartCoroutine(StartHouseAnim());
    }

    private IEnumerator StartHouseAnim()
    {
        yield return new WaitForSeconds(6);
        transform.gameObject.GetComponent<Animator>().SetTrigger("PastHouse");
        yield return new WaitForSeconds(2);
        HouseController.instance.DestroyHouse(this.gameObject);
        HouseController.instance.houseList.Add(this.gameObject);

    }
}
