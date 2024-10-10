using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionControl : MonoBehaviour
{
    public GameObject eventsystem;

    public void GOtransition()
    {
        eventsystem.SetActive(false);
    }

    public void ENDtransition()
    {
        eventsystem.SetActive(true);
    }
}
