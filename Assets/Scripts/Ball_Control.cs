using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Ball_Control : MonoBehaviour
{
    // Start is called before the first frame update
    private float vel = 6f;
    private Rigidbody rg;
    public Text txt;
    private bool isDead = false;
    float timer = 0.0f;
    public GameObject exp;
    public GameObject again , home, pause, sound,highScore;
    private Vector3 mouse_pos;
    void Start()
    {
        Physics.gravity = new Vector3(0,-6F,0);
        rg = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime/5000;
        if (isDead)
        {
            rg.velocity = new Vector3(0f, -vel, 0f);
        }
        
        if (Input.GetMouseButton(0) && !isDead && !IsPointerOverUIObject())
        {
            mouse_pos = Input.mousePosition;
            float upp;
            float sidee;
            float fp = Screen.width / 3;
            float xv = (mouse_pos.x - Screen.width / 2) / 256;
            if (xv < 0)
            {
                xv--;
                xv *= -1;
            }
            else
            {
                xv++;
            }
            if (mouse_pos.x > fp && mouse_pos.x < 2 * fp)
            {
                upp = 2.5f;
                sidee = 0f;
            }
            else
            {
                upp = 3f / xv;
                sidee = (mouse_pos.x - Screen.width / 2) / 256f;
            }
            Vector3 direction = new Vector3(sidee, upp, 0f);
            rg.velocity = direction;
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        x *= Time.deltaTime * vel;
        if (!isDead)
        {
            y = (Time.deltaTime * vel) + timer ;
        }
        transform.Translate(x, -y*Time.timeScale, 0f);
    }


    private void OnCollisionEnter(Collision collision)
    {
        isDead = true;
        exp.SetActive(true);
        again.SetActive(true);
        home.SetActive(true);
        pause.SetActive(false);
        sound.SetActive(true);
        rg.isKinematic = true;
        highScore.SetActive(true);
        DisableAllRenderers();
    }
    private void OnTriggerEnter(Collider other)
    {
        isDead = true;
        exp.SetActive(true);
        again.SetActive(true);
        home.SetActive(true);
        pause.SetActive(false);
        rg.isKinematic = true;
        sound.SetActive(true);
        highScore.SetActive(true);
        DisableAllRenderers();
        
    }
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
    void DisableAllRenderers()
    {
        MeshRenderer[] allRenderers;
        allRenderers = gameObject.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer childRenderer in allRenderers)
        {
            childRenderer.enabled = false;
        }
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
