using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animasi : MonoBehaviour
{
    //variabel
    private float nilai_x;
    private float nilai_z;
    private bool status_ground;

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
        status_ground = player.GetComponent<player_movement>().isGrounded;
        anim.SetFloat("x", nilai_x);
        anim.SetFloat("z", nilai_z);
        anim.SetBool("isGrounded", status_ground);
    }
}
