using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCircle : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform startPos;
    public int numberOfPrefabs;
    float next_step = 0;
    float startPosZ;
    float startPosX;
    float startPosY;
    float timer = 0.0f;
    public GameObject[] Prefabs;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime/10000;
        GameObject[] circles = GameObject.FindGameObjectsWithTag("Circle");
        
        if (circles.Length <= 5)
        {
            next_step += 10f;
            int index = Random.Range(0, numberOfPrefabs);
            
            GameObject tempPrefab = Prefabs[index];
            if (tempPrefab.name == "Triangle")
            {
                startPosX = 1.5f;
                startPosY = -1f;
            }
            else if(tempPrefab.name == "Square")
            {
                startPosX = 1f;
                startPosY = -1f;
            }
            else if (tempPrefab.name == "Hexagon")
            {
                startPosX = 0.2f;
                startPosY = -1f;
            }
            else
            {
                startPosX = 0f;
                startPosY = 0f;
            }
            GameObject tempCircle = Instantiate(tempPrefab, new Vector3(startPosX + Random.Range(-0.25f, 0.25f), Random.Range(-0.8f, 0.8f) + startPosY, startPosZ + next_step + timer), tempPrefab.transform.rotation);
            Color tempColor = tempCircle.GetComponent<MeshRenderer>().material.color;
            tempColor.a = 0f;
            tempCircle.GetComponent<MeshRenderer>().material.color = tempColor;
        }
    }
}
