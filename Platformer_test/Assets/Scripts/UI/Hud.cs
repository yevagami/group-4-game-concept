using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hud : MonoBehaviour
{
    [SerializeField] GameObject textBox;
    [SerializeField] TextBoxScroll text;
    // Start is called before the first frame update
    void Start()
    {
        textBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void printText(string text_){
        textBox.SetActive(true);
        text.lines[0] = text_;
        text.beginLine = true;
    }

    public void endText(){
        textBox.SetActive(false);
    }
}
