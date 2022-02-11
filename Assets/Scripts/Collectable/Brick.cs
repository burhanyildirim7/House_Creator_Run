using System.ComponentModel.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : BaseCollectable
{
  public  override void Collect(){
      StackController.instance.StackObjectMethod(this);
      BrickController.instance.PlaceObjectAddMethod(this);
   }

   
}
