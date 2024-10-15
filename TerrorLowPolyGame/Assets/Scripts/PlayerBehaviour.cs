using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float moveSpeed = 5f;        // Velocidad de movimiento del jugador
    public float mouseSensitivity = 100f; // Sensibilidad del mouse
    public Transform playerCamera;      // Asigna la cámara en el Inspector

    float xRotation = 0f;               // Para el manejo de la rotación vertical de la cámara

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

        // Control de rotación vertical (cámara)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);  // Limita la rotación vertical entre -80 y 80 grados

        // Aplicamos la rotación al objeto cámara
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);  // Rotación horizontal del jugador

        // Movimiento del jugador (WASD)
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);
    }

}
