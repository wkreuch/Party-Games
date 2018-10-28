using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KingsCupBehaviour : MonoBehaviour {

    public GameObject dragObject;
    public string LevelName;
    Sprite cardIMG;

    int drawCardTotal;
    public Text drawCardTotalTXT;

    int chosenSuit;
    int chosenNumber;

    //Array of Suits || Array de Naipe
    string[] alreadyDraw = new string[53];
    string[] suits = new string[] { "D", "H", "C", "S" };
    string[] number = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
    public string numberOfCard;
    string suitOfCard;
    string finalCard;

    int index = 52;
    int indexCard;
    public string finalCardPath;

    public bool drawAnother = true;

    private void Start()
    {
        numberOfCard = "0";
        dragObject = GameObject.Find("Card");
    }

    public void GenerateCard()
    {
        drawCardTotal += 1;
        //Loop usado caso o gerador já tenha gerado aquela carta
        while (drawAnother == true && drawCardTotal != 53)
        {
            //Gerador de numero e naipe
            chosenSuit = Random.Range(0, suits.Length);
            chosenNumber = Random.Range(0, number.Length);

            numberOfCard = number[chosenNumber];
            suitOfCard = suits[chosenSuit];
            //Concatena as duas variveis para obter a carta final
            finalCard = numberOfCard + suitOfCard;

            /*Verifica se existe algum item na string array com o mesmo valor da variavel finalCard
             *Se ele achar o index vai receber um valor diferente de -1 e vai gerar outra carta
             *E se ele não achar o index recebe -1 continuando o codigo
             */
            indexCard = System.Array.IndexOf(alreadyDraw, finalCard);
            if (indexCard < 0)
            {
                KingsProcessOne();
                drawAnother = false;
            }
        }
    }

    private void Update()
    {
        if(drawCardTotal >= 53)
        {
            dragObject.GetComponent<DragInput>().htpIsOpen = true;
            dragObject.GetComponent<DragInput>().GameOver.SetActive(true);
        }
    }
    public void ResetKing()
    {
        SceneManager.LoadScene("KingsCups");
    }

    public void KingsProcessOne()
    {
        //Index usado para salvar as String que representam as cartas
        index -= 1;
        drawCardTotalTXT.text = drawCardTotal + "/52";
        //Atribui o valor na index
        alreadyDraw[index] = finalCard;
        //Booleana 
        finalCardPath = "Cards/" + finalCard;
        dragObject.GetComponent<DragInput>().KingProcess();
    }
}