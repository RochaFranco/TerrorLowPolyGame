using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float moveSpeed = 5f;        // Velocidad de movimiento del jugador
    public float mouseSensitivity = 100f; // Sensibilidad del mouse
    public Transform playerCamera;      // Asigna la c�mara en el Inspector

    float xRotation = 0f;               // Para el manejo de la rotaci�n vertical de la c�mara

    void Start()
    {
        // Bloquea el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Movimiento del mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Control de rotaci�n vertical (c�mara)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);  // Limita la rotaci�n vertical entre -80 y 80 grados

        // Aplicamos la rotaci�n al objeto c�mara
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);  // Rotaci�n horizontal del jugador

        // Movimiento del jugador (WASD)
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);
    }

}
