using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class TruthOrDareBehaviour : MonoBehaviour {

    #region Variaves GameObject

    #region GameObject Oculto

    //Para Facilitar a Manipulaçao da Cenas
    private GameObject BG_Dare;
    private GameObject BG_Truth;
    private GameObject Text_Box;
    private GameObject CanvasFinder;

    #endregion

    //SceneController Guarda Dados Entre As Cenas
    private GameObject SceneController;

    //Faz a Troca De dados em o BTN
    public GameObject BTN_Switch;

    #endregion

    #region Variaves String

    private string callMethods;


    //Usado para Definir o tipo de txt.file a ser aberto
    public string file;
    public string dificuldade;
    public string fileFinalName;

    public string[] lines;

    #endregion

    public int random;

    void Start ()
    {

        #region Parte Responsavel para achar os Game Object

        // SceneController Usado para manipular dados entre cenas
        SceneController = GameObject.Find("SceneController");

        //Acha os GameOject da Scena Automatica Mente:
        BG_Dare = GameObject.Find("BG_Dare");
        BG_Truth = GameObject.Find("BG_Truth");
        Text_Box = GameObject.Find("Text_Box");
        CanvasFinder = GameObject.Find("Canvas");

        #endregion

        #region Parte Resposanvel por carregar o file.txt correto para cada tipo de ocasião

        dificuldade = SceneController.GetComponent<DataSave>().Difficulty;
        fileFinalName = file + "_" + dificuldade;
        TextAsset optionsText = Resources.Load<TextAsset>(fileFinalName);
        lines = optionsText.text.Split("\n"[0]);

        #endregion
    }    

    void Update()
    {

        #region Ativa a animaçao 
        //Executa a animaçao
        //BTNSwitch troca o dados entre os botões
        if (callMethods == "Truth")
        {
            CanvasFinder.GetComponent<Animator>().SetInteger("Animate", 1);
            Text_Box.GetComponent<UnityEngine.UI.Text>().text = lines[Random.Range(0, lines.Length)];
            callMethods = "Null";
        }
        if (callMethods == "Dare")
        {
            CanvasFinder.GetComponent<Animator>().SetInteger("Animate", 1);
            Text_Box.GetComponent<UnityEngine.UI.Text>().text = lines[Random.Range(0, lines.Length)];
            callMethods = "Null";
        }
        #endregion

    }

    #region Metodo BTN Verdade
    //Metodo Chamado ao clicar no botão Verdade
    public void IsTruthClicked()
    {
        BG_Truth.SetActive(true);
        BG_Dare.SetActive(false);
        callMethods = "Truth";
    }
#endregion

    #region Metodo BTN_Desafio
    //Metodo Chamado ao clicar no botão desafio
    public void IsDareClicked()
    {
        BG_Dare.SetActive(true);
        BG_Truth.SetActive(false);
        callMethods = "Dare";
        
    }
    #endregion

    #region Controle do botão aleatorio
    public void IsRandom()
    {
        random = Random.Range(0, 2);
        if(random == 0)
        {
            BG_Dare.SetActive(false);
            BG_Truth.SetActive(true);
            callMethods = "Truth";
        }
        if(random == 1)
        {
            BG_Dare.SetActive(true);
            BG_Truth.SetActive(false);
            callMethods = "Dare";
        }
    }
    #endregion

    #region Metodo BTN_Voltar
    //Metodo Chamado ao clicar no botão voltar
    public void IsBackClicked()
    {
        CanvasFinder.GetComponent<AdsControler>().CounterADD();
        CanvasFinder.GetComponent<Animator>().SetInteger("Animate", 0);
    }
    #endregion
}