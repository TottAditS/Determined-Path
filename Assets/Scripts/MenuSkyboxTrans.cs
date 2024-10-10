using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSkyboxTrans : MonoBehaviour
{
    public Material[] Langit;
    public GameObject siang;
    public GameObject malam;
    public void setskyday()
    {
        RenderSettings.skybox = Langit[0];
        siang.SetActive(true);
        malam.SetActive(false);

    }

    public void setskynight()
    {
        RenderSettings.skybox = Langit[1];
        siang.SetActive(false);
        malam.SetActive(true);
    }
}
