using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject arrows;

    public void Active()
    {
        if (!arrows.activeSelf)
        {
            arrows.SetActive(true);
        }
        else
        {
            arrows.SetActive(false);
        }
        
    }

}
