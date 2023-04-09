using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBoxScroll : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshComponent;
    [SerializeField] float textSpeed;
    public bool startLine = false;

    float timer_text_speed = 0;
    string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        textMeshComponent.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(startLine){
            timer_text_speed += Time.deltaTime;

            if(timer_text_speed >= textSpeed && index < text.Length){
                textMeshComponent.text += text[index];
                index += 1;
                timer_text_speed = 0;
            }
        }
    }
}
