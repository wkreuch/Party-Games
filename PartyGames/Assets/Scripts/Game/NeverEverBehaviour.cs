using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeverEverBehaviour : MonoBehaviour {

    private GameObject Text_Box;
    private GameObject SceneController;
    public GameObject CanvasFinder;

    public string file;
    public string dificuldade;
    public string fileFinalName;

    public string[] lines;

    private string callMethods;

    // Use this for initialization
    void Start ()
    {
        CanvasFinder = GameObject.Find("Canvas");
        SceneController = GameObject.Find("SceneController");
        Text_Box = GameObject.Find("Text_Box");

        dificuldade = SceneController.GetComponent<DataSave>().Difficulty;
        fileFinalName = file + "_" + dificuldade;
        TextAsset optionsText = Resources.Load<TextAsset>(fileFinalName);
        lines = optionsText.text.Split("\n"[0]);

        Text_Box.GetComponent<UnityEngine.UI.Text>().text = lines[Random.Range(0, lines.Length)];
        callMethods = "Null";
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (callMethods == "Clicked")
        {
            Text_Box.GetComponent<UnityEngine.UI.Text>().text = lines[Random.Range(0, lines.Length)];
            CanvasFinder.GetComponent<AdsControler>().CounterADD();
            callMethods = "Null";
        }
    }

    public void ChangeQuestion()
    {
        callMethods = "Clicked";
    }

}
