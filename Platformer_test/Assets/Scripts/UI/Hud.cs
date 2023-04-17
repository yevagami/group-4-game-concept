using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;

using UnityEngine;

public class Hud : MonoBehaviour
{

    [Header("Textbox")]
    [SerializeField] GameObject textBox;
    [SerializeField] TextBoxScroll text;


    [Header("Healthbar")]
    [SerializeField] PlayerHealth playerHealth_;
    [SerializeField] Image healthBar;


    [Header("Bark")]
    [SerializeField] barkProjectileLaunch playerShoot;
    [SerializeField] Image shootBar;
    [SerializeField] GameObject shootBarObject;


    [Header("Powerups")]
    [SerializeField] SpriteRenderer[] powerupRenderPos;
    [SerializeField] Sprite[] powerupSprites;
    [SerializeField] Player player_;
    List<Sprite> powerupsToRender;


    // Start is called before the first frame update
    void Start()
    {
        textBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        healthBar.fillAmount = playerHealth_.health / playerHealth_.maxHealth;
        shootBar.fillAmount = playerShoot.shootMeter / playerShoot.shootMeterMax;

        if(player_.hasAirJump) powerupRenderPos[0].sprite = powerupSprites[0];
        if(player_.hasHover) powerupRenderPos[1].sprite = powerupSprites[1];
        if(player_.hasOwl) powerupRenderPos[2].sprite = powerupSprites[2];
        if(player_.hasBark) powerupRenderPos[3].sprite = powerupSprites[3];
        shootBarObject.SetActive(player_.hasBark);
    }
    
    public void printText(string text_){
        textBox.SetActive(true);
        text.lines[0] = text_;
        text.beginLine = true;
    }

    public void endText(){
        textBox.SetActive(false);
    }


    public void RenderPowerups(){

    }

}
