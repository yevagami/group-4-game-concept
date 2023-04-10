using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class sequence 
{
   //Checks if the sequence has ended
   public bool hasEnded = false;
   public abstract void startSequence(); //The sequence itself
   public abstract void endSequence(); //The end of the sequence
}
