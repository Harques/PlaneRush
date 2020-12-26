using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WaitForInput : MonoBehaviour
{
    public bool gameStarted = false;
    private bool uiBool = false;
    public GameObject instruction, score, info, arrows;
    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale = 0;
    }
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))
                uiBool = true;
        }
        if (Input.touchCount>0 && !uiBool)
        {
            instruction.SetActive(false);
            score.SetActive(true);
            info.SetActive(false);
            arrows.SetActive(false);
            Time.timeScale = 1f;
            gameStarted = true;
        }
        if (Input.GetMouseButtonDown(0) && !IsPointerOverUIObject())
        {
            gameStarted = true;
            score.SetActive(true);
            instruction.SetActive(false);
            info.SetActive(false);
            arrows.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
