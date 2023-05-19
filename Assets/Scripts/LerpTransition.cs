using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTransition : MonoBehaviour
{
    public Material material;
    public float transitionSpeed = 0f;
    public float lerp;
    // Start is called before the first frame update
    void Start()
    {
        lerp = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Transition());
        }
    }

    IEnumerator Transition()
    {
        while (lerp < 1)
        {
            lerp += Time.deltaTime * transitionSpeed;
            material.SetFloat("_Lerp", lerp);
            yield return null;
        }
    }
    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(TransitionBack());
        }
    }

    IEnumerator TransitionBack()
    {
        while (lerp > 0)
        {
            lerp -= Time.deltaTime * transitionSpeed;
            material.SetFloat("_Lerp", lerp);
            yield return null;
        }
    }
}

