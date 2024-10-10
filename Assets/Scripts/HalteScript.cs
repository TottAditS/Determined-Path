using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HalteScript : MonoBehaviour
{
    public List<string> locations;
    public int currentIndex = 0;
    public GameObject eventsystem;
    public Rigidbody bus;
    public int haltevisited;
    public float timer;
    public bool iswaiting;

    [Header("Bus Trajectory")]
    public TextMeshProUGUI currlocate;
    public TextMeshProUGUI nextlocate;
    public TextMeshProUGUI text_notif;
    public TextMeshProUGUI text_status;

    [Header("Bus Reputation")]
    public Scene1Eventmanager eventmanager;
    public BusReputation busReputation;
    public CarController carController;
    public HalteManager halteManager;

    [Header("Bus Capacity")]
    public TextMeshProUGUI buscaptext;
    public Slider buscapslider;
    public int randompeople;
    public int maxcap = 20;
    public int currcap;
    private void Start()
    {
        haltevisited = 0;
        currcap = 0;
        timer = 12f;
        iswaiting = false;
    }  
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Halte") == true)
        {
            text_status.text = "Arrived";
            text_status.color = Color.green;

            string locationName = other.gameObject.name;

            if (locationName == "TerminalB")
            {
                currlocate.text = "Current Location: " + locationName;
                text_notif.text = "Opening Door";
                text_notif.color = Color.red;

                currcap = 0;
                Invoke("OpenDoor", 2);
                //bus.velocity = Vector3.zero;
                //currentIndex++; 
                eventmanager.checkwincondition();
            }
            //Debug.Log(locationName);

           
            if (locationName == locations[currentIndex])
            {
                if (halteManager == null)
                {
                    halteManager = other.GetComponent<HalteManager>();
                }

                currlocate.text = "Current Location: " + locationName;
                text_notif.text = "Opening Door";
                text_notif.color = Color.red;

                AudioManager.instance.playSFX("Door Open");
                AudioManager.instance.playSFX("CrowdSound");
                Invoke("OpenDoor", 2);
                //bus.velocity = Vector3.zero;
                currentIndex++; 
                UpdateLocationUI();
                haltevisited++;
            }
        }
    }
    public void OpenDoor()
    {
        currcap = currcap - Random.Range(1, 5);
        if (currcap < 1)
        {
            currcap = 0;
        }
        if (currcap > 20)
        {
            currcap = 20;
        }
        buscapslider.value = currcap;

        text_notif.text = "Door Open";
        text_status.text = "Stationary";

        text_notif.color = Color.green;
        text_status.color = Color.red;

        AudioManager.instance.playSFX("Station Sound");

        //bus.velocity = Vector3.zero;
        Invoke("waiting",2);
    }

    void Update()
    {
        if (iswaiting)
        {
            timer -= Time.deltaTime;

            if (timer < 1f || carController.speed > 5f)
            {
                if (timer < 1f)
                {
                    //Debug.Log("nunggu kelar");
                    iswaiting = false;
                    CloseDoor();
                }

                else if (carController.speed > 5f)
                {
                    //Debug.Log("darurat");
                    iswaiting = false;
                    emergencyclose();
                }
            }
        }
    }

    public void waiting()
    {
        iswaiting = true;
        timer = 12f;
        //Debug.Log("menunggu mulai");
    }

    public void CloseDoor()
    {
        currcap = currcap + Random.Range(1, 5);
        if (currcap < 1)
        {
            currcap = 0;
        }
        if (currcap > 20)
        {
            currcap = 20;
        }
        buscapslider.value = currcap;

        text_notif.text = "Closing Door";
        text_status.text = "Standby";

        text_notif.color = Color.red;
        text_status.color = Color.yellow;

        AudioManager.instance.playSFX("Door Close");
        //HalteManager.instance.DestroyPeopleAtHalte();
        busReputation.IncreaseRating(5);

        halteManager.DestroyPeopleAtHalte();
        halteManager = null;
        Invoke("erasetext", 2);
    }

    public void emergencyclose()
    {

        currcap = currcap + Random.Range(1, 3);
        if (currcap < 1)
        {
            currcap = 0;
        }
        if (currcap > 20)
        {
            currcap = 20;
        }
        buscapslider.value = currcap;

        text_notif.text = "Closing Door";
        text_status.text = "Standby";

        text_notif.color = Color.red;
        text_status.color = Color.red;

        AudioManager.instance.playSFX("Door Close");
        Invoke("erasetext", 2);
        halteManager = null;
        busReputation.DecreaseReputation(5);
        busReputation.DecreaseRating(5);
    }

    public void erasetext()
    {
        currlocate.text = "Current Location: OnRoute";

        text_notif.text = "Door Closed";
        text_status.text = "OnRoute";

        text_notif.color = Color.green;
        text_status.color = Color.green;

        //busReputation.IncreaseReputation(10);
    }

    private void UpdateLocationUI()
    {
        if (currentIndex < locations.Count)
        {
            nextlocate.text = "Next Location: " + locations[currentIndex];
        }
        else
        {
            nextlocate.text = "End of Route, Return to Terminal";
        }
    }
}
