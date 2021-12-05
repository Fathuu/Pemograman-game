using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDmanager : MonoBehaviour
{
    public Image currentEnergy;
    public Text time;
    [SerializeField] GameObject PauseMenu;
    public static bool GameIsPaused = false;
    public Player playerInstance;

    private GameObject player;

    private float energy = 200;
    private float maxenergy = 200;
    private float kecepatan;
    private float kecepatanLari;
    private float input_x;
    private float input_z;

    //HUD DARAH
    private float darah;
    private float maxdarah = 100f;
    public Image currentDarah;

    [SerializeField] GameObject GameOverMenu;
    [SerializeField] GameObject informasi;
    string info;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        kecepatanLari = player.GetComponent<player_movement>().Speed_Run;

        GameIsPaused = false;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        kecepatan = player.GetComponent<player_movement>().kecepatan;
        input_x = player.GetComponent<player_movement>().x;
        input_z = player.GetComponent<player_movement>().z;
        darah = player.GetComponent<system_Darah>().darah_player;
        info = player.GetComponent<system_Darah>().info;

        Text pesan = informasi.GetComponent<Text>();
        pesan.text = info;

        EnergyDrain();
        updateEnergy();
        updatetime();
        ShowPause();
        Updatedarah();
        gameover();
    }

    private void EnergyDrain()
    {
        if (kecepatan == kecepatanLari)
        {
            if (input_x > 0 || input_z > 0)
            {
                if (energy > 0)
                {
                    energy -= 10 * Time.deltaTime;
                }
            }
        }
        else
        {
            if (energy < maxenergy)
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

    private void ShowPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void pause()
    {
        PauseMenu.SetActive(true);
        GameIsPaused = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void Save()
    {
        SaveSystem.SavePlayer(playerInstance);
    }

    private void Updatedarah()
    {
        float ratio = darah / maxdarah;
        currentDarah.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    public void gameover()
    {
        if (darah < 1)
        {
            //player mati
            GameOverMenu.SetActive(true);
            GameIsPaused = true;
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }

    public void restart()
    {
        SceneManager.LoadScene("Game Play");
    }
}
