using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public void Audio()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
