using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sequenceManager : MonoBehaviour
{
    //The current sequences in the scene
    public sequence[] sequenceData;
    public List<sequence> sequenceList = new List<sequence>();
    //Current sequence
    sequence currentSequence;
    //List of sequences
    sequence sequence1 = new sequence_1();

    void Start()
    {
        currentSequence = sequence1;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentSequence != null && !currentSequence.hasEnded){
            currentSequence.startSequence();
        }
    }

    void changeSequence(sequence nextSequence){
        if(nextSequence != currentSequence){
            currentSequence = nextSequence;
        }
    }
}
