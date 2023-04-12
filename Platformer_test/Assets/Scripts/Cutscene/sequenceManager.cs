using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sequenceManager : MonoBehaviour
{
    //Current sequence
    sequence currentSequence;
    //List of sequences
    //[SerializeField] GameObject sequence_1;
    [SerializeField] sequence[] sequenceList;

    void Start()
    {
        currentSequence = sequenceList[0];
    }

    // Update is called once per frame
    void Update(){
        if(currentSequence != null){
            if(currentSequence.hasStarted){
                StartCoroutine(currentSequence.startSequence());
            }

            if(currentSequence.hasEnded){
                currentSequence.endSequence();
                currentSequence = null;
            }
        }
    }


    void changeSequence(sequence nextSequence){
        if(nextSequence != currentSequence){
            currentSequence = nextSequence;
        }
    }
}
