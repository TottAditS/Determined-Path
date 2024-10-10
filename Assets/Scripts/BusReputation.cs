using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BusReputation : MonoBehaviour
{
    public int reputation = 100;
    public TextMeshProUGUI reputationText;
    public bool IsGameOver;
    public CarController buspeed;
    public TrafficScript trafficScript;

    [Header("Driver Rating")]
    public TextMeshProUGUI driver_text;
    public int rating = 100;

    private void Start()
    {
        
        IsGameOver = false;
        reputation = 100;
        rating = 100;
        UpdateReputationUI();
        UpdateRating();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barrier") || other.CompareTag("Car"))
        {
            DecreaseReputation(1); 
            DecreaseRating(3);
        }

        if (other.CompareTag("TrafficLight"))
        {
            //trafficScript = other.GetComponent<TrafficScript>();

            if (trafficScript.currentLightState == TrafficScript.LightState.Red && buspeed.speed < 3)
            {
                DecreaseReputation(3);
                DecreaseRating(5);
            }
        }
    }
    public void DecreaseReputation(int amount)
    {
        reputation -= amount;
        UpdateReputationUI();

        if (reputation <= 0)
        {
            IsGameOver = true;
        }
    }
    public void IncreaseReputation(int amount)
    {
        if (reputation < 100)
        {
            if (reputation + amount > 100)
            {
                reputation = 100;
            }
            else
            {
                reputation += amount;
            }
        }

        UpdateReputationUI();
    }

    public void DecreaseRating(int amount)
    {
        rating -= amount;
        UpdateRating();

        if (rating <= 0)
        {
            IsGameOver = true;
        }
    }
    public void IncreaseRating(int amount)
    {
        if (rating < 100)
        {
            if (rating + amount > 100)
            {
                rating = 100;
            }
            else
            {
                rating += amount;
            }
        }

        UpdateRating();
    }

    private void UpdateRating()
    {
        driver_text.text = "Driver Rating: " + rating.ToString() + "%";
    }

    private void UpdateReputationUI()
    {
        if (reputation > 94)
        {
            reputationText.color = Color.green;
            reputationText.text = "Reputation: A";
        }
        else if (reputation > 84 && reputation < 95)
        {
            reputationText.color = Color.green;
            reputationText.text = "Reputation: B";
        }
        else if (reputation > 69 && reputation < 85)
        {
            reputationText.color = Color.yellow;
            reputationText.text = "Reputation: C";
        }
        else if (reputation > 54 && reputation < 70)
        {
            reputationText.color = Color.yellow;
            reputationText.text = "Reputation: D";
        }
        else if (reputation > 29 && reputation < 55)
        {
            reputationText.color = Color.red;
            reputationText.text = "Reputation: E";
        }
        else
        {
            reputationText.color = Color.red;
            reputationText.text = "Reputation: F";
            AudioManager.instance.playSFX("Reputation Alarm");
        }
    }
}