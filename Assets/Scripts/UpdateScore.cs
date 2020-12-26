using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    public static UpdateScore instance;
    Camera mainCamera;
    Canvas canv;
    bool passed = false;
    public int highScore;
    int tempScore = 0;

    // Start is called before the first frame update
    private void Awake()
    {
        mainCamera = Camera.main;
        GameObject tempObject = GameObject.Find("Canvas");
        if (tempObject != null)
        {
            canv = tempObject.GetComponent<Canvas>();
            if (canv == null)
            {
                Debug.Log("Could not locate Canvas component on " + tempObject.name);
            }
        }

        instance = this;
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
            GameObject tempTxt = canv.transform.GetChild(1).gameObject;
            Text highScoreText = tempTxt.GetComponent<Text>();
            highScoreText.text = "High Score:" + highScore.ToString();

        }
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(mainCamera.transform.parent.transform.position.z > transform.position.z && !passed)
        {
            passed = true;
            GameObject tempTxt = canv.transform.GetChild(0).gameObject;
            Text txt = tempTxt.GetComponent<Text>();
            string tempString = new String(txt.text.Where(Char.IsDigit).ToArray());
            tempScore = int.Parse(tempString);
            tempScore++;
            txt.text = "Score:" + tempScore.ToString();
            UpdateHighScore();
        }
    }
    public void UpdateHighScore()
    {
        if(tempScore > highScore)
        {
            highScore = tempScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            GameObject tempTxt = canv.transform.GetChild(1).gameObject;
            Text highScoreText = tempTxt.GetComponent<Text>();
            highScoreText.text = "High Score:" + highScore.ToString();
        }
    }
}
