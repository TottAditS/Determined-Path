using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalteManager : MonoBehaviour
{
    public GameObject[] peopleAtHalte;
    //public static HalteManager instance;

    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //    }
    //    else
    //    {
    //        //Destroy(gameObject);
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        DestroyPeopleAtHalte();
    //    }
    //}
    public void DestroyPeopleAtHalte()
    {
        foreach (GameObject person in peopleAtHalte)
        {
            if (person != null)
            {
                Destroy(person);
            }
        }
    }
}
