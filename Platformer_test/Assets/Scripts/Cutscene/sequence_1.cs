using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sequence_1 : sequence
{
    [Header("Actors")]
    [SerializeField] SmoothCameraFollow mainCamera;
    [SerializeField] Transform cameraTarget;
    [SerializeField] Transform player;
    [SerializeField] Hud hud;


    public override IEnumerator startSequence()
    {
        hasStarted = false;
        
        Debug.Log("Sequence Starting");
        yield return new WaitForSeconds(3);

        mainCamera.target = cameraTarget;
        hud.printText("HELLO!!!!");
        yield return new WaitForSeconds(2);

        hasEnded = true;
    }


    public override void endSequence(){
        hud.endText();
        mainCamera.target = player;
        hasEnded = true;
        Debug.Log("Sequence Ended");
    }
}
