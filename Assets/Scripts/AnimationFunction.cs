using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFunction : MonoBehaviour
{
    [SerializeField] MenuButtonController MenuButtonController;

    void PlaySound(AudioClip whichSound)
    {
        MenuButtonController.AudioSource.PlayOneShot(whichSound);
    }
}
