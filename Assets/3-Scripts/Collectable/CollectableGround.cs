using System.ComponentModel.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableGround : MonoBehaviour
{

    [SerializeField] private GameObject _olusturalacakObje;


    public void Collect()
    {

        GameObject obje = Instantiate(_olusturalacakObje, transform.position, Quaternion.identity);
        //obje.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
        StackController.instance.StackObjectMethod(obje);
        ThrowController.instance.PlaceObjectAddMethod(obje);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Collect();
            Destroy(gameObject);
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            Destroy(rigidbody);
        }
    }


}
