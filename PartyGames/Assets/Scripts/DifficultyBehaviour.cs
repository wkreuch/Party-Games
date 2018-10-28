using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DifficultyBehaviour : MonoBehaviour {

    public Sprite check;
    public Sprite notCheck;

    public GameObject Sim;
    public GameObject No;
    public GameObject backIsActive;
    public int saveDifficulty;
    public string difficultyWasSet;
	
	// Update is called once per frame
	void Update () {

        /*Int saveDifficulty
         * saveDifficulty = 1 = Salvar
         * saveDifficulty = 0 = Não Salvar
         * saveD
         */

        difficultyWasSet = PlayerPrefs.GetString("Difficulty");
        saveDifficulty = PlayerPrefs.GetInt("showDifficultySelectScene");

        if(difficultyWasSet == "")
        {
            backIsActive.SetActive(false);
        }
        else
        {
            backIsActive.SetActive(true);
        }


        if (saveDifficulty == 1)
        {
            Sim.GetComponent<Image>().sprite = check;
            No.GetComponent<Image>().sprite = notCheck;
        }
        else
        {
            Sim.GetComponent<Image>().sprite = notCheck;
            No.GetComponent<Image>().sprite = check;
        }
	}
}
