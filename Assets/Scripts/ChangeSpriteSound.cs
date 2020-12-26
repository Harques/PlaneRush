using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSpriteSound : MonoBehaviour
{
    private void Awake()
    {
        if(AudioListener.pause == true)
        {
            Image tempImage = GetComponent<Image>();
            Sprite temp = Resources.Load<Sprite>("ColorfulButtons/SoundOff");
            tempImage.sprite = temp;
        }
    }
}
