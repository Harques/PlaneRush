using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnv : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform startPos;
    GameObject Env;
    float next_step = 0;
    Object variableForPrefab;
    void Start()
    {
        variableForPrefab = Resources.Load("Prefabs/Environment Prefabs/Env");
        Env = (GameObject)variableForPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] envs = GameObject.FindGameObjectsWithTag("Environment");
        if (envs.Length<=2)
        {
            next_step += 98f;
            Instantiate(Env, new Vector3(startPos.position.x, startPos.position.y, startPos.transform.position.z + next_step), Quaternion.identity);
        }
        
    }

}