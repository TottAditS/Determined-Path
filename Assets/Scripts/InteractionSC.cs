using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionSC : MonoBehaviour
{
    public int currentindex = 0;

    [Header("Teks")]
    public TextMeshProUGUI guide_text;
    public GameObject gambar;
    public GameObject guidepanel;

    private void Start()
    {
        currentindex = 0;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interaction") == true)
        {
            //Debug.Log("duhle");
            getguidetext();
            guidepanel.SetActive(true);
            other.gameObject.SetActive(false);
        }
    }

    public void getguidetext()
    {

        if (currentindex == 99)
        {
            guide_text.text = "Welcome to Determined Path, Good Luck!";
        }

        if (currentindex == 0)
        {
            //Debug.Log("duhle1");
            guide_text.text = "Welcome to Determined Path, Before we begin, please, move to the highlighted spot";
            gambar.SetActive(false);
            Invoke("disablepanel", 3);
        }

        else if (currentindex == 1)
        {
            guide_text.text = "Upon arriving at the stop, please keep the bus stationary until" +
            " the passenger unloading process is complete, You can check the information panel for the status";

            gambar.SetActive(false);
            Invoke("disablepanel", 8);
        }

        else if (currentindex == 2)
        {
            guide_text.text = "Good, now please pay attention to the road and enter the bus lane";

            gambar.SetActive(false);
            Invoke("disablepanel", 3);
        }

        else if (currentindex == 3)
        {
            guide_text.text = "Goood, now follow this bus lane until you reach the first stop";

            gambar.SetActive(false);
            Invoke("disablepanel", 3);
        }

        else if (currentindex == 4)
        {
            guide_text.text = "Great, You have arrived, now do the same as you did at the previous terminal, keep the bus stationary";

            gambar.SetActive(false);
            Invoke("disablepanel", 6);
        }

        else if (currentindex == 5)
        {
            guide_text.text = "Now follow this bus lane until you reach the second stop, as you can see the green icon on your minimap";

            gambar.SetActive(false);
            Invoke("disablepanel", 3);
        }

        else if (currentindex == 6)
        {
            guide_text.text = "There's a traffic light ahead. You know the rules, red means stop, green means go";

            gambar.SetActive(false);
            Invoke("disablepanel", 3);
        }

        else if (currentindex == 7)
        {
            guide_text.text = "Please turn right at this intersection";

            gambar.SetActive(false);
            Invoke("disablepanel", 3);
        }

        else if (currentindex == 8)
        {
            guide_text.text = "Nice work, now stay on this lane until the next intersection";

            gambar.SetActive(false);
            Invoke("disablepanel", 3);
        }

        else if (currentindex == 9)
        {
            guide_text.text = "Up ahead is the final stop. Remember to apply what we've learned";

            gambar.SetActive(false);
            Invoke("disablepanel", 3);
        }

        else if (currentindex == 10)
        {
            guide_text.text = "Great, now head back to the terminal, stay on the road";

            gambar.SetActive(false);
            Invoke("disablepanel", 3);
        }

        else if (currentindex == 11)
        {
            guide_text.text = "Congratulations, you’ve completed your task! Thank you for playing. Proceed to the highlighted spot";

            gambar.SetActive(false);
            Invoke("disablepanel", 3);
        }
    }

    public void disablepanel()
    {
        guidepanel.SetActive(false);
        currentindex++;
    }
}
