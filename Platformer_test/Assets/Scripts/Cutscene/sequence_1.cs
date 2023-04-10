using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sequence_1 : sequence
{
    float timer_sequence_duration = 0;

    public override void startSequence()
    {
        Debug.Log("Sequence Starting");
        timer_sequence_duration += Time.deltaTime;
        if(timer_sequence_duration >= 10){
            endSequence();
        }
    }

    public override void endSequence()
    {
        hasEnded = true;
        Debug.Log("Sequence Ended");
    }
}
