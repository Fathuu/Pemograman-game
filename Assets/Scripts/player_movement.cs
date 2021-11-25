using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    //Variabel
    [SerializeField] public float kecepatan;
    public float x;
    public float z;
    [SerializeField] private float Speed_jump = 2f;
    [SerializeField] private float Speed_walk = 2f;
    [SerializeField] public float Speed_Run = 7f;
    [SerializeField] private float gravitasi = -20f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    public bool isGrounded;
    Vector3 velocity;

    //Referensi
    private CharacterController Controller;

    // Start is called before the first frame update
    void Start()
    {
        Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        grafity();
        Bergerak();
        Lompat();
        Jalan();
    }

    private void Bergerak()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        Vector3 gerak = transform.right * x + transform.forward * z;
        Controller.Move(gerak * kecepatan * Time.deltaTime);
    }

    private void grafity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravitasi * Time.deltaTime;
        Controller.Move(velocity * Time.deltaTime);
    }

    private void Lompat()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(Speed_jump * -2f * gravitasi);
        }

        velocity.y += gravitasi * Time.deltaTime;
        Controller.Move(velocity * Time.deltaTime);

    }

    private void Jalan()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            kecepatan = Speed_Run;
        }
        else
        {
            kecepatan = Speed_walk;
        }
    }

}
