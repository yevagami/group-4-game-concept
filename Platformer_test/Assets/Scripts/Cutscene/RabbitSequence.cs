using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitSequence : sequence
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
        
        yield return new WaitForSeconds(5);

        mainCamera.target = cameraTarget;
        string[] dialogue1 = {"Hey kid, over here", "Yeah you, over here, I've got something to tell you"};
        hud.printText(dialogue1);

        yield return new WaitForSeconds(7);
        hud.endText();
        mainCamera.target = player;

        yield return new WaitForSeconds(3);
         mainCamera.target = cameraTarget;
         string[] dialogue2 = {
            "The forest is crawling with monsters, thanks to that pesky dragon wrecking the place", 
            "I can see from the look in your eyes that you're sick of it too",
            "How about this? I lend you some of my power, and you take down that huge lump of scales you call a dragon",
            "Although I gotta make sure that you're worthy of handling it first"
            };

        hud.printText(dialogue2);

        yield return new WaitForSeconds(27);
        hud.endText();
        mainCamera.target = player;

        hasEnded = true;
    }
}
