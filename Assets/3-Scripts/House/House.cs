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
    [SerializeField] private GameObject zeminSeffaf, zeminAnim, duvarSeffaf, duvarAnim, catiSeffaf, catiAnim, ekObjeler, animasyonObject, groundTextObject, wallTextObject, roofTextObject;
    [SerializeField] private Text groundText, wallText, roofText;

    public Animator zeminAnimator, duvarAnimator, catiAnimator, ekObjelerAnimator;
    public int groundCount, wallCount, roofCount;
    public int _zeminTahtaCountLimit, _zeminCimentoCountLimit, _zeminTuglaCountLimit;
    public int _govdeTahtaCountLimit, _govdeCimentoCountLimit, _govdeTuglaCountLimit;
    public int _catiTahtaCountLimit, _catiCimentoCountLimit, _catiTuglaCountLimit;

    [SerializeField] private ParticleSystem _tozEfekti;

    private int _tahtaCount, _cimentoCount, tuglaCount;

    public int roofCountLimit;

    [SerializeField] private List<GameObject> _zeminTahtalar;
    [SerializeField] private List<GameObject> _zeminCimentolar;

    void Awake()
    {
        if (instance == null) instance = this;

    }

    private void Start()
    {
        StartingEvents();
    }

    private void Update()
    {
        /*
        groundText.text = groundCount + " / " + groundCountLimit;
        wallText.text = wallCount + " / " + wallCountLimit;
        roofText.text = roofCount + " / " + roofCountLimit;
        */
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectable")
        {
            _tozEfekti.Play();


            if (other.GetComponent<ParcalarScript>()._tahta)
            {
                _tahtaCount++;
                _zeminTahtalar[_tahtaCount - 1].SetActive(true);
                Debug.Log("Tahta Geldi");
            }
            else if (other.GetComponent<ParcalarScript>()._cimento)
            {
                _cimentoCount++;
                _zeminCimentolar[_cimentoCount - 1].SetActive(true);
                Debug.Log("Cimento Geldi");
            }
            else if (other.GetComponent<ParcalarScript>()._tugla)
            {
                Debug.Log("Tugla Geldi");
            }
            else
            {
                Debug.Log("sonuncu sayma test");
            }
            /*
            if (groundCount != groundCountLimit)
            {
                //groundCount = PlayerPrefs.GetInt("ZeminDeger");
                groundCount++;
                SetScore();

                PlayerPrefs.SetInt("ZeminDeger", groundCount);


            }
            else if (groundCount == groundCountLimit && wallCount != wallCountLimit)
            {
                //wallCount = PlayerPrefs.GetInt("GovdeDeger");
                wallCount++;
                SetScore();

                PlayerPrefs.SetInt("GovdeDeger", wallCount);

            }
            else if (wallCount == wallCountLimit && roofCount != roofCountLimit)
            {
                //roofCount = PlayerPrefs.GetInt("CatiDeger");
                roofCount++;
                SetScore();

                PlayerPrefs.SetInt("CatiDeger", roofCount);

                //CheckObjects();


            }
            */

            CheckObjects();
            Destroy(other.gameObject);
            // StartCoroutine(DestroyObjects(other));

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
        /*
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
        */
    }

    private void OpenZeminAnim()
    {
        zeminSeffaf.SetActive(false);
        groundTextObject.SetActive(false);
        wallTextObject.SetActive(true);
        zeminAnim.SetActive(true);
        zeminAnimator.Play("ZeminAnimation");
        duvarSeffaf.SetActive(true);

    }


    public void OpenDuvarAnim()
    {
        duvarSeffaf.SetActive(false);
        wallTextObject.SetActive(false);
        roofTextObject.SetActive(true);
        duvarAnim.SetActive(true);
        duvarAnimator.Play("DuvarAnimation");
        catiSeffaf.SetActive(true);
    }

    public void FinishHouse()
    {
        catiSeffaf.SetActive(false);
        roofTextObject.SetActive(false);
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
        yield return new WaitForSeconds(3);
        animasyonObject.GetComponent<Animator>().SetTrigger("PastHouse");
        yield return new WaitForSeconds(2);
        HouseController.instance.DestroyHouse(this.gameObject);
        HouseController.instance.houseList.Add(this.gameObject);

    }

    private void StartingEvents()
    {
        wallTextObject.SetActive(false);
        roofTextObject.SetActive(false);
        groundTextObject.SetActive(true);
        zeminSeffaf.gameObject.SetActive(true);

        /*
        groundCount = PlayerPrefs.GetInt("ZeminDeger");
        wallCount = PlayerPrefs.GetInt("GovdeDeger");
        roofCount = PlayerPrefs.GetInt("CatiDeger");
        */

        CheckObjects();

        //HouseKonum();

    }

    public void HouseKonum()
    {
        GameObject spawnpoint = GameObject.FindGameObjectWithTag("EvSpawnPoint");
        Debug.Log(spawnpoint);
        transform.position = spawnpoint.transform.position;
    }

    /*
    public void HouseDegerKayitEvent()
    {
        PlayerPrefs.SetInt("ZeminDeger", groundCount);
        PlayerPrefs.SetInt("GovdeDeger", wallCount);
        PlayerPrefs.SetInt("CatiDeger", roofCount);
    }
    */
}
