using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSave : MonoBehaviour {

    public int adsWasRemove;
    public string Difficulty;
    public string lastGameLoad;
    public string lastSceneLoad;

    public int adsCounter;

	// Use this for initialization
	void Start ()
    {

        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        adsWasRemove = PlayerPrefs.GetInt("adsOff");
        Difficulty = PlayerPrefs.GetString("Difficulty");
    }
}
