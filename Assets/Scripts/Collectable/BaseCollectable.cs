using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BaseCollectable : MonoBehaviour, ICollectable
{   
 
    void OnTriggerEnter(Collider other)
    {
        if(other.tag =="Player"){
            Collect();
        }

        if (other.tag=="Platform")
        {
          
           
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Platform")
        {
              gameObject.GetComponent<BoxCollider>().isTrigger=true;
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            Destroy(rigidbody);
        }
    }
    public virtual void Collect()
    {
        
    }



}
