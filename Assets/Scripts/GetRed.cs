using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRed : MonoBehaviour
{
    public Material material;
    public float transitionSpeed = 0.1f;
    public float lerp;
    
    public float increaseAmount = 0.1f;
    public float decreaseAmount = 0.05f;
    public float decreaseInterval = 0.1f;
    private float timeSinceLastDecrease = 0f;

    void Start()
    {
        lerp = 0;
    }
    void Update()
    {
        if(lerp < 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                lerp += increaseAmount;
                lerp = Mathf.Clamp01(lerp); // mantém o valor entre 0 e 1
            }

            // diminui gradualmente o valor com o tempo
            timeSinceLastDecrease += Time.deltaTime;
            if (timeSinceLastDecrease >= decreaseInterval)
            {
                lerp -= decreaseAmount;
                lerp = Mathf.Clamp01(lerp); // mantém o valor entre 0 e 1
                timeSinceLastDecrease = 0f;
            }
            
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            lerp -= decreaseAmount;
        }

        material.SetFloat("_Lerp", lerp);
    }
}
