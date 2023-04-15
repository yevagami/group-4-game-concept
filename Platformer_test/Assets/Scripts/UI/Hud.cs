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


    [Header("Powerups")]
    [SerializeField] GameObject[] powerupRenderPos;
    [SerializeField] List<Sprite> powerupSprites;
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
