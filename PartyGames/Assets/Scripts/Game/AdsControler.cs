 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsControler : MonoBehaviour
{
    public GameObject CanvasFinder;
    public int maxAdsAmount;
    public int minAdsAmount;
    public bool Fixed;
    public int adsFixed;
    public string nameLevel;

    public int adsCounterSwitch;
    public int adsMax;

    void Start()
    {

        CanvasFinder = GameObject.Find("Canvas");
        Fixed = CanvasFinder.GetComponent<LevelDataBehaviour>().Fixed;
        maxAdsAmount = CanvasFinder.GetComponent<LevelDataBehaviour>().adsMax;
        minAdsAmount = CanvasFinder.GetComponent<LevelDataBehaviour>().adsMin;
        nameLevel = CanvasFinder.GetComponent<LevelDataBehaviour>().levelName;
        adsFixed = CanvasFinder.GetComponent<LevelDataBehaviour>().adsFixed;
        if (Fixed == true)
        {
            adsMax = adsFixed;
            adsCounterSwitch = 0;
        }
        if (Fixed == false)
        {
            adsCounterSwitch = 0;
            adsMax = Random.Range(minAdsAmount, maxAdsAmount);
        }
    }

    private void Update()
    { 

        if (Fixed == true && adsCounterSwitch > adsMax)
        {
            if (PlayerPrefs.GetInt("adsOff") == 0)
            {
                if (Advertisement.IsReady())
                {
                    Advertisement.Show("video");
                    adsCounterSwitch = 0;
                }
            }

        }
        if (Fixed == false && adsCounterSwitch > adsMax)
        {
            if (PlayerPrefs.GetInt("adsOff") == 0)
            {
                if (Advertisement.IsReady())
                {
                    Advertisement.Show("video");
                    adsCounterSwitch = 0;
                    adsMax = Random.Range(minAdsAmount, maxAdsAmount);
                }
            }
        }
    }
    
    public void CounterADD()
    {
        adsCounterSwitch = adsCounterSwitch + 1;
    }

}