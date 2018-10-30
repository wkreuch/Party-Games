using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeverEverBehaviour : MonoBehaviour
{

    #region Variaves GameObject

    private GameObject Text_Box;
    private GameObject CanvasFinder;

    //SceneController Guarda Dados Entre As Cenas
    private GameObject SceneController;

    #endregion

    #region Variaves String

    //Usado para Definir o tipo de txt.file a ser aberto
    private string file;
    private string gameDifficulty;
    private string fetchDifficulty;
    private string fileFinalName;

    //Guarda as frases depois de buscar o arquivo correto
    private string[] lines;
    public string linesText;

    #endregion

    #region Variaves usada no codigo para não repetir os desafios

    public string[] alreadyUsed = new string[200];
    public int indexUsed;
    public int indexChecker;
    public bool randomizeAgain;

    #endregion

    #region Variaves Int

    //Valores para criar evento aleatorio 
    private int randomDifficulty;
    private int random;

    #endregion


    public void Start()
    {
        #region Parte Responsavel para achar os Game Object

        // SceneController Usado para manipular dados entre cenas
        SceneController = GameObject.Find("SceneController");

        //Acha os GameOject da Cenas:
        Text_Box = GameObject.Find("Text_Box");
        CanvasFinder = GameObject.Find("Canvas");

        #endregion

        //Busca a Difficuldade Selecionada
        gameDifficulty = SceneController.GetComponent<DataSave>().Difficulty;
        indexUsed = -1;

        NeverHaveIEverClicked();
    }

    public void NeverHaveIEverClicked()
    {
        file = "NeverHaveIEver";
        //Chama o Metodo Randomizer responsavel por ramdomizar o nivel de dificuldade do desafio
        Randomizer();
        CanvasFinder.GetComponent<AdsControler>().CounterADD();
    }
    public void FetchFile()
    {

        fileFinalName = file + "_" + fetchDifficulty;
        TextAsset optionsText = Resources.Load<TextAsset>(fileFinalName);
        //Separa o texto por cada quebra de linha
        lines = optionsText.text.Split("\n"[0]);
        RandomizerTextToDisplay();
    }
    public void RandomizerTextToDisplay()
    {
        randomizeAgain = true;
        if (randomizeAgain == true)
        {
            linesText = lines[Random.Range(0, lines.Length)];

            indexChecker = System.Array.IndexOf(alreadyUsed, linesText);
            if (indexChecker < 0)
            {
                Text_Box.GetComponent<UnityEngine.UI.Text>().text = linesText;
                if (indexUsed >= 198)
                {
                    indexUsed = -1;
                    indexUsed++;
                    alreadyUsed[indexUsed] = linesText;
                }
                else
                {
                    indexUsed++;
                    alreadyUsed[indexUsed] = linesText;
                }
                randomizeAgain = false;
            }
            else
            {
                Randomizer();
            }
        }

    }
    public void ChangeQuestion()
    {
        CanvasFinder.GetComponent<AdsControler>().CounterADD();
        NeverHaveIEverClicked();
    }

    public void Randomizer()
    {
        //Switch usado para controlar o provabilidade do nivel do desafio a ser selecionado
        switch (gameDifficulty)
        {
            #region Facil
            case "Easy":
                fetchDifficulty = "Easy";
                break;
            #endregion
            #region Normal
            case "Normal":
                randomDifficulty = Random.Range(0, 101);
                if (randomDifficulty >= 0 && randomDifficulty <= 50)
                {
                    fetchDifficulty = "Easy";
                }
                if (randomDifficulty >= 51 && randomDifficulty <= 100)
                {
                    fetchDifficulty = "Normal";
                }
                break;
            #endregion
            #region Dificil
            case "Hard":
                randomDifficulty = Random.Range(0, 101);
                if (randomDifficulty >= 0 && randomDifficulty <= 50)
                {
                    fetchDifficulty = "Easy";
                }
                if (randomDifficulty >= 51 && randomDifficulty <= 75)
                {
                    fetchDifficulty = "Normal";
                }
                if (randomDifficulty >= 76 && randomDifficulty <= 100)
                {
                    fetchDifficulty = "Hard";
                }
                break;
            #endregion
            #region Extremo
            case "Extreme":
                randomDifficulty = Random.Range(0, 101);
                if (randomDifficulty >= 0 && randomDifficulty <= 50)
                {
                    fetchDifficulty = "Easy";
                }
                if (randomDifficulty >= 51 && randomDifficulty <= 75)
                {
                    fetchDifficulty = "Normal";
                }
                if (randomDifficulty >= 76 && randomDifficulty <= 90)
                {
                    fetchDifficulty = "Hard";
                }
                if (randomDifficulty >= 91 && randomDifficulty <= 100)
                {
                    fetchDifficulty = "Extreme";
                }
                break;
                #endregion
        }
        FetchFile();
    }
}