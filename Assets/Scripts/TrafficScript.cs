using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficScript : MonoBehaviour
{
    public enum LightState { Red, Green, Yellow }
    public LightState currentLightState;
    public float lightDuration = 10f; 

    [Header("Aset")]
    public GameObject trafficlightred;
    public GameObject trafficlightyellow;
    public GameObject trafficlightgreen;

    public GameObject trafficlightred1;
    public GameObject trafficlightyellow1;
    public GameObject trafficlightgreen1;

    private void Start()
    {
        StartCoroutine(CycleLights());
    }

    private IEnumerator CycleLights()
    {
        while (true)
        {
            currentLightState = LightState.Red;
            //Debug.Log("lampu merah");
            trafficlightred.SetActive(true);
            trafficlightgreen.SetActive(false);
            trafficlightred1.SetActive(true);
            trafficlightgreen1.SetActive(false);
            yield return new WaitForSeconds(lightDuration);

            currentLightState = LightState.Yellow;
            //Debug.Log("lampu hijau");
            trafficlightred.SetActive(false);
            trafficlightyellow.SetActive(true);
            trafficlightred1.SetActive(false);
            trafficlightyellow1.SetActive(true);
            yield return new WaitForSeconds(2);

            currentLightState = LightState.Green;
            //Debug.Log("lampu hijau");
            trafficlightgreen.SetActive(true);
            trafficlightyellow.SetActive(false);
            trafficlightgreen1.SetActive(true);
            trafficlightyellow1.SetActive(false);
            yield return new WaitForSeconds(lightDuration);
        }
    }
}
