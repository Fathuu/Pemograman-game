using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animasi : MonoBehaviour
{
    //variabel
    [SerializeField] private float nilai_x;
    [SerializeField] private float nilai_z;
    private bool status_ground;
    public float kecepatan_pemain;

    //referensi
    private Animator anim;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        nilai_x = player.GetComponent<player_movement>().x;
        nilai_z = player.GetComponent<player_movement>().z;
        kecepatan_pemain = player.GetComponent<player_movement>().kecepatan;
        //status_ground = player.GetComponent<player_movement>().isGrounded;
        if (Input.GetButtonDown("Jump"))
        {
            status_ground = true;
        }
        else
        {
            status_ground = false;
        }
        anim.SetFloat("x", nilai_x);
        anim.SetFloat("z", nilai_z);
        anim.SetBool("isGrounded", status_ground);
    }
}
