using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighthing : MonoBehaviour
{
    float time;
    GameObject[] allrights;

    // Start is called before the first frame update
    void Start()
    {
        allrights = GameObject.FindGameObjectsWithTag("My Lighting");
    }

    // Update is called once per frame
    void Update()
    {
        time = EnviroSky.instance.GameTime.Hours;

        if(time < 17 && time > 6)
        {
            foreach(GameObject i in allrights)
            {
                i.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject i in allrights)
            {
                i.SetActive(true);
            }
        }
    }
}
