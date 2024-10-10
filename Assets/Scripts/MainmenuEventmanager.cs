using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainmenuEventmanager : MonoBehaviour
{
    [Header("Main Menu Panel")]

    public Button playbutton;
    public Button settingButton;
    public Button exitButton;

    [Header("Setting Panel")]

    public Button Howtoplaybutton;
    public Button backtomainbutton;
    public Slider mastervolume;
    public Slider sfxvolume;
    public Toggle Isfullscreen;

    [Header("How To Play Panel")]

    public Button backtosettingbutton;

    [Header("Select Level Panel")]

    public Button scene1;
    public Button scene2;
    public Button scenetut;
    public GameObject lockedlv2;
    public GameObject lights;

    [Header("Others")]
    public Camera maincam;
    public GameObject loadingpanel;
    private Animator ANImain;
    private Animator ANIlight;
    private string selectedscene;

    [Header("Sound Panel")]
    public Slider musicslider;
    public Slider sfxslider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Lv2unlocked"))
        {
            float key = PlayerPrefs.GetInt("Lv2unlocked");

            if (key == 1)
            {
                scene2.interactable = true;
                lockedlv2.SetActive(false);
            }
            else
            {
                scene2.interactable = false;
            }
        }
        else
        {
            scene2.interactable = false;
        }

        ANImain = maincam.GetComponent<Animator>();
        ANIlight = lights.GetComponent<Animator>();
        loadingpanel.SetActive(false);
        ANImain.SetBool("goseting", false);
        ANImain.SetBool("golevel", false);

        AudioManager.instance.stopmusic();
        AudioManager.instance.playmusic("Main Theme");

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

    //main menu buttons
    public void Aplaybut()
    {
        ANImain.SetBool("golevel", true);
    }

    public void Asettingbut()
    {
        ANImain.SetBool("goseting", true);
    }

    public void Aexitbut()
    {
        Application.Quit();
    }

    //setting buttons

    public void Asettingbacktomainbut()
    {
        ANImain.SetBool("goseting", false);
    }

    public void Ahowtoplay()
    {

    }

    //how to play panel buttons
    public void Ahowbacktosettingbut()
    {
        
    }

    // level buttons 
    public void Alevelbacktomainbut()
    {
        ANImain.SetBool("golevel", false);
    }
    public void Ascene1Tutbut()
    {
        selectedscene = "TUT";
    }
    public void Ascene1daybut()
    {
        selectedscene = "DAY";
    }
    public void Ascene2nightbut()
    {
        selectedscene = "NIGHT";
    }

    public void dayskybox() 
    {
        ANIlight.SetBool("MALAM", false);
    }

    public void nightskybox()
    {
        ANIlight.SetBool("MALAM", true);
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

    //Loading

    public void loadingscene()
    {

        Invoke("Achangescene", 2);
    }
    public void Achangescene()
    {
        SceneManager.LoadScene(selectedscene);
    }
}
