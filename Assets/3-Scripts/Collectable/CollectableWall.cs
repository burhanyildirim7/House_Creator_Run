using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableWall : BaseCollectable
{
      public  override void Collect(){
      StackController.instance.StackObjectMethod(this);
      ThrowController.instance.PlaceObjectAddMethod(this);
   }
}
