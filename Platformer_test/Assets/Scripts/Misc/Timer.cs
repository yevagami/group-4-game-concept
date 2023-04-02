using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Image TimerUIImage;

    private float timeRemaining;
    public float maxTime;
    public string SceneName;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

            TimerUIImage.fillAmount = timeRemaining / maxTime;
        }

        else
        {
            timeRemaining = 0;
            SceneManager.LoadScene(SceneName);
        }
    }
}
