using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Scene1Eventmanager : MonoBehaviour
{
    [Header("PausePanel")]
    public GameObject pausepanel;
    public bool pausebuttonpressed;
    public bool istutpanelpressed;

    [Header("SettingPanel")]
    public GameObject settingpanel;
    public Toggle fullscreen;

    [Header("Sound Panel")]
    public Slider musicslider;
    public Slider sfxslider;

    [Header("istutorial Panel")]
    public GameObject istutpanel;
    public GameObject allguidetrigger;
    public InteractionSC interactionSC;

    [Header("WinCondition")]
    public HalteScript haltescript;
    public BusReputation busreputation;
    public TextMeshProUGUI condition_Text;
    public GameObject winpanel;
    public GameObject losepanel;
    


    private void Start()
    {
        pausebuttonpressed = false;

        if (SceneManager.GetActiveScene() != null)
        {
            string sceneName = SceneManager.GetActiveScene().name;

            if (sceneName == "DAY")
            {
                AudioManager.instance.stopmusic();
                AudioManager.instance.playmusic("Level-1-Music");
            }
            else if (sceneName == "TUT")
            {
                AudioManager.instance.stopmusic();
                AudioManager.instance.playmusic("Level-1-Music");
            }
            else if (sceneName == "NIGHT")
            {
                AudioManager.instance.stopmusic();
                AudioManager.instance.playmusic("Level-2-Music");
            }
        }

        if (PlayerPrefs.HasKey("MusicVolumes"))
        {
            float savedmusicvol = PlayerPrefs.GetFloat("MusicVolumes");
            musicslider.value = savedmusicvol;
            AudioManager.instance.musicvolume(savedmusicvol);
        }
        else
        {
            musicslider.value = 1;
            AudioManager.instance.musicvolume(1);
        }

        if (PlayerPrefs.HasKey("SFXVolumes"))
        {
            float sfxvol = PlayerPrefs.GetFloat("SFXVolumes");
            sfxslider.value = sfxvol;
            AudioManager.instance.SFXvolume(sfxvol);
        }
        else
        {
            musicslider.value = 1;
            AudioManager.instance.SFXvolume(1);
        }
    }

    private void FixedUpdate() 
    {
        if (pausebuttonpressed)
        {
            //Debug.Log("PAUSED");
            Time.timeScale = 0f;
            pausepanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        else if (!pausebuttonpressed)
        {
            //Debug.Log("UNPAUSED");
            Time.timeScale = 1.0f;
            pausepanel.SetActive(false);
        }
        //if (istutpanelpressed)
        //{
        //    Time.timeScale = 0f;
        //    istutpanel.SetActive(true);
        //    Cursor.lockState = CursorLockMode.None;
        //}
        //else if (!istutpanelpressed)
        //{
        //    Debug.Log("UNPAUSED");
        //    Time.timeScale = 1.0f;
        //    istutpanel.SetActive(false);
        //}
    }

    public void AAdisabletutorial()
    {
        allguidetrigger.SetActive(false);
        istutpanelpressed = false;
        istutpanel.SetActive(false);
        interactionSC.currentindex = 99;
    }
    public void AAenableTutorial()
    {
        allguidetrigger.SetActive(false);
        istutpanelpressed = false;
        istutpanel.SetActive(false);
    }

    public void AAbacktogamebutton()
    {
        Time.timeScale = 1.0f;
        pausepanel.SetActive(false);
        pausebuttonpressed = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void AARestartgamebutton()
    {
        Time.timeScale = 1.0f;
        pausepanel.SetActive(false);
        pausebuttonpressed = false;
        Cursor.lockState = CursorLockMode.Locked;
        //Debug.Log(SceneManager.GetActiveScene().name);
        AudioManager.instance.SFXsource.Stop();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AAbacktomainmenubutton()
    {
        Time.timeScale = 1.0f;
        pausepanel.SetActive(false);
        pausebuttonpressed = false;
        AudioManager.instance.SFXsource.Stop();
        SceneManager.LoadScene("Mainmenu");

    }

    public void checkwincondition()
    {
        if (haltescript.haltevisited >= 9)
        {
            if (busreputation.IsGameOver == false)
            {
                if (busreputation.reputation < 55)
                {
                    //Debug.Log("kalah dibawah D");
                    YouLose();

                    AudioManager.instance.playSFX("Reputation Alarm");
                    condition_Text.text = "Your reputation is below D";
                }
                else
                {
                    Debug.Log("Gacor");
                    YouWin();

                    PlayerPrefs.SetInt("Lv2unlocked", 1);
                }
            }
            else
            {
                //Debug.Log("kalah dibawah fffffff");
                YouLose();

                AudioManager.instance.playSFX("Reputation Alarm");
                condition_Text.text = "Your reputation is too low";
            }
        }
        else
        {
            //Debug.Log("kalah kabur");
            YouLose();

            AudioManager.instance.playSFX("Reputation Alarm");
            condition_Text.text = "You didn't visited some station";
        }
    }

    public void YouWin()
    {
        winpanel.SetActive(true);
        Invoke("pausinggame", 0);
    }

    public void YouLose()
    {
        losepanel.SetActive(true);
        Invoke("pausinggame", 0);
    }

    public void togglemusic()
    {
        AudioManager.instance.togglemusic();
    }
    public void toggleSFX()
    {
        AudioManager.instance.toggleSFX();
    }
    public void musicvolume()
    {
        AudioManager.instance.musicvolume(musicslider.value);
    }
    public void SFXvolume()
    {
        AudioManager.instance.SFXvolume(sfxslider.value);
    }
    public void togglefullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void pausinggame()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }

    public void continuegame()
    {
        Time.timeScale = 1;
    }

}
