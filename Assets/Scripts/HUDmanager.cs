using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDmanager : MonoBehaviour
{
    public Image currentEnergy;
    public Text time;

    private GameObject player;

    private float energy = 200;
    private float maxenergy = 200;
    private float kecepatan;
    private float kecepatanLari;
    private float input_x;
    private float input_z;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        kecepatanLari = player.GetComponent<player_movement>().Speed_Run;
    }

    // Update is called once per frame
    void Update()
    {
        kecepatan = player.GetComponent<player_movement>().kecepatan;
        input_x = player.GetComponent<player_movement>().x;
        input_z = player.GetComponent<player_movement>().z;

        EnergyDrain();
        updateEnergy();
        updatetime();
    }

    private void EnergyDrain()
    {
        if (kecepatan == kecepatanLari)
        {
            if(input_x > 0 || input_z > 0)
            {
                if(energy > 0)
                {
                    energy -= 10 * Time.deltaTime;
                }
            }
        }
        else
        {
            if(energy < maxenergy)
            {
                energy += 15 * Time.deltaTime;
            }
        }

    }

    private void updateEnergy()
    {
        float ratio = energy / maxenergy;
        currentEnergy.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    private void updatetime()
    {
        int hours = EnviroSky.instance.GameTime.Hours;
        int minutes = EnviroSky.instance.GameTime.Minutes;
        string gamehours;
        string gameminutes;


        if(hours >= 0 && hours < 10)
        {
            gamehours = "0" + hours.ToString();
        }
        else
        {
            gamehours = hours.ToString();
        }

        if (minutes >= 0 && minutes < 10)
        {
            gameminutes = "0" + minutes.ToString();
        }
        else
        {
            gameminutes = minutes.ToString();
        }

        time.text = gamehours + " : " + gameminutes;
    }
}
