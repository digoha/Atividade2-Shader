using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Velocidade de movimento do jogador.
    public Camera mainCamera;    // Refer�ncia � c�mera principal.

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Obtenha o Rigidbody2D do jogador.
    }

    void Update()
    {
        // Obter entrada de teclado.
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        // Calcular a dire��o de movimento relativa � c�mera.
        Vector3 cameraForward = mainCamera.transform.forward;
        cameraForward.y = 0f;
        cameraForward.Normalize();
        Vector3 cameraRight = mainCamera.transform.right;
        cameraRight.y = 0f;
        cameraRight.Normalize();
        Vector3 movement = (moveHorizontal * cameraRight + moveVertical * cameraForward).normalized;

        // Aplicar a for�a de movimento no jogador.
        rb.velocity = movement * moveSpeed;
    }
}
