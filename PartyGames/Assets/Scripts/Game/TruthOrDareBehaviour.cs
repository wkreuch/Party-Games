using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class TruthOrDareBehaviour : MonoBehaviour {

    #region Variaves GameObject

    private GameObject BG_Dare;
    private GameObject BG_Truth;
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
        BG_Dare = GameObject.Find("BG_Dare");
        BG_Truth = GameObject.Find("BG_Truth");
        Text_Box = GameObject.Find("Text_Box");
        CanvasFinder = GameObject.Find("Canvas");

        #endregion

        //Busca a Difficuldade Selecionada
        gameDifficulty = SceneController.GetComponent<DataSave>().Difficulty;
    }

    //Procura o arquivo correto
    public void FetchFile()
    {

        fileFinalName = file + "_" + fetchDifficulty;
        TextAsset optionsText = Resources.Load<TextAsset>(fileFinalName);
        //Separa o texto por cada quebra de linha
        lines = optionsText.text.Split("\n"[0]);
        //Chama o Metodo DoAnimation responsavel pela animaçao
        DoAnimation();
    }
    //Controle do Botão Verdade
    public void TruthClicked()
    {
        file = "Truth";
        //Controla o Plano de Fundo Exibido
        BG_Dare.SetActive(false);
        BG_Truth.SetActive(true);
        //Chama o Metodo Randomizer responsavel por ramdomizar o nivel de dificuldade do desafio
        Randomizer();
    }
    //Controle do Botão Desafio
    public void DareClicked()
    {
        file = "Dare";
        //Controla o Plano de Fundo Exibido
        BG_Truth.SetActive(false);
        BG_Dare.SetActive(true);
        //Chama o Metodo Randomizer responsavel por ramdomizar o nivel de dificuldade do desafio
        Randomizer();
    }
    //Controle do Botão Aleatorio
    public void RandomClicked()
    {
        //Randomiza um numero
        //Se for de 0 a 74 chamarar o metodo usado quando o botão verdade e clicado
        //Se for de 75 a 100 chamarar o metodo usado quando o botão desafio e clicado
        random = Random.Range(0, 101);
        if(random >= 0 && random <= 74)
        {
            TruthClicked();
        }
        if (random >= 75 && random <= 100)
        {
            DareClicked();
        }
    }
    //Controle do Botão Voltar
    public void BackClicked()
    {
        //Adiciona +1 na contagem até passar um anuncio
        CanvasFinder.GetComponent<AdsControler>().CounterADD();
        //Ativa animação de fechar
        CanvasFinder.GetComponent<Animator>().SetInteger("Animate", 0);
    }
    //Controla Animação
    public void DoAnimation()
    {
        //Ativa animação de abrir
        CanvasFinder.GetComponent<Animator>().SetInteger("Animate", 1);
        //Chama o metodo responsavel por mudar o texto mostrado no cartão
        ChangeTextDisplay();
    }
    //Muda o Texto a ser exibido
    public void ChangeTextDisplay()
    {
        Text_Box.GetComponent<UnityEngine.UI.Text>().text = lines[Random.Range(0, lines.Length)];
    }
    //Randomizer responsavel por ramdomizar o nivel de dificuldade do desafio
    public void Randomizer()
    {
        //Switch usado para controlar o provabilidade do nivel do desafio a ser selecionado
        switch (gameDifficulty)
        {
            case "Easy":
                fetchDifficulty = "Easy";
                break;
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
        }
        FetchFile();
    }
}