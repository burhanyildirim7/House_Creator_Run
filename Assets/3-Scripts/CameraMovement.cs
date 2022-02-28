using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public static CameraMovement instance;

    private GameObject Player;

    Vector3 aradakiFark;

    Vector3 ilkKonum;

    private void Awake()
    {
        if (instance == null) instance = this;

    }

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        aradakiFark = transform.position - Player.transform.position;

        ilkKonum = transform.position;
    }


    void FixedUpdate()
    {
        if (GameController.instance.isFinish)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(0.5f, 12, Player.transform.position.z), Time.deltaTime * 5f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(35, 0, 0), Time.deltaTime * 5f);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(Player.transform.position.x, Player.transform.position.y + aradakiFark.y, Player.transform.position.z + aradakiFark.z), Time.deltaTime * 5f);
        }


    }

    public void KameraResetle()
    {
        transform.position = ilkKonum;
        transform.rotation = Quaternion.Euler(25, 0, 0);
    }

}
