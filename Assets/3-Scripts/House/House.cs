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
    [SerializeField] private GameObject zeminSeffaf, zeminAnim, duvarSeffaf, duvarAnim, catiSeffaf, catiAnim, ekObjeler, animasyonObject;
    [SerializeField] private Text _tahtaText, _cimentoText, _tuglaText;

    public Animator zeminAnimator, duvarAnimator, catiAnimator, ekObjelerAnimator;
    //public int groundCount, wallCount, roofCount;
    //public int _zeminTahtaCountLimit, _zeminCimentoCountLimit, _zeminTuglaCountLimit;
    //public int _govdeTahtaCountLimit, _govdeCimentoCountLimit, _govdeTuglaCountLimit;
    //public int _catiTahtaCountLimit, _catiCimentoCountLimit, _catiTuglaCountLimit;

    [SerializeField] private ParticleSystem _tozEfekti;

    private int _tahtaCount, _cimentoCount, _tuglaCount;

    public int roofCountLimit;

    [SerializeField] private List<GameObject> _binaBolumleri;

    private bool _zemin, _duvar1, _duvar2, _duvar3, _duvar4, _duvar5, _cati1, _cati2;

    public bool _binaBitti;

    private int _zeminTamam, _duvar1Tamam, _duvar2Tamam, _duvar3Tamam, _duvar4Tamam, _duvar5Tamam, _cati1Tamam, _cati2Tamam;



    void Awake()
    {
        if (instance == null) instance = this;

    }

    [Obsolete]
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

    [Obsolete]
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectable")
        {
            _tozEfekti.Play();

            SetScore();

            CheckObjects();

            if (other.GetComponent<ParcalarScript>()._tahta)
            {
                _tahtaCount++;

                PlayerPrefs.SetInt("TahtaCount", _tahtaCount);

                if (_zemin == false)
                {
                    if (_binaBolumleri[0].transform.FindChild("TAHTA") != null)
                    {
                        if (_binaBolumleri[0].transform.FindChild("TAHTA").transform.childCount > _tahtaCount - 1)
                        {
                            _binaBolumleri[0].transform.FindChild("TAHTA").transform.GetChild(_tahtaCount - 1).gameObject.SetActive(true);
                            _tahtaText.text = _tahtaCount.ToString() + "/" + _binaBolumleri[0].transform.FindChild("TAHTA").transform.childCount.ToString();
                        }
                        else
                        {
                            _tahtaText.text = _binaBolumleri[0].transform.FindChild("TAHTA").transform.childCount.ToString() + "/" + _binaBolumleri[0].transform.FindChild("TAHTA").transform.childCount.ToString();
                        }
                    }
                    else
                    {
                        _tahtaText.text = 0 + "/" + 0;
                    }

                }
                else if (_duvar1 == false)
                {
                    if (_binaBolumleri[1].transform.FindChild("TAHTA") != null)
                    {
                        if (_binaBolumleri[1].transform.FindChild("TAHTA").transform.childCount > _tahtaCount - 1)
                        {
                            _binaBolumleri[1].transform.FindChild("TAHTA").transform.GetChild(_tahtaCount - 1).gameObject.SetActive(true);
                            _tahtaText.text = _tahtaCount.ToString() + "/" + _binaBolumleri[1].transform.FindChild("TAHTA").transform.childCount.ToString();
                        }
                        else
                        {
                            _tahtaText.text = _binaBolumleri[1].transform.FindChild("TAHTA").transform.childCount.ToString() + "/" + _binaBolumleri[1].transform.FindChild("TAHTA").transform.childCount.ToString();
                        }
                    }
                    else
                    {
                        _tahtaText.text = 0 + "/" + 0;
                    }

                }
                else if (_duvar2 == false)
                {
                    if (_binaBolumleri[2].transform.FindChild("TAHTA") != null)
                    {
                        if (_binaBolumleri[2].transform.FindChild("TAHTA").transform.childCount > _tahtaCount - 1)
                        {
                            _binaBolumleri[2].transform.FindChild("TAHTA").transform.GetChild(_tahtaCount - 1).gameObject.SetActive(true);
                            _tahtaText.text = _tahtaCount.ToString() + "/" + _binaBolumleri[2].transform.FindChild("TAHTA").transform.childCount.ToString();
                        }
                        else
                        {
                            _tahtaText.text = _binaBolumleri[2].transform.FindChild("TAHTA").transform.childCount.ToString() + "/" + _binaBolumleri[2].transform.FindChild("TAHTA").transform.childCount.ToString();
                        }
                    }
                    else
                    {
                        _tahtaText.text = 0 + "/" + 0;
                    }

                }
                else if (_duvar3 == false)
                {
                    if (_binaBolumleri[3].transform.FindChild("TAHTA") != null)
                    {
                        if (_binaBolumleri[3].transform.FindChild("TAHTA").transform.childCount > _tahtaCount - 1)
                        {
                            _binaBolumleri[3].transform.FindChild("TAHTA").transform.GetChild(_tahtaCount - 1).gameObject.SetActive(true);
                            _tahtaText.text = _tahtaCount.ToString() + "/" + _binaBolumleri[3].transform.FindChild("TAHTA").transform.childCount.ToString();
                        }
                        else
                        {
                            _tahtaText.text = _binaBolumleri[3].transform.FindChild("TAHTA").transform.childCount.ToString() + "/" + _binaBolumleri[3].transform.FindChild("TAHTA").transform.childCount.ToString();
                        }
                    }
                    else
                    {
                        _tahtaText.text = 0 + "/" + 0;
                    }

                }
                else if (_duvar4 == false)
                {
                    if (_binaBolumleri[4].transform.FindChild("TAHTA") != null)
                    {
                        if (_binaBolumleri[4].transform.FindChild("TAHTA").transform.childCount > _tahtaCount - 1)
                        {
                            _binaBolumleri[4].transform.FindChild("TAHTA").transform.GetChild(_tahtaCount - 1).gameObject.SetActive(true);
                            _tahtaText.text = _tahtaCount.ToString() + "/" + _binaBolumleri[4].transform.FindChild("TAHTA").transform.childCount.ToString();
                        }
                        else
                        {
                            _tahtaText.text = _binaBolumleri[4].transform.FindChild("TAHTA").transform.childCount.ToString() + "/" + _binaBolumleri[4].transform.FindChild("TAHTA").transform.childCount.ToString();
                        }
                    }
                    else
                    {
                        _tahtaText.text = 0 + "/" + 0;
                    }

                }
                else if (_duvar5 == false)
                {
                    if (_binaBolumleri[5].transform.FindChild("TAHTA") != null)
                    {
                        if (_binaBolumleri[5].transform.FindChild("TAHTA").transform.childCount > _tahtaCount - 1)
                        {
                            _binaBolumleri[5].transform.FindChild("TAHTA").transform.GetChild(_tahtaCount - 1).gameObject.SetActive(true);
                            _tahtaText.text = _tahtaCount.ToString() + "/" + _binaBolumleri[5].transform.FindChild("TAHTA").transform.childCount.ToString();
                        }
                        else
                        {
                            _tahtaText.text = _binaBolumleri[5].transform.FindChild("TAHTA").transform.childCount.ToString() + "/" + _binaBolumleri[5].transform.FindChild("TAHTA").transform.childCount.ToString();
                        }
                    }
                    else
                    {
                        _tahtaText.text = 0 + "/" + 0;
                    }

                }
                else if (_cati1 == false)
                {
                    if (_binaBolumleri[6].transform.FindChild("TAHTA") != null)
                    {
                        if (_binaBolumleri[6].transform.FindChild("TAHTA").transform.childCount > _tahtaCount - 1)
                        {
                            _binaBolumleri[6].transform.FindChild("TAHTA").transform.GetChild(_tahtaCount - 1).gameObject.SetActive(true);
                            _tahtaText.text = _tahtaCount.ToString() + "/" + _binaBolumleri[6].transform.FindChild("TAHTA").transform.childCount.ToString();
                        }
                        else
                        {
                            _tahtaText.text = _binaBolumleri[6].transform.FindChild("TAHTA").transform.childCount.ToString() + "/" + _binaBolumleri[6].transform.FindChild("TAHTA").transform.childCount.ToString();
                        }
                    }
                    else
                    {
                        _tahtaText.text = 0 + "/" + 0;
                    }

                }
                else if (_cati2 == false)
                {
                    if (_binaBolumleri[7].transform.FindChild("TAHTA") != null)
                    {
                        if (_binaBolumleri[7].transform.FindChild("TAHTA").transform.childCount > _tahtaCount - 1)
                        {
                            _binaBolumleri[7].transform.FindChild("TAHTA").transform.GetChild(_tahtaCount - 1).gameObject.SetActive(true);
                            _tahtaText.text = _tahtaCount.ToString() + "/" + _binaBolumleri[7].transform.FindChild("TAHTA").transform.childCount.ToString();
                        }
                        else
                        {
                            _tahtaText.text = _binaBolumleri[7].transform.FindChild("TAHTA").transform.childCount.ToString() + "/" + _binaBolumleri[7].transform.FindChild("TAHTA").transform.childCount.ToString();
                        }
                    }
                    else
                    {
                        _tahtaText.text = 0 + "/" + 0;
                    }

                }
                else
                {

                }


                Debug.Log("Tahta Geldi");
            }
            else if (other.GetComponent<ParcalarScript>()._cimento)
            {
                _cimentoCount++;

                PlayerPrefs.SetInt("CimentoCount", _cimentoCount);

                if (_zemin == false)
                {
                    if (_binaBolumleri[0].transform.FindChild("CIMENTO") != null)
                    {
                        if (_binaBolumleri[0].transform.FindChild("CIMENTO").transform.childCount > _cimentoCount - 1)
                        {
                            _binaBolumleri[0].transform.FindChild("CIMENTO").transform.GetChild(_cimentoCount - 1).gameObject.SetActive(true);
                            _cimentoText.text = _cimentoCount.ToString() + "/" + _binaBolumleri[0].transform.FindChild("CIMENTO").transform.childCount.ToString();
                        }
                        else
                        {
                            _cimentoText.text = _binaBolumleri[0].transform.FindChild("CIMENTO").transform.childCount.ToString() + "/" + _binaBolumleri[0].transform.FindChild("CIMENTO").transform.childCount.ToString();
                        }
                    }
                    else
                    {
                        _cimentoText.text = 0 + "/" + 0;
                    }

                }
                else if (_duvar1 == false)
                {
                    if (_binaBolumleri[1].transform.FindChild("CIMENTO") != null)
                    {
                        if (_binaBolumleri[1].transform.FindChild("CIMENTO").transform.childCount > _cimentoCount - 1)
                        {
                            _binaBolumleri[1].transform.FindChild("CIMENTO").transform.GetChild(_cimentoCount - 1).gameObject.SetActive(true);
                            _cimentoText.text = _cimentoCount.ToString() + "/" + _binaBolumleri[1].transform.FindChild("CIMENTO").transform.childCount.ToString();
                        }
                        else
                        {
                            _cimentoText.text = _binaBolumleri[1].transform.FindChild("CIMENTO").transform.childCount.ToString() + "/" + _binaBolumleri[1].transform.FindChild("CIMENTO").transform.childCount.ToString();
                        }
                    }
                    else
                    {
                        _cimentoText.text = 0 + "/" + 0;
                    }

                }
                else if (_duvar2 == false)
                {
                    if (_binaBolumleri[2].transform.FindChild("CIMENTO") != null)
                    {
                        if (_binaBolumleri[2].transform.FindChild("CIMENTO").transform.childCount > _cimentoCount - 1)
                        {
                            _binaBolumleri[2].transform.FindChild("CIMENTO").transform.GetChild(_cimentoCount - 1).gameObject.SetActive(true);
                            _cimentoText.text = _cimentoCount.ToString() + "/" + _binaBolumleri[2].transform.FindChild("CIMENTO").transform.childCount.ToString();
                        }
                        else
                        {
                            _cimentoText.text = _binaBolumleri[2].transform.FindChild("CIMENTO").transform.childCount.ToString() + "/" + _binaBolumleri[2].transform.FindChild("CIMENTO").transform.childCount.ToString();
                        }
                    }
                    else
                    {
                        _cimentoText.text = 0 + "/" + 0;
                    }

                }
                else if (_duvar3 == false)
                {
                    if (_binaBolumleri[3].transform.FindChild("CIMENTO") != null)
                    {
                        if (_binaBolumleri[3].transform.FindChild("CIMENTO").transform.childCount > _cimentoCount - 1)
                        {
                            _binaBolumleri[3].transform.FindChild("CIMENTO").transform.GetChild(_cimentoCount - 1).gameObject.SetActive(true);
                            _cimentoText.text = _cimentoCount.ToString() + "/" + _binaBolumleri[3].transform.FindChild("CIMENTO").transform.childCount.ToString();
                        }
                        else
                        {
                            _cimentoText.text = _binaBolumleri[3].transform.FindChild("CIMENTO").transform.childCount.ToString() + "/" + _binaBolumleri[3].transform.FindChild("CIMENTO").transform.childCount.ToString();
                        }
                    }
                    else
                    {
                        _cimentoText.text = 0 + "/" + 0;
                    }

                }
                else if (_duvar4 == false)
                {
                    if (_binaBolumleri[4].transform.FindChild("CIMENTO") != null)
                    {
                        if (_binaBolumleri[4].transform.FindChild("CIMENTO").transform.childCount > _cimentoCount - 1)
                        {
                            _binaBolumleri[4].transform.FindChild("CIMENTO").transform.GetChild(_cimentoCount - 1).gameObject.SetActive(true);
                            _cimentoText.text = _cimentoCount.ToString() + "/" + _binaBolumleri[4].transform.FindChild("CIMENTO").transform.childCount.ToString();
                        }
                        else
                        {
                            _cimentoText.text = _binaBolumleri[4].transform.FindChild("CIMENTO").transform.childCount.ToString() + "/" + _binaBolumleri[4].transform.FindChild("CIMENTO").transform.childCount.ToString();
                        }
                    }
                    else
                    {
                        _cimentoText.text = 0 + "/" + 0;
                    }

                }
                else if (_duvar5 == false)
                {
                    if (_binaBolumleri[5].transform.FindChild("CIMENTO") != null)
                    {
                        if (_binaBolumleri[5].transform.FindChild("CIMENTO").transform.childCount > _cimentoCount - 1)
                        {
                            _binaBolumleri[5].transform.FindChild("CIMENTO").transform.GetChild(_cimentoCount - 1).gameObject.SetActive(true);
                            _cimentoText.text = _cimentoCount.ToString() + "/" + _binaBolumleri[5].transform.FindChild("CIMENTO").transform.childCount.ToString();
                        }
                        else
                        {
                            _cimentoText.text = _binaBolumleri[5].transform.FindChild("CIMENTO").transform.childCount.ToString() + "/" + _binaBolumleri[5].transform.FindChild("CIMENTO").transform.childCount.ToString();
                        }
                    }
                    else
                    {
                        _cimentoText.text = 0 + "/" + 0;
                    }

                }
                else if (_cati1 == false)
                {
                    if (_binaBolumleri[6].transform.FindChild("CIMENTO") != null)
                    {
                        if (_binaBolumleri[6].transform.FindChild("CIMENTO").transform.childCount > _cimentoCount - 1)
                        {
                            _binaBolumleri[6].transform.FindChild("CIMENTO").transform.GetChild(_cimentoCount - 1).gameObject.SetActive(true);
                            _cimentoText.text = _cimentoCount.ToString() + "/" + _binaBolumleri[6].transform.FindChild("CIMENTO").transform.childCount.ToString();
                        }
                        else
                        {
                            _cimentoText.text = _binaBolumleri[6].transform.FindChild("CIMENTO").transform.childCount.ToString() + "/" + _binaBolumleri[6].transform.FindChild("CIMENTO").transform.childCount.ToString();
                        }
                    }
                    else
                    {
                        _cimentoText.text = 0 + "/" + 0;
                    }

                }
                else if (_cati2 == false)
                {
                    if (_binaBolumleri[7].transform.FindChild("CIMENTO") != null)
                    {
                        if (_binaBolumleri[7].transform.FindChild("CIMENTO").transform.childCount > _cimentoCount - 1)
                        {
                            _binaBolumleri[7].transform.FindChild("CIMENTO").transform.GetChild(_cimentoCount - 1).gameObject.SetActive(true);
                            _cimentoText.text = _cimentoCount.ToString() + "/" + _binaBolumleri[7].transform.FindChild("CIMENTO").transform.childCount.ToString();
                        }
                        else
                        {
                            _cimentoText.text = _binaBolumleri[7].transform.FindChild("CIMENTO").transform.childCount.ToString() + "/" + _binaBolumleri[7].transform.FindChild("CIMENTO").transform.childCount.ToString();
                        }
                    }
                    else
                    {
                        _cimentoText.text = 0 + "/" + 0;
                    }

                }
                else
                {

                }


                Debug.Log("Cimento Geldi");
            }
            else if (other.GetComponent<ParcalarScript>()._tugla)
            {
                _tuglaCount++;

                PlayerPrefs.SetInt("TuglaCount", _tuglaCount);

                if (_zemin == false)
                {
                    if (_binaBolumleri[0].transform.FindChild("TUGLA") != null)
                    {
                        if (_binaBolumleri[0].transform.FindChild("TUGLA").transform.childCount > _tuglaCount - 1)
                        {
                            _binaBolumleri[0].transform.FindChild("TUGLA").transform.GetChild(_tuglaCount - 1).gameObject.SetActive(true);
                            _tuglaText.text = _tuglaCount.ToString() + "/" + _binaBolumleri[0].transform.FindChild("TUGLA").transform.childCount.ToString();
                        }
                        else
                        {
                            _tuglaText.text = _binaBolumleri[0].transform.FindChild("TUGLA").transform.childCount.ToString() + "/" + _binaBolumleri[0].transform.FindChild("TUGLA").transform.childCount.ToString();
                        }
                    }
                    else
                    {
                        _tuglaText.text = 0 + "/" + 0;
                    }
                }
                else if (_duvar1 == false)
                {
                    if (_binaBolumleri[1].transform.FindChild("TUGLA") != null)
                    {
                        if (_binaBolumleri[1].transform.FindChild("TUGLA").transform.childCount > _tuglaCount - 1)
                        {
                            _binaBolumleri[1].transform.FindChild("TUGLA").transform.GetChild(_tuglaCount - 1).gameObject.SetActive(true);
                            _tuglaText.text = _tuglaCount.ToString() + "/" + _binaBolumleri[1].transform.FindChild("TUGLA").transform.childCount.ToString();
                        }
                        else
                        {
                            _tuglaText.text = _binaBolumleri[1].transform.FindChild("TUGLA").transform.childCount.ToString() + "/" + _binaBolumleri[1].transform.FindChild("TUGLA").transform.childCount.ToString();
                        }
                    }
                    else
                    {
                        _tuglaText.text = 0 + "/" + 0;
                    }

                }
                else if (_duvar2 == false)
                {
                    if (_binaBolumleri[2].transform.FindChild("TUGLA") != null)
                    {
                        if (_binaBolumleri[2].transform.FindChild("TUGLA").transform.childCount > _tuglaCount - 1)
                        {
                            _binaBolumleri[2].transform.FindChild("TUGLA").transform.GetChild(_tuglaCount - 1).gameObject.SetActive(true);
                            _tuglaText.text = _tuglaCount.ToString() + "/" + _binaBolumleri[2].transform.FindChild("TUGLA").transform.childCount.ToString();
                        }
                        else
                        {
                            _tuglaText.text = _binaBolumleri[2].transform.FindChild("TUGLA").transform.childCount.ToString() + "/" + _binaBolumleri[2].transform.FindChild("TUGLA").transform.childCount.ToString();
                        }
                    }
                    else
                    {
                        _tuglaText.text = 0 + "/" + 0;
                    }

                }
                else if (_duvar3 == false)
                {
                    if (_binaBolumleri[3].transform.FindChild("TUGLA") != null)
                    {
                        if (_binaBolumleri[3].transform.FindChild("TUGLA").transform.childCount > _tuglaCount - 1)
                        {
                            _binaBolumleri[3].transform.FindChild("TUGLA").transform.GetChild(_tuglaCount - 1).gameObject.SetActive(true);
                            _tuglaText.text = _tuglaCount.ToString() + "/" + _binaBolumleri[3].transform.FindChild("TUGLA").transform.childCount.ToString();
                        }
                        else
                        {
                            _tuglaText.text = _binaBolumleri[3].transform.FindChild("TUGLA").transform.childCount.ToString() + "/" + _binaBolumleri[3].transform.FindChild("TUGLA").transform.childCount.ToString();
                        }
                    }
                    else
                    {
                        _tuglaText.text = 0 + "/" + 0;
                    }

                }
                else if (_duvar4 == false)
                {
                    if (_binaBolumleri[4].transform.FindChild("TUGLA") != null)
                    {
                        if (_binaBolumleri[4].transform.FindChild("TUGLA").transform.childCount > _tuglaCount - 1)
                        {
                            _binaBolumleri[4].transform.FindChild("TUGLA").transform.GetChild(_tuglaCount - 1).gameObject.SetActive(true);
                            _tuglaText.text = _tuglaCount.ToString() + "/" + _binaBolumleri[4].transform.FindChild("TUGLA").transform.childCount.ToString();
                        }
                        else
                        {
                            _tuglaText.text = _binaBolumleri[4].transform.FindChild("TUGLA").transform.childCount.ToString() + "/" + _binaBolumleri[4].transform.FindChild("TUGLA").transform.childCount.ToString();
                        }
                    }
                    else
                    {
                        _tuglaText.text = 0 + "/" + 0;
                    }

                }
                else if (_duvar5 == false)
                {
                    if (_binaBolumleri[5].transform.FindChild("TUGLA") != null)
                    {
                        if (_binaBolumleri[5].transform.FindChild("TUGLA").transform.childCount > _tuglaCount - 1)
                        {
                            _binaBolumleri[5].transform.FindChild("TUGLA").transform.GetChild(_tuglaCount - 1).gameObject.SetActive(true);
                            _tuglaText.text = _tuglaCount.ToString() + "/" + _binaBolumleri[5].transform.FindChild("TUGLA").transform.childCount.ToString();
                        }
                        else
                        {
                            _tuglaText.text = _binaBolumleri[5].transform.FindChild("TUGLA").transform.childCount.ToString() + "/" + _binaBolumleri[5].transform.FindChild("TUGLA").transform.childCount.ToString();
                        }
                    }
                    else
                    {
                        _tuglaText.text = 0 + "/" + 0;
                    }

                }
                else if (_cati1 == false)
                {
                    if (_binaBolumleri[6].transform.FindChild("TUGLA") != null)
                    {
                        if (_binaBolumleri[6].transform.FindChild("TUGLA").transform.childCount > _tuglaCount - 1)
                        {
                            _binaBolumleri[6].transform.FindChild("TUGLA").transform.GetChild(_tuglaCount - 1).gameObject.SetActive(true);
                            _tuglaText.text = _tuglaCount.ToString() + "/" + _binaBolumleri[6].transform.FindChild("TUGLA").transform.childCount.ToString();
                        }
                        else
                        {
                            _tuglaText.text = _binaBolumleri[6].transform.FindChild("TUGLA").transform.childCount.ToString() + "/" + _binaBolumleri[6].transform.FindChild("TUGLA").transform.childCount.ToString();
                        }
                    }
                    else
                    {
                        _tuglaText.text = 0 + "/" + 0;
                    }

                }
                else if (_cati2 == false)
                {
                    if (_binaBolumleri[7].transform.FindChild("TUGLA") != null)
                    {
                        if (_binaBolumleri[7].transform.FindChild("TUGLA").transform.childCount > _tuglaCount - 1)
                        {
                            _binaBolumleri[7].transform.FindChild("TUGLA").transform.GetChild(_tuglaCount - 1).gameObject.SetActive(true);
                            _tuglaText.text = _tuglaCount.ToString() + "/" + _binaBolumleri[7].transform.FindChild("TUGLA").transform.childCount.ToString();
                        }
                        else
                        {
                            _tuglaText.text = _binaBolumleri[7].transform.FindChild("TUGLA").transform.childCount.ToString() + "/" + _binaBolumleri[7].transform.FindChild("TUGLA").transform.childCount.ToString();
                        }
                    }
                    else
                    {
                        _tuglaText.text = 0 + "/" + 0;
                    }

                }
                else
                {

                }


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

    [Obsolete]
    private void CheckObjects()
    {
        if (_zemin == false)
        {
            if (_binaBolumleri[0].transform.FindChild("TAHTA").transform.childCount <= _tahtaCount && _binaBolumleri[0].transform.FindChild("CIMENTO").transform.childCount <= _cimentoCount)
            {
                _zemin = true;
                OpenZeminAnim();
                _tahtaCount = 0;
                _cimentoCount = 0;
                _tuglaCount = 0;
                PlayerPrefs.SetInt("ZeminTamam", 1);

                PlayerPrefs.SetInt("TahtaCount", _tahtaCount);
                PlayerPrefs.SetInt("CimentoCount", _cimentoCount);
                PlayerPrefs.SetInt("TuglaCount", _tuglaCount);


                if (_binaBolumleri[1].transform.FindChild("TAHTA") != null)
                {

                    _tahtaText.text = 0 + "/" + _binaBolumleri[1].transform.FindChild("TAHTA").transform.childCount.ToString();

                }
                else
                {
                    _tahtaText.text = 0 + "/" + 0;
                }

                if (_binaBolumleri[1].transform.FindChild("CIMENTO") != null)
                {

                    _cimentoText.text = 0 + "/" + _binaBolumleri[1].transform.FindChild("CIMENTO").transform.childCount.ToString();

                }
                else
                {
                    _cimentoText.text = 0 + "/" + 0;
                }

                if (_binaBolumleri[1].transform.FindChild("TUGLA") != null)
                {

                    _tuglaText.text = 0 + "/" + _binaBolumleri[1].transform.FindChild("TUGLA").transform.childCount.ToString();

                }
                else
                {
                    _tuglaText.text = 0 + "/" + 0;
                }

            }
            else
            {

            }
        }
        else if (_duvar1 == false)
        {
            if (_binaBolumleri[1].transform.FindChild("TAHTA").transform.childCount <= _tahtaCount && _binaBolumleri[1].transform.FindChild("CIMENTO").transform.childCount <= _cimentoCount && _binaBolumleri[1].transform.FindChild("TUGLA").transform.childCount <= _tuglaCount)
            {
                _duvar1 = true;
                // OpenZeminAnim();
                _tahtaCount = 0;
                _cimentoCount = 0;
                _tuglaCount = 0;
                PlayerPrefs.SetInt("Duvar1Tamam", 1);

                PlayerPrefs.SetInt("TahtaCount", _tahtaCount);
                PlayerPrefs.SetInt("CimentoCount", _cimentoCount);
                PlayerPrefs.SetInt("TuglaCount", _tuglaCount);


                if (_binaBolumleri[2].transform.FindChild("TAHTA") != null)
                {

                    _tahtaText.text = 0 + "/" + _binaBolumleri[2].transform.FindChild("TAHTA").transform.childCount.ToString();

                }
                else
                {
                    _tahtaText.text = 0 + "/" + 0;
                }

                if (_binaBolumleri[2].transform.FindChild("CIMENTO") != null)
                {

                    _cimentoText.text = 0 + "/" + _binaBolumleri[2].transform.FindChild("CIMENTO").transform.childCount.ToString();

                }
                else
                {
                    _cimentoText.text = 0 + "/" + 0;
                }

                if (_binaBolumleri[2].transform.FindChild("TUGLA") != null)
                {

                    _tuglaText.text = 0 + "/" + _binaBolumleri[2].transform.FindChild("TUGLA").transform.childCount.ToString();

                }
                else
                {
                    _tuglaText.text = 0 + "/" + 0;
                }


            }
            else
            {

            }
        }
        else if (_duvar2 == false)
        {
            if (_binaBolumleri[2].transform.FindChild("TAHTA").transform.childCount <= _tahtaCount && _binaBolumleri[2].transform.FindChild("CIMENTO").transform.childCount <= _cimentoCount && _binaBolumleri[2].transform.FindChild("TUGLA").transform.childCount <= _tuglaCount)
            {
                _duvar2 = true;
                // OpenZeminAnim();
                _tahtaCount = 0;
                _cimentoCount = 0;
                _tuglaCount = 0;
                PlayerPrefs.SetInt("Duvar2Tamam", 1);

                PlayerPrefs.SetInt("TahtaCount", _tahtaCount);
                PlayerPrefs.SetInt("CimentoCount", _cimentoCount);
                PlayerPrefs.SetInt("TuglaCount", _tuglaCount);


                if (_binaBolumleri[3].transform.FindChild("TAHTA") != null)
                {

                    _tahtaText.text = 0 + "/" + _binaBolumleri[3].transform.FindChild("TAHTA").transform.childCount.ToString();

                }
                else
                {
                    _tahtaText.text = 0 + "/" + 0;
                }

                if (_binaBolumleri[3].transform.FindChild("CIMENTO") != null)
                {

                    _cimentoText.text = 0 + "/" + _binaBolumleri[3].transform.FindChild("CIMENTO").transform.childCount.ToString();

                }
                else
                {
                    _cimentoText.text = 0 + "/" + 0;
                }

                if (_binaBolumleri[3].transform.FindChild("TUGLA") != null)
                {

                    _tuglaText.text = 0 + "/" + _binaBolumleri[3].transform.FindChild("TUGLA").transform.childCount.ToString();

                }
                else
                {
                    _tuglaText.text = 0 + "/" + 0;
                }


            }
            else
            {

            }
        }
        else if (_duvar3 == false)
        {
            if (_binaBolumleri[3].transform.FindChild("TAHTA").transform.childCount <= _tahtaCount && _binaBolumleri[3].transform.FindChild("CIMENTO").transform.childCount <= _cimentoCount && _binaBolumleri[3].transform.FindChild("TUGLA").transform.childCount <= _tuglaCount)
            {
                _duvar3 = true;
                // OpenZeminAnim();
                _tahtaCount = 0;
                _cimentoCount = 0;
                _tuglaCount = 0;
                PlayerPrefs.SetInt("Duvar3Tamam", 1);

                PlayerPrefs.SetInt("TahtaCount", _tahtaCount);
                PlayerPrefs.SetInt("CimentoCount", _cimentoCount);
                PlayerPrefs.SetInt("TuglaCount", _tuglaCount);


                if (_binaBolumleri[4].transform.FindChild("TAHTA") != null)
                {

                    _tahtaText.text = 0 + "/" + _binaBolumleri[4].transform.FindChild("TAHTA").transform.childCount.ToString();

                }
                else
                {
                    _tahtaText.text = 0 + "/" + 0;
                }

                if (_binaBolumleri[4].transform.FindChild("CIMENTO") != null)
                {

                    _cimentoText.text = 0 + "/" + _binaBolumleri[4].transform.FindChild("CIMENTO").transform.childCount.ToString();

                }
                else
                {
                    _cimentoText.text = 0 + "/" + 0;
                }

                if (_binaBolumleri[4].transform.FindChild("TUGLA") != null)
                {

                    _tuglaText.text = 0 + "/" + _binaBolumleri[4].transform.FindChild("TUGLA").transform.childCount.ToString();

                }
                else
                {
                    _tuglaText.text = 0 + "/" + 0;
                }


            }
            else
            {

            }
        }
        else if (_duvar4 == false)
        {
            if (_binaBolumleri[4].transform.FindChild("TAHTA").transform.childCount <= _tahtaCount && _binaBolumleri[4].transform.FindChild("CIMENTO").transform.childCount <= _cimentoCount && _binaBolumleri[4].transform.FindChild("TUGLA").transform.childCount <= _tuglaCount)
            {
                _duvar4 = true;
                // OpenZeminAnim();
                _tahtaCount = 0;
                _cimentoCount = 0;
                _tuglaCount = 0;
                PlayerPrefs.SetInt("Duvar4Tamam", 1);

                PlayerPrefs.SetInt("TahtaCount", _tahtaCount);
                PlayerPrefs.SetInt("CimentoCount", _cimentoCount);
                PlayerPrefs.SetInt("TuglaCount", _tuglaCount);


                if (_binaBolumleri[5].transform.FindChild("TAHTA") != null)
                {

                    _tahtaText.text = 0 + "/" + _binaBolumleri[5].transform.FindChild("TAHTA").transform.childCount.ToString();

                }
                else
                {
                    _tahtaText.text = 0 + "/" + 0;
                }

                if (_binaBolumleri[5].transform.FindChild("CIMENTO") != null)
                {

                    _cimentoText.text = 0 + "/" + _binaBolumleri[5].transform.FindChild("CIMENTO").transform.childCount.ToString();

                }
                else
                {
                    _cimentoText.text = 0 + "/" + 0;
                }

                if (_binaBolumleri[5].transform.FindChild("TUGLA") != null)
                {

                    _tuglaText.text = 0 + "/" + _binaBolumleri[5].transform.FindChild("TUGLA").transform.childCount.ToString();

                }
                else
                {
                    _tuglaText.text = 0 + "/" + 0;
                }


            }
            else
            {

            }
        }
        else if (_duvar5 == false)
        {
            if (_binaBolumleri[5].transform.FindChild("TAHTA").transform.childCount <= _tahtaCount && _binaBolumleri[5].transform.FindChild("CIMENTO").transform.childCount <= _cimentoCount && _binaBolumleri[5].transform.FindChild("TUGLA").transform.childCount <= _tuglaCount)
            {
                _duvar5 = true;
                OpenDuvarAnim();
                _tahtaCount = 0;
                _cimentoCount = 0;
                _tuglaCount = 0;
                PlayerPrefs.SetInt("Duvar5Tamam", 1);

                PlayerPrefs.SetInt("TahtaCount", _tahtaCount);
                PlayerPrefs.SetInt("CimentoCount", _cimentoCount);
                PlayerPrefs.SetInt("TuglaCount", _tuglaCount);


                if (_binaBolumleri[6].transform.FindChild("TAHTA") != null)
                {

                    _tahtaText.text = 0 + "/" + _binaBolumleri[6].transform.FindChild("TAHTA").transform.childCount.ToString();

                }
                else
                {
                    _tahtaText.text = 0 + "/" + 0;
                }

                if (_binaBolumleri[6].transform.FindChild("CIMENTO") != null)
                {

                    _cimentoText.text = 0 + "/" + _binaBolumleri[6].transform.FindChild("CIMENTO").transform.childCount.ToString();

                }
                else
                {
                    _cimentoText.text = 0 + "/" + 0;
                }

                if (_binaBolumleri[6].transform.FindChild("TUGLA") != null)
                {

                    _tuglaText.text = 0 + "/" + _binaBolumleri[6].transform.FindChild("TUGLA").transform.childCount.ToString();

                }
                else
                {
                    _tuglaText.text = 0 + "/" + 0;
                }


            }
            else
            {

            }
        }
        else if (_cati1 == false)
        {
            if (_binaBolumleri[6].transform.FindChild("TAHTA").transform.childCount <= _tahtaCount && _binaBolumleri[6].transform.FindChild("TUGLA").transform.childCount <= _tuglaCount)
            {
                _cati1 = true;
                //OpenDuvarAnim();
                _tahtaCount = 0;
                _cimentoCount = 0;
                _tuglaCount = 0;
                PlayerPrefs.SetInt("Cati1Tamam", 1);

                PlayerPrefs.SetInt("TahtaCount", _tahtaCount);
                PlayerPrefs.SetInt("CimentoCount", _cimentoCount);
                PlayerPrefs.SetInt("TuglaCount", _tuglaCount);


                if (_binaBolumleri[7].transform.FindChild("TAHTA") != null)
                {

                    _tahtaText.text = 0 + "/" + _binaBolumleri[7].transform.FindChild("TAHTA").transform.childCount.ToString();

                }
                else
                {
                    _tahtaText.text = 0 + "/" + 0;
                }

                if (_binaBolumleri[7].transform.FindChild("CIMENTO") != null)
                {

                    _cimentoText.text = 0 + "/" + _binaBolumleri[7].transform.FindChild("CIMENTO").transform.childCount.ToString();

                }
                else
                {
                    _cimentoText.text = 0 + "/" + 0;
                }

                if (_binaBolumleri[7].transform.FindChild("TUGLA") != null)
                {

                    _tuglaText.text = 0 + "/" + _binaBolumleri[7].transform.FindChild("TUGLA").transform.childCount.ToString();

                }
                else
                {
                    _tuglaText.text = 0 + "/" + 0;
                }


            }
            else
            {

            }
        }
        else if (_cati2 == false)
        {
            if (_binaBolumleri[7].transform.FindChild("TAHTA").transform.childCount <= _tahtaCount && _binaBolumleri[7].transform.FindChild("TUGLA").transform.childCount <= _tuglaCount)
            {
                _cati2 = true;
                _binaBitti = true;
                FinishHouse();
                _tahtaCount = 0;
                _cimentoCount = 0;
                _tuglaCount = 0;
                PlayerPrefs.SetInt("Cati2Tamam", 1);

                PlayerPrefs.SetInt("TahtaCount", _tahtaCount);
                PlayerPrefs.SetInt("CimentoCount", _cimentoCount);
                PlayerPrefs.SetInt("TuglaCount", _tuglaCount);
            }
            else
            {

            }
        }
        else
        {

        }


        //PlayerPrefs.Save();


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

    [Obsolete]
    private void SavingSystem()
    {
        if (_zeminTamam == 1)
        {
            _zemin = true;
            OpenZeminAnim();

            if (_binaBolumleri[0].transform.FindChild("TAHTA") != null)
            {
                if (_binaBolumleri[0].transform.FindChild("TAHTA").transform.childCount > _tahtaCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("TAHTA").transform.GetChild(_tahtaCount - 1).gameObject.SetActive(true);
                    _tahtaText.text = _tahtaCount.ToString() + "/" + _binaBolumleri[0].transform.FindChild("TAHTA").transform.childCount.ToString();
                }
                else
                {
                    _tahtaText.text = _binaBolumleri[0].transform.FindChild("TAHTA").transform.childCount.ToString() + "/" + _binaBolumleri[0].transform.FindChild("TAHTA").transform.childCount.ToString();
                }
            }
            else
            {
                _tahtaText.text = 0 + "/" + 0;
            }

            if (_binaBolumleri[0].transform.FindChild("CIMENTO") != null)
            {
                if (_binaBolumleri[0].transform.FindChild("CIMENTO").transform.childCount > _cimentoCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("CIMENTO").transform.GetChild(_cimentoCount - 1).gameObject.SetActive(true);
                    _cimentoText.text = _cimentoCount.ToString() + "/" + _binaBolumleri[0].transform.FindChild("CIMENTO").transform.childCount.ToString();
                }
                else
                {
                    _cimentoText.text = _binaBolumleri[0].transform.FindChild("CIMENTO").transform.childCount.ToString() + "/" + _binaBolumleri[0].transform.FindChild("CIMENTO").transform.childCount.ToString();
                }
            }
            else
            {
                _cimentoText.text = 0 + "/" + 0;
            }

            if (_binaBolumleri[0].transform.FindChild("TUGLA") != null)
            {
                if (_binaBolumleri[0].transform.FindChild("TUGLA").transform.childCount > _tuglaCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("TUGLA").transform.GetChild(_tuglaCount - 1).gameObject.SetActive(true);
                    _tuglaText.text = _tuglaCount.ToString() + "/" + _binaBolumleri[0].transform.FindChild("TUGLA").transform.childCount.ToString();
                }
                else
                {
                    _tuglaText.text = _binaBolumleri[0].transform.FindChild("TUGLA").transform.childCount.ToString() + "/" + _binaBolumleri[0].transform.FindChild("TUGLA").transform.childCount.ToString();
                }
            }
            else
            {
                _tuglaText.text = 0 + "/" + 0;
            }
        }
        else
        {
            _zemin = false;

            for (int i = 0; i < _tahtaCount; i++)
            {
                if (_binaBolumleri[0].transform.FindChild("TAHTA") != null)
                {
                    if (_binaBolumleri[0].transform.FindChild("TAHTA").transform.childCount > i)
                    {
                        _binaBolumleri[0].transform.FindChild("TAHTA").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }


            for (int i = 0; i < _cimentoCount; i++)
            {
                if (_binaBolumleri[0].transform.FindChild("CIMENTO") != null)
                {
                    if (_binaBolumleri[0].transform.FindChild("CIMENTO").transform.childCount > i)
                    {
                        _binaBolumleri[0].transform.FindChild("CIMENTO").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }


            for (int i = 0; i < _tuglaCount; i++)
            {
                if (_binaBolumleri[0].transform.FindChild("TUGLA") != null)
                {
                    if (_binaBolumleri[0].transform.FindChild("TUGLA").transform.childCount > i)
                    {
                        _binaBolumleri[0].transform.FindChild("TUGLA").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }

            if (_binaBolumleri[0].transform.FindChild("TAHTA") != null)
            {
                if (_binaBolumleri[0].transform.FindChild("TAHTA").transform.childCount > _tahtaCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("TAHTA").transform.GetChild(_tahtaCount - 1).gameObject.SetActive(true);
                    _tahtaText.text = _tahtaCount.ToString() + "/" + _binaBolumleri[0].transform.FindChild("TAHTA").transform.childCount.ToString();
                }
                else
                {
                    _tahtaText.text = _binaBolumleri[0].transform.FindChild("TAHTA").transform.childCount.ToString() + "/" + _binaBolumleri[0].transform.FindChild("TAHTA").transform.childCount.ToString();
                }
            }
            else
            {
                _tahtaText.text = 0 + "/" + 0;
            }

            if (_binaBolumleri[0].transform.FindChild("CIMENTO") != null)
            {
                if (_binaBolumleri[0].transform.FindChild("CIMENTO").transform.childCount > _cimentoCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("CIMENTO").transform.GetChild(_cimentoCount - 1).gameObject.SetActive(true);
                    _cimentoText.text = _cimentoCount.ToString() + "/" + _binaBolumleri[0].transform.FindChild("CIMENTO").transform.childCount.ToString();
                }
                else
                {
                    _cimentoText.text = _binaBolumleri[0].transform.FindChild("CIMENTO").transform.childCount.ToString() + "/" + _binaBolumleri[0].transform.FindChild("CIMENTO").transform.childCount.ToString();
                }
            }
            else
            {
                _cimentoText.text = 0 + "/" + 0;
            }

            if (_binaBolumleri[0].transform.FindChild("TUGLA") != null)
            {
                if (_binaBolumleri[0].transform.FindChild("TUGLA").transform.childCount > _tuglaCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("TUGLA").transform.GetChild(_tuglaCount - 1).gameObject.SetActive(true);
                    _tuglaText.text = _tuglaCount.ToString() + "/" + _binaBolumleri[0].transform.FindChild("TUGLA").transform.childCount.ToString();
                }
                else
                {
                    _tuglaText.text = _binaBolumleri[0].transform.FindChild("TUGLA").transform.childCount.ToString() + "/" + _binaBolumleri[0].transform.FindChild("TUGLA").transform.childCount.ToString();
                }
            }
            else
            {
                _tuglaText.text = 0 + "/" + 0;
            }


        }


        if (_duvar1Tamam == 1)
        {
            _duvar1 = true;

            for (int i = 0; i < _binaBolumleri[1].transform.FindChild("TAHTA").transform.childCount; i++)
            {
                if (_binaBolumleri[1].transform.FindChild("TAHTA") != null)
                {
                    if (_binaBolumleri[1].transform.FindChild("TAHTA").transform.childCount > i)
                    {
                        _binaBolumleri[1].transform.FindChild("TAHTA").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }


            for (int i = 0; i < _binaBolumleri[1].transform.FindChild("CIMENTO").transform.childCount; i++)
            {
                if (_binaBolumleri[1].transform.FindChild("CIMENTO") != null)
                {
                    if (_binaBolumleri[1].transform.FindChild("CIMENTO").transform.childCount > i)
                    {
                        _binaBolumleri[1].transform.FindChild("CIMENTO").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }


            for (int i = 0; i < _binaBolumleri[1].transform.FindChild("TUGLA").transform.childCount; i++)
            {
                if (_binaBolumleri[1].transform.FindChild("TUGLA") != null)
                {
                    if (_binaBolumleri[1].transform.FindChild("TUGLA").transform.childCount > i)
                    {
                        _binaBolumleri[1].transform.FindChild("TUGLA").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }


            if (_binaBolumleri[1].transform.FindChild("TAHTA") != null)
            {
                if (_binaBolumleri[1].transform.FindChild("TAHTA").transform.childCount > _tahtaCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("TAHTA").transform.GetChild(_tahtaCount - 1).gameObject.SetActive(true);
                    _tahtaText.text = _tahtaCount.ToString() + "/" + _binaBolumleri[1].transform.FindChild("TAHTA").transform.childCount.ToString();
                }
                else
                {
                    _tahtaText.text = _binaBolumleri[1].transform.FindChild("TAHTA").transform.childCount.ToString() + "/" + _binaBolumleri[1].transform.FindChild("TAHTA").transform.childCount.ToString();
                }
            }
            else
            {
                _tahtaText.text = 0 + "/" + 0;
            }

            if (_binaBolumleri[1].transform.FindChild("CIMENTO") != null)
            {
                if (_binaBolumleri[1].transform.FindChild("CIMENTO").transform.childCount > _cimentoCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("CIMENTO").transform.GetChild(_cimentoCount - 1).gameObject.SetActive(true);
                    _cimentoText.text = _cimentoCount.ToString() + "/" + _binaBolumleri[1].transform.FindChild("CIMENTO").transform.childCount.ToString();
                }
                else
                {
                    _cimentoText.text = _binaBolumleri[1].transform.FindChild("CIMENTO").transform.childCount.ToString() + "/" + _binaBolumleri[1].transform.FindChild("CIMENTO").transform.childCount.ToString();
                }
            }
            else
            {
                _cimentoText.text = 0 + "/" + 0;
            }

            if (_binaBolumleri[1].transform.FindChild("TUGLA") != null)
            {
                if (_binaBolumleri[1].transform.FindChild("TUGLA").transform.childCount > _tuglaCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("TUGLA").transform.GetChild(_tuglaCount - 1).gameObject.SetActive(true);
                    _tuglaText.text = _tuglaCount.ToString() + "/" + _binaBolumleri[1].transform.FindChild("TUGLA").transform.childCount.ToString();
                }
                else
                {
                    _tuglaText.text = _binaBolumleri[1].transform.FindChild("TUGLA").transform.childCount.ToString() + "/" + _binaBolumleri[1].transform.FindChild("TUGLA").transform.childCount.ToString();
                }
            }
            else
            {
                _tuglaText.text = 0 + "/" + 0;
            }


        }
        else if (_zeminTamam == 1 && _duvar1Tamam == 0)
        {
            _duvar1 = false;

            for (int i = 0; i < _tahtaCount; i++)
            {
                if (_binaBolumleri[1].transform.FindChild("TAHTA") != null)
                {
                    if (_binaBolumleri[1].transform.FindChild("TAHTA").transform.childCount > i)
                    {
                        _binaBolumleri[1].transform.FindChild("TAHTA").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }


            for (int i = 0; i < _cimentoCount; i++)
            {
                if (_binaBolumleri[1].transform.FindChild("CIMENTO") != null)
                {
                    if (_binaBolumleri[1].transform.FindChild("CIMENTO").transform.childCount > i)
                    {
                        _binaBolumleri[1].transform.FindChild("CIMENTO").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }


            for (int i = 0; i < _tuglaCount; i++)
            {
                if (_binaBolumleri[1].transform.FindChild("TUGLA") != null)
                {
                    if (_binaBolumleri[1].transform.FindChild("TUGLA").transform.childCount > i)
                    {
                        _binaBolumleri[1].transform.FindChild("TUGLA").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }


            if (_binaBolumleri[1].transform.FindChild("TAHTA") != null)
            {
                if (_binaBolumleri[1].transform.FindChild("TAHTA").transform.childCount > _tahtaCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("TAHTA").transform.GetChild(_tahtaCount - 1).gameObject.SetActive(true);
                    _tahtaText.text = _tahtaCount.ToString() + "/" + _binaBolumleri[1].transform.FindChild("TAHTA").transform.childCount.ToString();
                }
                else
                {
                    _tahtaText.text = _binaBolumleri[1].transform.FindChild("TAHTA").transform.childCount.ToString() + "/" + _binaBolumleri[1].transform.FindChild("TAHTA").transform.childCount.ToString();
                }
            }
            else
            {
                _tahtaText.text = 0 + "/" + 0;
            }

            if (_binaBolumleri[1].transform.FindChild("CIMENTO") != null)
            {
                if (_binaBolumleri[1].transform.FindChild("CIMENTO").transform.childCount > _cimentoCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("CIMENTO").transform.GetChild(_cimentoCount - 1).gameObject.SetActive(true);
                    _cimentoText.text = _cimentoCount.ToString() + "/" + _binaBolumleri[1].transform.FindChild("CIMENTO").transform.childCount.ToString();
                }
                else
                {
                    _cimentoText.text = _binaBolumleri[1].transform.FindChild("CIMENTO").transform.childCount.ToString() + "/" + _binaBolumleri[1].transform.FindChild("CIMENTO").transform.childCount.ToString();
                }
            }
            else
            {
                _cimentoText.text = 0 + "/" + 0;
            }

            if (_binaBolumleri[1].transform.FindChild("TUGLA") != null)
            {
                if (_binaBolumleri[1].transform.FindChild("TUGLA").transform.childCount > _tuglaCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("TUGLA").transform.GetChild(_tuglaCount - 1).gameObject.SetActive(true);
                    _tuglaText.text = _tuglaCount.ToString() + "/" + _binaBolumleri[1].transform.FindChild("TUGLA").transform.childCount.ToString();
                }
                else
                {
                    _tuglaText.text = _binaBolumleri[1].transform.FindChild("TUGLA").transform.childCount.ToString() + "/" + _binaBolumleri[1].transform.FindChild("TUGLA").transform.childCount.ToString();
                }
            }
            else
            {
                _tuglaText.text = 0 + "/" + 0;
            }


        }


        if (_duvar2Tamam == 1)
        {
            _duvar2 = true;

            for (int i = 0; i < _binaBolumleri[2].transform.FindChild("TAHTA").transform.childCount; i++)
            {
                if (_binaBolumleri[2].transform.FindChild("TAHTA") != null)
                {
                    if (_binaBolumleri[2].transform.FindChild("TAHTA").transform.childCount > i)
                    {
                        _binaBolumleri[2].transform.FindChild("TAHTA").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }


            for (int i = 0; i < _binaBolumleri[2].transform.FindChild("CIMENTO").transform.childCount; i++)
            {
                if (_binaBolumleri[2].transform.FindChild("CIMENTO") != null)
                {
                    if (_binaBolumleri[2].transform.FindChild("CIMENTO").transform.childCount > i)
                    {
                        _binaBolumleri[2].transform.FindChild("CIMENTO").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }


            for (int i = 0; i < _binaBolumleri[2].transform.FindChild("TUGLA").transform.childCount; i++)
            {
                if (_binaBolumleri[2].transform.FindChild("TUGLA") != null)
                {
                    if (_binaBolumleri[2].transform.FindChild("TUGLA").transform.childCount > i)
                    {
                        _binaBolumleri[2].transform.FindChild("TUGLA").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }


            if (_binaBolumleri[2].transform.FindChild("TAHTA") != null)
            {
                if (_binaBolumleri[2].transform.FindChild("TAHTA").transform.childCount > _tahtaCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("TAHTA").transform.GetChild(_tahtaCount - 1).gameObject.SetActive(true);
                    _tahtaText.text = _tahtaCount.ToString() + "/" + _binaBolumleri[2].transform.FindChild("TAHTA").transform.childCount.ToString();
                }
                else
                {
                    _tahtaText.text = _binaBolumleri[2].transform.FindChild("TAHTA").transform.childCount.ToString() + "/" + _binaBolumleri[2].transform.FindChild("TAHTA").transform.childCount.ToString();
                }
            }
            else
            {
                _tahtaText.text = 0 + "/" + 0;
            }

            if (_binaBolumleri[2].transform.FindChild("CIMENTO") != null)
            {
                if (_binaBolumleri[2].transform.FindChild("CIMENTO").transform.childCount > _cimentoCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("CIMENTO").transform.GetChild(_cimentoCount - 1).gameObject.SetActive(true);
                    _cimentoText.text = _cimentoCount.ToString() + "/" + _binaBolumleri[2].transform.FindChild("CIMENTO").transform.childCount.ToString();
                }
                else
                {
                    _cimentoText.text = _binaBolumleri[2].transform.FindChild("CIMENTO").transform.childCount.ToString() + "/" + _binaBolumleri[2].transform.FindChild("CIMENTO").transform.childCount.ToString();
                }
            }
            else
            {
                _cimentoText.text = 0 + "/" + 0;
            }

            if (_binaBolumleri[2].transform.FindChild("TUGLA") != null)
            {
                if (_binaBolumleri[2].transform.FindChild("TUGLA").transform.childCount > _tuglaCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("TUGLA").transform.GetChild(_tuglaCount - 1).gameObject.SetActive(true);
                    _tuglaText.text = _tuglaCount.ToString() + "/" + _binaBolumleri[2].transform.FindChild("TUGLA").transform.childCount.ToString();
                }
                else
                {
                    _tuglaText.text = _binaBolumleri[2].transform.FindChild("TUGLA").transform.childCount.ToString() + "/" + _binaBolumleri[2].transform.FindChild("TUGLA").transform.childCount.ToString();
                }
            }
            else
            {
                _tuglaText.text = 0 + "/" + 0;
            }



        }
        else if (_duvar1Tamam == 1 && _duvar2Tamam == 0)
        {
            _duvar2 = false;

            for (int i = 0; i < _tahtaCount; i++)
            {
                if (_binaBolumleri[2].transform.FindChild("TAHTA") != null)
                {
                    if (_binaBolumleri[2].transform.FindChild("TAHTA").transform.childCount > i)
                    {
                        _binaBolumleri[2].transform.FindChild("TAHTA").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }


            for (int i = 0; i < _cimentoCount; i++)
            {
                if (_binaBolumleri[2].transform.FindChild("CIMENTO") != null)
                {
                    if (_binaBolumleri[2].transform.FindChild("CIMENTO").transform.childCount > i)
                    {
                        _binaBolumleri[2].transform.FindChild("CIMENTO").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }


            for (int i = 0; i < _tuglaCount; i++)
            {
                if (_binaBolumleri[2].transform.FindChild("TUGLA") != null)
                {
                    if (_binaBolumleri[2].transform.FindChild("TUGLA").transform.childCount > i)
                    {
                        _binaBolumleri[2].transform.FindChild("TUGLA").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }


            if (_binaBolumleri[2].transform.FindChild("TAHTA") != null)
            {
                if (_binaBolumleri[2].transform.FindChild("TAHTA").transform.childCount > _tahtaCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("TAHTA").transform.GetChild(_tahtaCount - 1).gameObject.SetActive(true);
                    _tahtaText.text = _tahtaCount.ToString() + "/" + _binaBolumleri[2].transform.FindChild("TAHTA").transform.childCount.ToString();
                }
                else
                {
                    _tahtaText.text = _binaBolumleri[2].transform.FindChild("TAHTA").transform.childCount.ToString() + "/" + _binaBolumleri[2].transform.FindChild("TAHTA").transform.childCount.ToString();
                }
            }
            else
            {
                _tahtaText.text = 0 + "/" + 0;
            }

            if (_binaBolumleri[2].transform.FindChild("CIMENTO") != null)
            {
                if (_binaBolumleri[2].transform.FindChild("CIMENTO").transform.childCount > _cimentoCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("CIMENTO").transform.GetChild(_cimentoCount - 1).gameObject.SetActive(true);
                    _cimentoText.text = _cimentoCount.ToString() + "/" + _binaBolumleri[2].transform.FindChild("CIMENTO").transform.childCount.ToString();
                }
                else
                {
                    _cimentoText.text = _binaBolumleri[2].transform.FindChild("CIMENTO").transform.childCount.ToString() + "/" + _binaBolumleri[2].transform.FindChild("CIMENTO").transform.childCount.ToString();
                }
            }
            else
            {
                _cimentoText.text = 0 + "/" + 0;
            }

            if (_binaBolumleri[2].transform.FindChild("TUGLA") != null)
            {
                if (_binaBolumleri[2].transform.FindChild("TUGLA").transform.childCount > _tuglaCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("TUGLA").transform.GetChild(_tuglaCount - 1).gameObject.SetActive(true);
                    _tuglaText.text = _tuglaCount.ToString() + "/" + _binaBolumleri[2].transform.FindChild("TUGLA").transform.childCount.ToString();
                }
                else
                {
                    _tuglaText.text = _binaBolumleri[2].transform.FindChild("TUGLA").transform.childCount.ToString() + "/" + _binaBolumleri[2].transform.FindChild("TUGLA").transform.childCount.ToString();
                }
            }
            else
            {
                _tuglaText.text = 0 + "/" + 0;
            }



        }


        if (_duvar3Tamam == 1)
        {
            _duvar3 = true;

            for (int i = 0; i < _binaBolumleri[3].transform.FindChild("TAHTA").transform.childCount; i++)
            {
                if (_binaBolumleri[3].transform.FindChild("TAHTA") != null)
                {
                    if (_binaBolumleri[3].transform.FindChild("TAHTA").transform.childCount > i)
                    {
                        _binaBolumleri[3].transform.FindChild("TAHTA").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }


            for (int i = 0; i < _binaBolumleri[3].transform.FindChild("CIMENTO").transform.childCount; i++)
            {
                if (_binaBolumleri[3].transform.FindChild("CIMENTO") != null)
                {
                    if (_binaBolumleri[3].transform.FindChild("CIMENTO").transform.childCount > i)
                    {
                        _binaBolumleri[3].transform.FindChild("CIMENTO").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }


            for (int i = 0; i < _binaBolumleri[3].transform.FindChild("TUGLA").transform.childCount; i++)
            {
                if (_binaBolumleri[3].transform.FindChild("TUGLA") != null)
                {
                    if (_binaBolumleri[3].transform.FindChild("TUGLA").transform.childCount > i)
                    {
                        _binaBolumleri[3].transform.FindChild("TUGLA").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }


            if (_binaBolumleri[3].transform.FindChild("TAHTA") != null)
            {
                if (_binaBolumleri[3].transform.FindChild("TAHTA").transform.childCount > _tahtaCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("TAHTA").transform.GetChild(_tahtaCount - 1).gameObject.SetActive(true);
                    _tahtaText.text = _tahtaCount.ToString() + "/" + _binaBolumleri[3].transform.FindChild("TAHTA").transform.childCount.ToString();
                }
                else
                {
                    _tahtaText.text = _binaBolumleri[3].transform.FindChild("TAHTA").transform.childCount.ToString() + "/" + _binaBolumleri[3].transform.FindChild("TAHTA").transform.childCount.ToString();
                }
            }
            else
            {
                _tahtaText.text = 0 + "/" + 0;
            }

            if (_binaBolumleri[3].transform.FindChild("CIMENTO") != null)
            {
                if (_binaBolumleri[3].transform.FindChild("CIMENTO").transform.childCount > _cimentoCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("CIMENTO").transform.GetChild(_cimentoCount - 1).gameObject.SetActive(true);
                    _cimentoText.text = _cimentoCount.ToString() + "/" + _binaBolumleri[3].transform.FindChild("CIMENTO").transform.childCount.ToString();
                }
                else
                {
                    _cimentoText.text = _binaBolumleri[3].transform.FindChild("CIMENTO").transform.childCount.ToString() + "/" + _binaBolumleri[3].transform.FindChild("CIMENTO").transform.childCount.ToString();
                }
            }
            else
            {
                _cimentoText.text = 0 + "/" + 0;
            }

            if (_binaBolumleri[3].transform.FindChild("TUGLA") != null)
            {
                if (_binaBolumleri[3].transform.FindChild("TUGLA").transform.childCount > _tuglaCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("TUGLA").transform.GetChild(_tuglaCount - 1).gameObject.SetActive(true);
                    _tuglaText.text = _tuglaCount.ToString() + "/" + _binaBolumleri[3].transform.FindChild("TUGLA").transform.childCount.ToString();
                }
                else
                {
                    _tuglaText.text = _binaBolumleri[3].transform.FindChild("TUGLA").transform.childCount.ToString() + "/" + _binaBolumleri[3].transform.FindChild("TUGLA").transform.childCount.ToString();
                }
            }
            else
            {
                _tuglaText.text = 0 + "/" + 0;
            }



        }
        else if (_duvar2Tamam == 1 && _duvar3Tamam == 0)
        {
            _duvar3 = false;

            for (int i = 0; i < _tahtaCount; i++)
            {
                if (_binaBolumleri[3].transform.FindChild("TAHTA") != null)
                {
                    if (_binaBolumleri[3].transform.FindChild("TAHTA").transform.childCount > i)
                    {
                        _binaBolumleri[3].transform.FindChild("TAHTA").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }


            for (int i = 0; i < _cimentoCount; i++)
            {
                if (_binaBolumleri[3].transform.FindChild("CIMENTO") != null)
                {
                    if (_binaBolumleri[3].transform.FindChild("CIMENTO").transform.childCount > i)
                    {
                        _binaBolumleri[3].transform.FindChild("CIMENTO").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }


            for (int i = 0; i < _tuglaCount; i++)
            {
                if (_binaBolumleri[3].transform.FindChild("TUGLA") != null)
                {
                    if (_binaBolumleri[3].transform.FindChild("TUGLA").transform.childCount > i)
                    {
                        _binaBolumleri[3].transform.FindChild("TUGLA").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }


            if (_binaBolumleri[3].transform.FindChild("TAHTA") != null)
            {
                if (_binaBolumleri[3].transform.FindChild("TAHTA").transform.childCount > _tahtaCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("TAHTA").transform.GetChild(_tahtaCount - 1).gameObject.SetActive(true);
                    _tahtaText.text = _tahtaCount.ToString() + "/" + _binaBolumleri[3].transform.FindChild("TAHTA").transform.childCount.ToString();
                }
                else
                {
                    _tahtaText.text = _binaBolumleri[3].transform.FindChild("TAHTA").transform.childCount.ToString() + "/" + _binaBolumleri[3].transform.FindChild("TAHTA").transform.childCount.ToString();
                }
            }
            else
            {
                _tahtaText.text = 0 + "/" + 0;
            }

            if (_binaBolumleri[3].transform.FindChild("CIMENTO") != null)
            {
                if (_binaBolumleri[3].transform.FindChild("CIMENTO").transform.childCount > _cimentoCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("CIMENTO").transform.GetChild(_cimentoCount - 1).gameObject.SetActive(true);
                    _cimentoText.text = _cimentoCount.ToString() + "/" + _binaBolumleri[3].transform.FindChild("CIMENTO").transform.childCount.ToString();
                }
                else
                {
                    _cimentoText.text = _binaBolumleri[3].transform.FindChild("CIMENTO").transform.childCount.ToString() + "/" + _binaBolumleri[3].transform.FindChild("CIMENTO").transform.childCount.ToString();
                }
            }
            else
            {
                _cimentoText.text = 0 + "/" + 0;
            }

            if (_binaBolumleri[3].transform.FindChild("TUGLA") != null)
            {
                if (_binaBolumleri[3].transform.FindChild("TUGLA").transform.childCount > _tuglaCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("TUGLA").transform.GetChild(_tuglaCount - 1).gameObject.SetActive(true);
                    _tuglaText.text = _tuglaCount.ToString() + "/" + _binaBolumleri[3].transform.FindChild("TUGLA").transform.childCount.ToString();
                }
                else
                {
                    _tuglaText.text = _binaBolumleri[3].transform.FindChild("TUGLA").transform.childCount.ToString() + "/" + _binaBolumleri[3].transform.FindChild("TUGLA").transform.childCount.ToString();
                }
            }
            else
            {
                _tuglaText.text = 0 + "/" + 0;
            }




        }


        if (_duvar4Tamam == 1)
        {
            _duvar4 = true;

            for (int i = 0; i < _binaBolumleri[4].transform.FindChild("TAHTA").transform.childCount; i++)
            {
                if (_binaBolumleri[4].transform.FindChild("TAHTA") != null)
                {
                    if (_binaBolumleri[4].transform.FindChild("TAHTA").transform.childCount > i)
                    {
                        _binaBolumleri[4].transform.FindChild("TAHTA").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }


            for (int i = 0; i < _binaBolumleri[4].transform.FindChild("CIMENTO").transform.childCount; i++)
            {
                if (_binaBolumleri[4].transform.FindChild("CIMENTO") != null)
                {
                    if (_binaBolumleri[4].transform.FindChild("CIMENTO").transform.childCount > i)
                    {
                        _binaBolumleri[4].transform.FindChild("CIMENTO").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }


            for (int i = 0; i < _binaBolumleri[4].transform.FindChild("TUGLA").transform.childCount; i++)
            {
                if (_binaBolumleri[4].transform.FindChild("TUGLA") != null)
                {
                    if (_binaBolumleri[4].transform.FindChild("TUGLA").transform.childCount > i)
                    {
                        _binaBolumleri[4].transform.FindChild("TUGLA").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }

            if (_binaBolumleri[4].transform.FindChild("TAHTA") != null)
            {
                if (_binaBolumleri[4].transform.FindChild("TAHTA").transform.childCount > _tahtaCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("TAHTA").transform.GetChild(_tahtaCount - 1).gameObject.SetActive(true);
                    _tahtaText.text = _tahtaCount.ToString() + "/" + _binaBolumleri[4].transform.FindChild("TAHTA").transform.childCount.ToString();
                }
                else
                {
                    _tahtaText.text = _binaBolumleri[4].transform.FindChild("TAHTA").transform.childCount.ToString() + "/" + _binaBolumleri[4].transform.FindChild("TAHTA").transform.childCount.ToString();
                }
            }
            else
            {
                _tahtaText.text = 0 + "/" + 0;
            }

            if (_binaBolumleri[4].transform.FindChild("CIMENTO") != null)
            {
                if (_binaBolumleri[4].transform.FindChild("CIMENTO").transform.childCount > _cimentoCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("CIMENTO").transform.GetChild(_cimentoCount - 1).gameObject.SetActive(true);
                    _cimentoText.text = _cimentoCount.ToString() + "/" + _binaBolumleri[4].transform.FindChild("CIMENTO").transform.childCount.ToString();
                }
                else
                {
                    _cimentoText.text = _binaBolumleri[4].transform.FindChild("CIMENTO").transform.childCount.ToString() + "/" + _binaBolumleri[4].transform.FindChild("CIMENTO").transform.childCount.ToString();
                }
            }
            else
            {
                _cimentoText.text = 0 + "/" + 0;
            }

            if (_binaBolumleri[4].transform.FindChild("TUGLA") != null)
            {
                if (_binaBolumleri[4].transform.FindChild("TUGLA").transform.childCount > _tuglaCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("TUGLA").transform.GetChild(_tuglaCount - 1).gameObject.SetActive(true);
                    _tuglaText.text = _tuglaCount.ToString() + "/" + _binaBolumleri[4].transform.FindChild("TUGLA").transform.childCount.ToString();
                }
                else
                {
                    _tuglaText.text = _binaBolumleri[4].transform.FindChild("TUGLA").transform.childCount.ToString() + "/" + _binaBolumleri[4].transform.FindChild("TUGLA").transform.childCount.ToString();
                }
            }
            else
            {
                _tuglaText.text = 0 + "/" + 0;
            }


        }
        else if (_duvar3Tamam == 1 && _duvar4Tamam == 0)
        {
            _duvar4 = false;

            for (int i = 0; i < _tahtaCount; i++)
            {
                if (_binaBolumleri[4].transform.FindChild("TAHTA") != null)
                {
                    if (_binaBolumleri[4].transform.FindChild("TAHTA").transform.childCount > i)
                    {
                        _binaBolumleri[4].transform.FindChild("TAHTA").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }


            for (int i = 0; i < _cimentoCount; i++)
            {
                if (_binaBolumleri[4].transform.FindChild("CIMENTO") != null)
                {
                    if (_binaBolumleri[4].transform.FindChild("CIMENTO").transform.childCount > i)
                    {
                        _binaBolumleri[4].transform.FindChild("CIMENTO").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }


            for (int i = 0; i < _tuglaCount; i++)
            {
                if (_binaBolumleri[4].transform.FindChild("TUGLA") != null)
                {
                    if (_binaBolumleri[4].transform.FindChild("TUGLA").transform.childCount > i)
                    {
                        _binaBolumleri[4].transform.FindChild("TUGLA").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }


            if (_binaBolumleri[4].transform.FindChild("TAHTA") != null)
            {
                if (_binaBolumleri[4].transform.FindChild("TAHTA").transform.childCount > _tahtaCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("TAHTA").transform.GetChild(_tahtaCount - 1).gameObject.SetActive(true);
                    _tahtaText.text = _tahtaCount.ToString() + "/" + _binaBolumleri[4].transform.FindChild("TAHTA").transform.childCount.ToString();
                }
                else
                {
                    _tahtaText.text = _binaBolumleri[4].transform.FindChild("TAHTA").transform.childCount.ToString() + "/" + _binaBolumleri[4].transform.FindChild("TAHTA").transform.childCount.ToString();
                }
            }
            else
            {
                _tahtaText.text = 0 + "/" + 0;
            }

            if (_binaBolumleri[4].transform.FindChild("CIMENTO") != null)
            {
                if (_binaBolumleri[4].transform.FindChild("CIMENTO").transform.childCount > _cimentoCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("CIMENTO").transform.GetChild(_cimentoCount - 1).gameObject.SetActive(true);
                    _cimentoText.text = _cimentoCount.ToString() + "/" + _binaBolumleri[4].transform.FindChild("CIMENTO").transform.childCount.ToString();
                }
                else
                {
                    _cimentoText.text = _binaBolumleri[4].transform.FindChild("CIMENTO").transform.childCount.ToString() + "/" + _binaBolumleri[4].transform.FindChild("CIMENTO").transform.childCount.ToString();
                }
            }
            else
            {
                _cimentoText.text = 0 + "/" + 0;
            }

            if (_binaBolumleri[4].transform.FindChild("TUGLA") != null)
            {
                if (_binaBolumleri[4].transform.FindChild("TUGLA").transform.childCount > _tuglaCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("TUGLA").transform.GetChild(_tuglaCount - 1).gameObject.SetActive(true);
                    _tuglaText.text = _tuglaCount.ToString() + "/" + _binaBolumleri[4].transform.FindChild("TUGLA").transform.childCount.ToString();
                }
                else
                {
                    _tuglaText.text = _binaBolumleri[4].transform.FindChild("TUGLA").transform.childCount.ToString() + "/" + _binaBolumleri[4].transform.FindChild("TUGLA").transform.childCount.ToString();
                }
            }
            else
            {
                _tuglaText.text = 0 + "/" + 0;
            }




        }


        if (_duvar5Tamam == 1)
        {
            _duvar5 = true;
            OpenDuvarAnim();


            if (_binaBolumleri[5].transform.FindChild("TAHTA") != null)
            {
                if (_binaBolumleri[5].transform.FindChild("TAHTA").transform.childCount > _tahtaCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("TAHTA").transform.GetChild(_tahtaCount - 1).gameObject.SetActive(true);
                    _tahtaText.text = _tahtaCount.ToString() + "/" + _binaBolumleri[5].transform.FindChild("TAHTA").transform.childCount.ToString();
                }
                else
                {
                    _tahtaText.text = _binaBolumleri[5].transform.FindChild("TAHTA").transform.childCount.ToString() + "/" + _binaBolumleri[5].transform.FindChild("TAHTA").transform.childCount.ToString();
                }
            }
            else
            {
                _tahtaText.text = 0 + "/" + 0;
            }

            if (_binaBolumleri[5].transform.FindChild("CIMENTO") != null)
            {
                if (_binaBolumleri[5].transform.FindChild("CIMENTO").transform.childCount > _cimentoCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("CIMENTO").transform.GetChild(_cimentoCount - 1).gameObject.SetActive(true);
                    _cimentoText.text = _cimentoCount.ToString() + "/" + _binaBolumleri[5].transform.FindChild("CIMENTO").transform.childCount.ToString();
                }
                else
                {
                    _cimentoText.text = _binaBolumleri[5].transform.FindChild("CIMENTO").transform.childCount.ToString() + "/" + _binaBolumleri[5].transform.FindChild("CIMENTO").transform.childCount.ToString();
                }
            }
            else
            {
                _cimentoText.text = 0 + "/" + 0;
            }

            if (_binaBolumleri[5].transform.FindChild("TUGLA") != null)
            {
                if (_binaBolumleri[5].transform.FindChild("TUGLA").transform.childCount > _tuglaCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("TUGLA").transform.GetChild(_tuglaCount - 1).gameObject.SetActive(true);
                    _tuglaText.text = _tuglaCount.ToString() + "/" + _binaBolumleri[5].transform.FindChild("TUGLA").transform.childCount.ToString();
                }
                else
                {
                    _tuglaText.text = _binaBolumleri[5].transform.FindChild("TUGLA").transform.childCount.ToString() + "/" + _binaBolumleri[5].transform.FindChild("TUGLA").transform.childCount.ToString();
                }
            }
            else
            {
                _tuglaText.text = 0 + "/" + 0;
            }


        }
        else if (_duvar4Tamam == 1 && _duvar5Tamam == 0)
        {
            _duvar5 = false;

            for (int i = 0; i < _tahtaCount; i++)
            {
                if (_binaBolumleri[5].transform.FindChild("TAHTA") != null)
                {
                    if (_binaBolumleri[5].transform.FindChild("TAHTA").transform.childCount > i)
                    {
                        _binaBolumleri[5].transform.FindChild("TAHTA").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }


            for (int i = 0; i < _cimentoCount; i++)
            {
                if (_binaBolumleri[5].transform.FindChild("CIMENTO") != null)
                {
                    if (_binaBolumleri[5].transform.FindChild("CIMENTO").transform.childCount > i)
                    {
                        _binaBolumleri[5].transform.FindChild("CIMENTO").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }


            for (int i = 0; i < _tuglaCount; i++)
            {
                if (_binaBolumleri[5].transform.FindChild("TUGLA") != null)
                {
                    if (_binaBolumleri[5].transform.FindChild("TUGLA").transform.childCount > i)
                    {
                        _binaBolumleri[5].transform.FindChild("TUGLA").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }


            if (_binaBolumleri[5].transform.FindChild("TAHTA") != null)
            {
                if (_binaBolumleri[5].transform.FindChild("TAHTA").transform.childCount > _tahtaCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("TAHTA").transform.GetChild(_tahtaCount - 1).gameObject.SetActive(true);
                    _tahtaText.text = _tahtaCount.ToString() + "/" + _binaBolumleri[5].transform.FindChild("TAHTA").transform.childCount.ToString();
                }
                else
                {
                    _tahtaText.text = _binaBolumleri[5].transform.FindChild("TAHTA").transform.childCount.ToString() + "/" + _binaBolumleri[5].transform.FindChild("TAHTA").transform.childCount.ToString();
                }
            }
            else
            {
                _tahtaText.text = 0 + "/" + 0;
            }

            if (_binaBolumleri[5].transform.FindChild("CIMENTO") != null)
            {
                if (_binaBolumleri[5].transform.FindChild("CIMENTO").transform.childCount > _cimentoCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("CIMENTO").transform.GetChild(_cimentoCount - 1).gameObject.SetActive(true);
                    _cimentoText.text = _cimentoCount.ToString() + "/" + _binaBolumleri[5].transform.FindChild("CIMENTO").transform.childCount.ToString();
                }
                else
                {
                    _cimentoText.text = _binaBolumleri[5].transform.FindChild("CIMENTO").transform.childCount.ToString() + "/" + _binaBolumleri[5].transform.FindChild("CIMENTO").transform.childCount.ToString();
                }
            }
            else
            {
                _cimentoText.text = 0 + "/" + 0;
            }

            if (_binaBolumleri[5].transform.FindChild("TUGLA") != null)
            {
                if (_binaBolumleri[5].transform.FindChild("TUGLA").transform.childCount > _tuglaCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("TUGLA").transform.GetChild(_tuglaCount - 1).gameObject.SetActive(true);
                    _tuglaText.text = _tuglaCount.ToString() + "/" + _binaBolumleri[5].transform.FindChild("TUGLA").transform.childCount.ToString();
                }
                else
                {
                    _tuglaText.text = _binaBolumleri[5].transform.FindChild("TUGLA").transform.childCount.ToString() + "/" + _binaBolumleri[5].transform.FindChild("TUGLA").transform.childCount.ToString();
                }
            }
            else
            {
                _tuglaText.text = 0 + "/" + 0;
            }




        }


        if (_cati1Tamam == 1)
        {
            _cati1 = true;

            for (int i = 0; i < _binaBolumleri[6].transform.FindChild("TAHTA").transform.childCount; i++)
            {
                if (_binaBolumleri[6].transform.FindChild("TAHTA") != null)
                {
                    if (_binaBolumleri[6].transform.FindChild("TAHTA").transform.childCount > i)
                    {
                        _binaBolumleri[6].transform.FindChild("TAHTA").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }

            /*
            for (int i = 0; i < _cimentoCount; i++)
            {
                if (_binaBolumleri[6].transform.FindChild("CIMENTO") != null)
                {
                    if (_binaBolumleri[6].transform.FindChild("CIMENTO").transform.childCount > i)
                    {
                        _binaBolumleri[6].transform.FindChild("CIMENTO").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }
            */

            for (int i = 0; i < _binaBolumleri[6].transform.FindChild("TUGLA").transform.childCount; i++)
            {
                if (_binaBolumleri[6].transform.FindChild("TUGLA") != null)
                {
                    if (_binaBolumleri[6].transform.FindChild("TUGLA").transform.childCount > i)
                    {
                        _binaBolumleri[6].transform.FindChild("TUGLA").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }


            if (_binaBolumleri[6].transform.FindChild("TAHTA") != null)
            {
                if (_binaBolumleri[6].transform.FindChild("TAHTA").transform.childCount > _tahtaCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("TAHTA").transform.GetChild(_tahtaCount - 1).gameObject.SetActive(true);
                    _tahtaText.text = _tahtaCount.ToString() + "/" + _binaBolumleri[6].transform.FindChild("TAHTA").transform.childCount.ToString();
                }
                else
                {
                    _tahtaText.text = _binaBolumleri[6].transform.FindChild("TAHTA").transform.childCount.ToString() + "/" + _binaBolumleri[6].transform.FindChild("TAHTA").transform.childCount.ToString();
                }
            }
            else
            {
                _tahtaText.text = 0 + "/" + 0;
            }

            if (_binaBolumleri[6].transform.FindChild("CIMENTO") != null)
            {
                if (_binaBolumleri[6].transform.FindChild("CIMENTO").transform.childCount > _cimentoCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("CIMENTO").transform.GetChild(_cimentoCount - 1).gameObject.SetActive(true);
                    _cimentoText.text = _cimentoCount.ToString() + "/" + _binaBolumleri[6].transform.FindChild("CIMENTO").transform.childCount.ToString();
                }
                else
                {
                    _cimentoText.text = _binaBolumleri[6].transform.FindChild("CIMENTO").transform.childCount.ToString() + "/" + _binaBolumleri[6].transform.FindChild("CIMENTO").transform.childCount.ToString();
                }
            }
            else
            {
                _cimentoText.text = 0 + "/" + 0;
            }

            if (_binaBolumleri[6].transform.FindChild("TUGLA") != null)
            {
                if (_binaBolumleri[6].transform.FindChild("TUGLA").transform.childCount > _tuglaCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("TUGLA").transform.GetChild(_tuglaCount - 1).gameObject.SetActive(true);
                    _tuglaText.text = _tuglaCount.ToString() + "/" + _binaBolumleri[6].transform.FindChild("TUGLA").transform.childCount.ToString();
                }
                else
                {
                    _tuglaText.text = _binaBolumleri[6].transform.FindChild("TUGLA").transform.childCount.ToString() + "/" + _binaBolumleri[6].transform.FindChild("TUGLA").transform.childCount.ToString();
                }
            }
            else
            {
                _tuglaText.text = 0 + "/" + 0;
            }




        }
        else if (_duvar5Tamam == 1 && _cati1Tamam == 0)
        {
            _cati1 = false;

            for (int i = 0; i < _tahtaCount; i++)
            {
                if (_binaBolumleri[6].transform.FindChild("TAHTA") != null)
                {
                    if (_binaBolumleri[6].transform.FindChild("TAHTA").transform.childCount > i)
                    {
                        _binaBolumleri[6].transform.FindChild("TAHTA").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }


            for (int i = 0; i < _cimentoCount; i++)
            {
                if (_binaBolumleri[6].transform.FindChild("CIMENTO") != null)
                {
                    if (_binaBolumleri[6].transform.FindChild("CIMENTO").transform.childCount > i)
                    {
                        _binaBolumleri[6].transform.FindChild("CIMENTO").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }


            for (int i = 0; i < _tuglaCount; i++)
            {
                if (_binaBolumleri[6].transform.FindChild("TUGLA") != null)
                {
                    if (_binaBolumleri[6].transform.FindChild("TUGLA").transform.childCount > i)
                    {
                        _binaBolumleri[6].transform.FindChild("TUGLA").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }

            if (_binaBolumleri[6].transform.FindChild("TAHTA") != null)
            {
                if (_binaBolumleri[6].transform.FindChild("TAHTA").transform.childCount > _tahtaCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("TAHTA").transform.GetChild(_tahtaCount - 1).gameObject.SetActive(true);
                    _tahtaText.text = _tahtaCount.ToString() + "/" + _binaBolumleri[6].transform.FindChild("TAHTA").transform.childCount.ToString();
                }
                else
                {
                    _tahtaText.text = _binaBolumleri[6].transform.FindChild("TAHTA").transform.childCount.ToString() + "/" + _binaBolumleri[6].transform.FindChild("TAHTA").transform.childCount.ToString();
                }
            }
            else
            {
                _tahtaText.text = 0 + "/" + 0;
            }

            if (_binaBolumleri[6].transform.FindChild("CIMENTO") != null)
            {
                if (_binaBolumleri[6].transform.FindChild("CIMENTO").transform.childCount > _cimentoCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("CIMENTO").transform.GetChild(_cimentoCount - 1).gameObject.SetActive(true);
                    _cimentoText.text = _cimentoCount.ToString() + "/" + _binaBolumleri[6].transform.FindChild("CIMENTO").transform.childCount.ToString();
                }
                else
                {
                    _cimentoText.text = _binaBolumleri[6].transform.FindChild("CIMENTO").transform.childCount.ToString() + "/" + _binaBolumleri[6].transform.FindChild("CIMENTO").transform.childCount.ToString();
                }
            }
            else
            {
                _cimentoText.text = 0 + "/" + 0;
            }

            if (_binaBolumleri[6].transform.FindChild("TUGLA") != null)
            {
                if (_binaBolumleri[6].transform.FindChild("TUGLA").transform.childCount > _tuglaCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("TUGLA").transform.GetChild(_tuglaCount - 1).gameObject.SetActive(true);
                    _tuglaText.text = _tuglaCount.ToString() + "/" + _binaBolumleri[6].transform.FindChild("TUGLA").transform.childCount.ToString();
                }
                else
                {
                    _tuglaText.text = _binaBolumleri[6].transform.FindChild("TUGLA").transform.childCount.ToString() + "/" + _binaBolumleri[6].transform.FindChild("TUGLA").transform.childCount.ToString();
                }
            }
            else
            {
                _tuglaText.text = 0 + "/" + 0;
            }



        }



        if (_cati2Tamam == 1)
        {
            _cati2 = true;
            _binaBitti = true;
            FinishHouse();


            if (_binaBolumleri[7].transform.FindChild("TAHTA") != null)
            {
                if (_binaBolumleri[7].transform.FindChild("TAHTA").transform.childCount > _tahtaCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("TAHTA").transform.GetChild(_tahtaCount - 1).gameObject.SetActive(true);
                    _tahtaText.text = _tahtaCount.ToString() + "/" + _binaBolumleri[7].transform.FindChild("TAHTA").transform.childCount.ToString();
                }
                else
                {
                    _tahtaText.text = _binaBolumleri[7].transform.FindChild("TAHTA").transform.childCount.ToString() + "/" + _binaBolumleri[7].transform.FindChild("TAHTA").transform.childCount.ToString();
                }
            }
            else
            {
                _tahtaText.text = 0 + "/" + 0;
            }

            if (_binaBolumleri[7].transform.FindChild("CIMENTO") != null)
            {
                if (_binaBolumleri[7].transform.FindChild("CIMENTO").transform.childCount > _cimentoCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("CIMENTO").transform.GetChild(_cimentoCount - 1).gameObject.SetActive(true);
                    _cimentoText.text = _cimentoCount.ToString() + "/" + _binaBolumleri[7].transform.FindChild("CIMENTO").transform.childCount.ToString();
                }
                else
                {
                    _cimentoText.text = _binaBolumleri[7].transform.FindChild("CIMENTO").transform.childCount.ToString() + "/" + _binaBolumleri[7].transform.FindChild("CIMENTO").transform.childCount.ToString();
                }
            }
            else
            {
                _cimentoText.text = 0 + "/" + 0;
            }

            if (_binaBolumleri[7].transform.FindChild("TUGLA") != null)
            {
                if (_binaBolumleri[7].transform.FindChild("TUGLA").transform.childCount > _tuglaCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("TUGLA").transform.GetChild(_tuglaCount - 1).gameObject.SetActive(true);
                    _tuglaText.text = _tuglaCount.ToString() + "/" + _binaBolumleri[7].transform.FindChild("TUGLA").transform.childCount.ToString();
                }
                else
                {
                    _tuglaText.text = _binaBolumleri[7].transform.FindChild("TUGLA").transform.childCount.ToString() + "/" + _binaBolumleri[7].transform.FindChild("TUGLA").transform.childCount.ToString();
                }
            }
            else
            {
                _tuglaText.text = 0 + "/" + 0;
            }


        }
        else if (_cati1Tamam == 1 && _cati2Tamam == 0)
        {
            _cati2 = false;

            for (int i = 0; i < _tahtaCount; i++)
            {
                if (_binaBolumleri[7].transform.FindChild("TAHTA") != null)
                {
                    if (_binaBolumleri[7].transform.FindChild("TAHTA").transform.childCount > i)
                    {
                        _binaBolumleri[7].transform.FindChild("TAHTA").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }


            for (int i = 0; i < _cimentoCount; i++)
            {
                if (_binaBolumleri[7].transform.FindChild("CIMENTO") != null)
                {
                    if (_binaBolumleri[7].transform.FindChild("CIMENTO").transform.childCount > i)
                    {
                        _binaBolumleri[7].transform.FindChild("CIMENTO").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }


            for (int i = 0; i < _tuglaCount; i++)
            {
                if (_binaBolumleri[7].transform.FindChild("TUGLA") != null)
                {
                    if (_binaBolumleri[7].transform.FindChild("TUGLA").transform.childCount > i)
                    {
                        _binaBolumleri[7].transform.FindChild("TUGLA").transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }


            if (_binaBolumleri[7].transform.FindChild("TAHTA") != null)
            {
                if (_binaBolumleri[7].transform.FindChild("TAHTA").transform.childCount > _tahtaCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("TAHTA").transform.GetChild(_tahtaCount - 1).gameObject.SetActive(true);
                    _tahtaText.text = _tahtaCount.ToString() + "/" + _binaBolumleri[7].transform.FindChild("TAHTA").transform.childCount.ToString();
                }
                else
                {
                    _tahtaText.text = _binaBolumleri[7].transform.FindChild("TAHTA").transform.childCount.ToString() + "/" + _binaBolumleri[7].transform.FindChild("TAHTA").transform.childCount.ToString();
                }
            }
            else
            {
                _tahtaText.text = 0 + "/" + 0;
            }

            if (_binaBolumleri[7].transform.FindChild("CIMENTO") != null)
            {
                if (_binaBolumleri[7].transform.FindChild("CIMENTO").transform.childCount > _cimentoCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("CIMENTO").transform.GetChild(_cimentoCount - 1).gameObject.SetActive(true);
                    _cimentoText.text = _cimentoCount.ToString() + "/" + _binaBolumleri[7].transform.FindChild("CIMENTO").transform.childCount.ToString();
                }
                else
                {
                    _cimentoText.text = _binaBolumleri[7].transform.FindChild("CIMENTO").transform.childCount.ToString() + "/" + _binaBolumleri[7].transform.FindChild("CIMENTO").transform.childCount.ToString();
                }
            }
            else
            {
                _cimentoText.text = 0 + "/" + 0;
            }

            if (_binaBolumleri[7].transform.FindChild("TUGLA") != null)
            {
                if (_binaBolumleri[7].transform.FindChild("TUGLA").transform.childCount > _tuglaCount - 1)
                {
                    //_binaBolumleri[0].transform.FindChild("TUGLA").transform.GetChild(_tuglaCount - 1).gameObject.SetActive(true);
                    _tuglaText.text = _tuglaCount.ToString() + "/" + _binaBolumleri[7].transform.FindChild("TUGLA").transform.childCount.ToString();
                }
                else
                {
                    _tuglaText.text = _binaBolumleri[7].transform.FindChild("TUGLA").transform.childCount.ToString() + "/" + _binaBolumleri[7].transform.FindChild("TUGLA").transform.childCount.ToString();
                }
            }
            else
            {
                _tuglaText.text = 0 + "/" + 0;
            }



        }


        //fonc ending

    }

    private void OpenZeminAnim()
    {
        zeminSeffaf.SetActive(false);
        // groundTextObject.SetActive(false);
        // wallTextObject.SetActive(true);
        zeminAnim.SetActive(true);
        zeminAnimator.Play("ZeminAnimation");
        duvarSeffaf.SetActive(true);

    }


    public void OpenDuvarAnim()
    {
        duvarSeffaf.SetActive(false);
        // wallTextObject.SetActive(false);
        //roofTextObject.SetActive(true);
        duvarAnim.SetActive(true);
        duvarAnimator.Play("DuvarAnimation");
        catiSeffaf.SetActive(true);
    }

    public void FinishHouse()
    {
        catiSeffaf.SetActive(false);
        //roofTextObject.SetActive(false);
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

    [Obsolete]
    private void StartingEvents()
    {
        // wallTextObject.SetActive(false);
        // roofTextObject.SetActive(false);
        // groundTextObject.SetActive(true);
        zeminSeffaf.gameObject.SetActive(true);

        /*
        groundCount = PlayerPrefs.GetInt("ZeminDeger");
        wallCount = PlayerPrefs.GetInt("GovdeDeger");
        roofCount = PlayerPrefs.GetInt("CatiDeger");
        */

        //CheckObjects();

        _zemin = false;
        _duvar1 = false;
        _duvar2 = false;
        _duvar3 = false;
        _duvar4 = false;
        _duvar5 = false;
        _cati1 = false;
        _cati2 = false;

        _binaBitti = false;

        _zeminTamam = PlayerPrefs.GetInt("ZeminTamam");
        _duvar1Tamam = PlayerPrefs.GetInt("Duvar1Tamam");
        _duvar2Tamam = PlayerPrefs.GetInt("Duvar2Tamam");
        _duvar3Tamam = PlayerPrefs.GetInt("Duvar3Tamam");
        _duvar4Tamam = PlayerPrefs.GetInt("Duvar4Tamam");
        _duvar5Tamam = PlayerPrefs.GetInt("Duvar5Tamam");
        _cati1Tamam = PlayerPrefs.GetInt("Cati1Tamam");
        _cati2Tamam = PlayerPrefs.GetInt("Cati2Tamam");

        _tahtaCount = PlayerPrefs.GetInt("TahtaCount");
        _cimentoCount = PlayerPrefs.GetInt("CimentoCount");
        _tuglaCount = PlayerPrefs.GetInt("TuglaCount");


        SavingSystem();

        /*
        if (_binaBolumleri[0].transform.FindChild("TAHTA") != null)
        {

            _tahtaText.text = 0 + "/" + _binaBolumleri[0].transform.FindChild("TAHTA").transform.childCount.ToString();

        }
        else
        {
            _tahtaText.text = 0 + "/" + 0;
        }

        if (_binaBolumleri[0].transform.FindChild("CIMENTO") != null)
        {

            _tahtaText.text = 0 + "/" + _binaBolumleri[0].transform.FindChild("CIMENTO").transform.childCount.ToString();

        }
        else
        {
            _tahtaText.text = 0 + "/" + 0;
        }

        if (_binaBolumleri[0].transform.FindChild("TUGLA") != null)
        {

            _tahtaText.text = 0 + "/" + _binaBolumleri[0].transform.FindChild("TUGLA").transform.childCount.ToString();

        }
        else
        {
            _tahtaText.text = 0 + "/" + 0;
        }
        */
        //HouseKonum();

    }

    public void SavingSifirla()
    {
        PlayerPrefs.SetInt("ZeminTamam", 0);
        PlayerPrefs.SetInt("Duvar1Tamam", 0);
        PlayerPrefs.SetInt("Duvar2Tamam", 0);
        PlayerPrefs.SetInt("Duvar3Tamam", 0);
        PlayerPrefs.SetInt("Duvar4Tamam", 0);
        PlayerPrefs.SetInt("Duvar5Tamam", 0);
        PlayerPrefs.SetInt("Cati1Tamam", 0);
        PlayerPrefs.SetInt("Cati2Tamam", 0);


        PlayerPrefs.SetInt("TahtaCount", 0);
        PlayerPrefs.SetInt("CimentoCount", 0);
        PlayerPrefs.SetInt("TuglaCount", 0);
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
