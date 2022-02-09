using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class StackController : MonoBehaviour
{
    public static StackController instance;
    public  GameObject CollectPoint;
    public GameObject DropPoint,DropPoint2;
    public List<BaseCollectable> _stackObjectsList = new List<BaseCollectable>();
    public List<BaseCollectable> StackObjectsList => _stackObjectsList;

    private void Awake()
	{
        if (instance == null) instance = this;

	}

    private void Update() {
        FixedStackPosition();
    }

    void OnTriggerEnter(Collider other)
    {
        
        if(other.tag=="engel"){
            if(_stackObjectsList.Count>0)
                DropObjectMethod(_stackObjectsList[_stackObjectsList.Count-1]);
        }
    }

 public void StackObjectMethod(BaseCollectable baseObject){
       
       baseObject.transform.parent= CollectPoint.transform;
       baseObject.transform.DOMove(new Vector3(CollectPoint.transform.position.x,CollectPoint.transform.position.y+(_stackObjectsList.Count),CollectPoint.transform.position.z),0).OnComplete(()=>{
          
       });
       
 }


    public void DropObjectMethod(BaseCollectable baseObject){
       
          
        baseObject.transform.DOMove(new Vector3(baseObject.transform.position.x,baseObject.transform.position.y+0.5f,baseObject.transform.position.z+5f),0.3f).OnComplete(()=>{
            baseObject.transform.DOMoveY(1,0.3f);
        });
       baseObject.transform.parent=null;
        _stackObjectsList.Remove(baseObject);
       
 }

  private void FixedStackPosition()
    {
        foreach (BaseCollectable stack  in _stackObjectsList)
           {
               stack.transform.DOMoveX(CollectPoint.transform.position.x,0f);
           }
    }

}
