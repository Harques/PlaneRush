using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI , tapToPlay, info, arrows;
    bool tap = false;
    
    public void Resume()
    {
        GameObject input = GameObject.Find("WaitForInput");
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
        if (input.GetComponent<WaitForInput>().gameStarted) {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }
        if (tap)
        {
            tapToPlay.SetActive(true);
            tap = false;
            if (!info.activeSelf)
            {
                info.SetActive(true);
            }
        }
    }
    public void Pause()
    {
        if(tapToPlay.activeSelf)
        {
            tapToPlay.SetActive(false);
            tap = true;
        }
        if (arrows.activeSelf)
        {
            arrows.SetActive(false);
        }
        pauseMenuUI.SetActive(true);
        info.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void ShowMainMenu()
    {
        SceneManager.LoadScene("MainWindow");
    }
    public void SoundControl()
    {
        GameObject sound = pauseMenuUI.transform.Find("Sound").gameObject;
        Image tempImage = sound.GetComponent<Image>();
        if (AudioListener.pause == false)
        {
            AudioListener.pause = true;
            Sprite temp = Resources.Load<Sprite>("ColorfulButtons/SoundOff");
            tempImage.sprite = temp;

        }
        else if (AudioListener.pause == true)
        {
            AudioListener.pause = false;
            Sprite temp = Resources.Load<Sprite>("ColorfulButtons/SoundOn");
            tempImage.sprite = temp;
        }

    }
}
