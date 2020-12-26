using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAway : MonoBehaviour
{
    float solidDistance = 5f;
    float dist;
    Renderer render;
    Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        render = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(transform.position, mainCamera.transform.parent.position);
        Color color = render.material.color;
        if (dist < solidDistance) dist = solidDistance;
        if (dist >= 2 * solidDistance)
            color.a = 0;
        else
        {
            StartCoroutine(FadeTo(1f, .5f));
        }

        render.material.color = color;
    }
    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = transform.GetComponent<Renderer>().material.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            transform.GetComponent<Renderer>().material.color = newColor;
            yield return null;
        }
    }
}
