using System.Threading;
using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public int collectibleDegeri;
    public bool xVarMi = true;
    public bool collectibleVarMi = true;


    private Animator animator;
    private void Awake()
    {
        if (instance == null) instance = this;
        //else Destroy(this);
        animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        //HouseController.instance.EvOlustur();
        StartingEvents();
    }

    /// <summary>
    /// Playerin collider olaylari.. collectible, engel veya finish noktasi icin. Burasi artirilabilir.
    /// elmas icin veya baska herhangi etkilesimler icin tag ekleyerek kontrol dongusune eklenir.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Collectable"))
        {
            // COLLECTIBLE CARPINCA YAPILACAKLAR...
            // GameController.instance.SetScore(collectibleDegeri); // ORNEK KULLANIM detaylar icin ctrl+click yapip fonksiyon aciklamasini oku
            MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);
        }
        else if (other.CompareTag("engel"))
        {
            // ENGELELRE CARPINCA YAPILACAKLAR....
            // GameController.instance.SetScore(-collectibleDegeri);

            // ORNEK KULLANIM detaylar icin ctrl+click yapip fonksiyon aciklamasini oku

            MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);

            if (StackController.instance.StackObjectsList.Count <= 0 && !StackController.instance.triggerCheck) // SKOR SIFIRIN ALTINA DUSTUYSE - GameController.instance.score < 0
            {
                // FAİL EVENTLERİ BURAYA YAZILACAK..
                GameController.instance.isContinue = false; // çarptığı anda oyuncunun yerinde durması ilerlememesi için
                UIController.instance.ActivateLooseScreen(); // Bu fonksiyon direk çağrılada bilir veya herhangi bir effect veya animasyon bitiminde de çağrılabilir..
                IdleAnim();
                // oyuncu fail durumunda bu fonksiyon çağrılacak.. 
            }


        }
        else if (other.CompareTag("finish"))
        {
            // finishe collider eklenecek levellerde...
            // FINISH NOKTASINA GELINCE YAPILACAKLAR... Totalscore artırma, x işlemleri, efektler v.s. v.s.
            //
            GameController.instance.isContinue = false;
            IdleAnim();
            transform.DOMove(new Vector3(0, transform.position.y, transform.position.z), 0.5f).OnComplete(() =>
            {
                //IdleAnim();
            });

            //
            // GameController.instance.ScoreCarp(3);  // Bu fonksiyon normalde x ler hesaplandıktan sonra çağrılacak. Parametre olarak x i alıyor. 
            // x değerine göre oyuncunun total scoreunu hesaplıyor.. x li olmayan oyunlarda parametre olarak 1 gönderilecek.

            //
            //StartCoroutine(ActiveWinScreen()); //////////////////

            //

            // finish noktasına gelebildiyse her türlü win screen aktif edilecek.. ama burada değil..
            // normal de bu kodu x ler hesaplandıktan sonra çağıracağız. Ve bu kod çağrıldığında da kazanılan puanlar animasyonlu şekilde artacak..


        }

    }



    /// <summary>
    /// Bu fonksiyon her level baslarken cagrilir. 
    /// </summary>
    public void StartingEvents()
    {

        transform.parent.transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.parent.transform.position = Vector3.zero;
        GameController.instance.isContinue = false;
        GameController.instance.score = 0;
        transform.position = new Vector3(0, transform.position.y, 0);
        GetComponent<Collider>().enabled = true;

        Invoke("HouseKonum", 0.1f);

    }

    private void HouseKonum()
    {
        House.instance.HouseKonum();
    }

    public void IdleAnim()
    {
        animator.SetTrigger("idle");
    }

    public void WalkAnim()
    {
        animator.SetTrigger("walk");
    }


    private IEnumerator ActiveWinScreen(int delay)
    {
        yield return new WaitForSeconds(delay);
        UIController.instance.ActivateWinScreen();
        GameController.instance.DestroyAllObject();
        GameController.instance.ScoreCarp(1);
    }

    public void WinBaslat(int sure)
    {
        StartCoroutine(ActiveWinScreen(sure));
    }


}
