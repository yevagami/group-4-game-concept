using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable] public abstract class sequence : MonoBehaviour
{
   //Checks if the sequence has ended
   public bool hasStarted = true;
   public bool hasEnded = false;
   public string sequenceName = "";

   public abstract IEnumerator startSequence(); //The sequence itself
   public abstract void endSequence(); //The end of the sequence
}
