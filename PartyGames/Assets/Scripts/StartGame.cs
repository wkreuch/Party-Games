using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    public int sceneSwitch;
    public string doTheGameHaveDifficulty;
    public GameObject sceneController;

    // Use this for initialization
    void Start()
    {

        sceneController = GameObject.Find("SceneController");
        sceneSwitch = PlayerPrefs.GetInt("showDifficultySelectScene");
        doTheGameHaveDifficulty = PlayerPrefs.GetString("Difficulty");
        

        /* Verifica se é ou não para mostrar a Tela de selecionar a dificuldade no inicio do jogo
         * Se for verdade ele mostrar a tela Difficulty para que o jogador escolha a dificuldade das perguntas / desafios
         * Se for falso ele mostrar a tela SelectGame para que o jogador escolha o jogo
        */
        if (sceneSwitch == 0 || doTheGameHaveDifficulty == "")
        {
            PlayerPrefs.SetString("Difficulty", "");
            SceneManager.LoadScene("Difficulty");
            sceneController.GetComponent<DataSave>().lastGameLoad = "SelectGame";
        }
        if(sceneSwitch == 1 && doTheGameHaveDifficulty != "")
        {
            SceneManager.LoadScene("SelectGame");
            sceneController.GetComponent<DataSave>().lastGameLoad = "SelectGame";
        }
        
    }
        
}
