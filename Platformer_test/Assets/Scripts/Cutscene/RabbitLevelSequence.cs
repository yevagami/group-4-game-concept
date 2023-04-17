using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitLevelSequence : sequence
{
    [Header("Actors")]
    [SerializeField] SmoothCameraFollow mainCamera;
    [SerializeField] Transform cameraTarget;
    [SerializeField] Transform player;
    [SerializeField] Hud hud;
    public override void endSequence()
    {
        return;
    }

    public override IEnumerator startSequence()
    {
        hasStarted = false;

        yield return new WaitForSeconds(2);

        mainCamera.target = cameraTarget;
        string[] dialogue1 = {"If you can get over here in less than a minute, I'll let you keep the power I gave to you"};
        hud.printText(dialogue1);

        yield return new WaitForSeconds(10);
        mainCamera.target = player;
        hud.endText();

        yield return new WaitForSeconds(35);
        mainCamera.target = cameraTarget;
        string[] dialogue2 = {
            "Hahahahaha",
            "There you go, I knew you could do it",
            "A deal's a deal, you keep it kid"
        };
        hud.printText(dialogue2);
    
        yield return new WaitForSeconds(9.5f);
        mainCamera.target = player;
        hud.endText();


        hasEnded = true;
    }
}
