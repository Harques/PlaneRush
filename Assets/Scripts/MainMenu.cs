using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public void SoundControl()
    {
        Image tempImage = GetComponent<Image>();
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
