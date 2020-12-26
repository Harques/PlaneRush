using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
public class ScoreManager : MonoBehaviour
{

    ///<summary>    The transform ofour player, for determining position. </summary>
    [Header("Please Drag Objects Here")]
    public Transform player;
    ///<summary>    The UI element to display our current score.              </summary>
    public Text currentScoreText;
    ///<summary>    The UI element to display our high score.                 </summary>
    public Text highScoreText;

    // Good idea to keep strings like this in a field, to avoid typos later.
    private const string highScoreKey = "HighScore";

    // Hold our score values.
    [Header("Do not change values")]
    [SerializeField] private int highScore = 0;
    [SerializeField] private int currentScore = 0;

    Camera mainCamera;
    Canvas canv;
    bool passed = false;
    ///<summary>
    /// Get our current high score if we have it and dipslay it in the UI.
    ///</summary>
    private void Start()
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
        // TODO: The high score could be retrieved in Awake()

        // Get the current high score from player prefs, 0 if id doesn't exist.
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);

        // Set the UI text to the current high score.
        highScoreText.text = highScore.ToString();
    }

    ///<summary>
    /// Calculate our current score based on z position. Display current score to UI.
    /// Check if current score is greater than high score. If so, update appropriately.
    ///</summary>
    private void Update()
    {
        if (mainCamera.transform.parent.transform.position.z > transform.position.z && !passed)
        {
            passed = true;
            GameObject tempTxt = canv.transform.GetChild(0).gameObject;
            Text txt = tempTxt.GetComponent<Text>();
            string tempString = new String(txt.text.Where(Char.IsDigit).ToArray());
            int tempScore = int.Parse(tempString);
            tempScore++;

            currentScoreText.text = "Score:" + tempScore.ToString();
        }

        // Check if our new score is greater than our previous high score.
        if (currentScore > highScore)
        {
            // Change the high score to the new current value.
            highScore = currentScore;
            // Update the high score UI text.
            highScoreText.text = highScore.ToString();

            // TODO: Delete me, unless for some odd reason I am needed... But I should not be :D
            PlayerPrefs.SetInt(highScoreKey, highScore);
            PlayerPrefs.Save();
        }
    }

    ///<summary>
    /// When this gameobject is disabled, save our players highscore.
    ///</summary?
    private void OnDisable()
    {
        /* 
         * OnDisable() is called anytime this object is disabled. This
         * includes changing scenes and quitting the application.
         */

        // Set our high score.
        PlayerPrefs.SetInt(highScoreKey, highScore);
        // Save our data.
        PlayerPrefs.Save();

        // TODO: Delete me, for debugging only!
        Debug.Log("I'm being Disabled! The high score is currently: " + highScore);
    }

    ///<summary>
    /// For testing only! Delete our PlayerPrefs and update UI.
    ///</summary>
    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        highScoreText.text = "unset";
    }
}