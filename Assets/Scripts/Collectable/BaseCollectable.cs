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
    }
    public void Collect()
    {

 
        StackController.instance.StackObjectsList.Add(this);
        StackController.instance.StackObjectMethod(this);
    }

}
