using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBoxScroll : MonoBehaviour
{
    //Properties
    [SerializeField] TextMeshProUGUI TMPComponent;
    [SerializeField] float textSpeed;
    [SerializeField] float minFontSize;
    [SerializeField] float maxFontSize;
    
    public bool beginLine = false;
    //ideal should be about 445 characters for a 27 font
    //so that's a ratio of 16.48 : 1
    public string[] lines = {
        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
        "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
    };
    
    float timer_text = 0;
    //Character index counter
    int charIndex = 0;
    int lineIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        TMPComponent.text = "";
    }


    // Update is called once per frame
    void Update()
    {
        if(beginLine){
            TMPComponent.fontSize = calculateFontSize(lines[lineIndex]);
            startLine();
        }

        if(Input.anyKeyDown){
            KINGCRIMSON();
        }
    }


    //calculates the fontsize dempending on the line character count
    float calculateFontSize(string line){
        char[] lineCharacters = line.ToCharArray();
        float Length = 10000 / lineCharacters.Length;

        if(Length < minFontSize){
            return minFontSize;
        }

        if(Length > maxFontSize){
            return maxFontSize;
        }
        
        return Length;
    }

    
    //Reads through the line, character by character and printing them into the textbox
    void startLine(){
        timer_text += Time.deltaTime;

        if(timer_text >= textSpeed){
            if(charIndex < lines[lineIndex].Length){
                TMPComponent.text += lines[lineIndex][charIndex];
                charIndex += 1;
                timer_text = 0;
            }
            else{
                beginLine = false;
                newLine();
            }
        }
    }


    //Resets everything to begin parsing through a new line
    void newLine(){
        charIndex = 0;
        lineIndex += 1;
        timer_text = 0;
        TMPComponent.text = "";

        
        if(lineIndex < lines.Length){
            TMPComponent.fontSize = calculateFontSize(lines[lineIndex]);
            beginLine = true;
        }
        else{
            lineIndex = 0;
        }
    }
    
    
    //when a button is pressed, prints the entire line and skips the whole process
    void KINGCRIMSON(){ 
        if(beginLine){
            beginLine = false;
            TMPComponent.text = lines[lineIndex];
        }

        else{
            newLine();
        }
    }

}
