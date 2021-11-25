using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour
{
    //Variabel
    [SerializeField] private float sensivity;
    [SerializeField] private float mouseX, mouseY;

    //Referansi
    public Transform Player, target;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (!HUDmanager.GameIsPaused)
        {
            mouseX += Input.GetAxis("Mouse X") * sensivity;
            mouseY -= Input.GetAxis("Mouse Y") * sensivity;

            mouseY = Mathf.Clamp(mouseY, -35, 60);
            transform.LookAt(target);

            target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            Player.rotation = Quaternion.Euler(0, mouseX, 0);
        }
    }
}