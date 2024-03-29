using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamerashacky : MonoBehaviour
{
    [SerializeField] private float power = 0.05f;
    [SerializeField] private float duration = 0f;
    private float slowDownAmount = 1f;
    private bool shouldShake = false;
    public Transform kamera;
    Vector3 startPosition;
    float initialDuration;

    // Start is called before the first frame update
    void Start()
    {
        kamera = Camera.main.transform;
        startPosition = kamera.localPosition;
        initialDuration = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldShake)
        {
            kamera.localPosition = startPosition + Random.insideUnitSphere * power;
            duration += Time.deltaTime * slowDownAmount;

            if (duration > 4)
            {
                shouldShake = false;
                duration = initialDuration;
                kamera.localPosition = startPosition;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle")
        {
            shouldShake = true;
        }

        if (other.tag == "Enemy")
        {
            shouldShake = true;
        }
    }
}
