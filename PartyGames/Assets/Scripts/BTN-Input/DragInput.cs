using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragInput : MonoBehaviour
{

    public GameObject CanvasFinder;
    public GameObject infoBox;
    public GameObject GameOver;
    public Sprite infoBoxIMG;
    string infoPathIMG;

    public GameObject htpDbBox;
    public bool htpIsOpen;
    public Text htpDbBoxText;
    
    public string levelName;
    string number;
    string finalCardPath;
    bool returnInput;
    Sprite cardIMG;

    public GameObject dragObject;
    public float speed;
    float x;
    float y;
    float initPositionX;
    float FinalPositionX;
    float initPositionY;
    float FinalPositionY;
    bool swipeAction = false;

    private void Start()
    {
        number = "0";
        HtpChangeTxt();
        htpIsOpen = false;

        initPositionX = dragObject.transform.position.x;
        initPositionY = dragObject.transform.position.y;

        infoBoxIMG = Resources.Load<Sprite>("King_info/0");
        infoBox.GetComponent<Image>().overrideSprite = infoBoxIMG;
        cardIMG = Resources.Load<Sprite>("Cards/NONE");
        gameObject.GetComponent<Image>().sprite = cardIMG;
    }

    public void KingProcess()
    {
        CanvasFinder.GetComponent<KingsCupBehaviour>().drawAnother = false;
        CanvasFinder.GetComponent<AdsControler>().CounterADD();
        finalCardPath = CanvasFinder.GetComponent<KingsCupBehaviour>().finalCardPath;
        number = CanvasFinder.GetComponent<KingsCupBehaviour>().numberOfCard;
        infoPathIMG = "King_info/" + number;
        infoBoxIMG = Resources.Load<Sprite>(infoPathIMG);
        infoBox.GetComponent<Image>().overrideSprite = infoBoxIMG;
        cardIMG = Resources.Load<Sprite>(finalCardPath);
        gameObject.GetComponent<Image>().sprite = cardIMG;
        gameObject.transform.position = new Vector3(initPositionX, initPositionY, 0);
        HtpChangeTxt();
    }    
    public void OpenHTP()
    {
        if (htpIsOpen == true)
        { 
            htpDbBox.SetActive(false);
            htpIsOpen = false;
        }
        else
        {
            htpDbBox.SetActive(true);
            htpIsOpen = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        CanvasFinder = GameObject.Find("Canvas");
        
        if (Input.touches.Length > 0 && htpIsOpen == false)
        {
            

            if (Input.touches[0].phase == TouchPhase.Moved && htpIsOpen == false)
            {

                x = Input.touches[0].deltaPosition.x * speed * Time.deltaTime;
                y = Input.touches[0].deltaPosition.y * speed * Time.deltaTime;
                transform.Translate(new Vector3(x, y, 0));
                FinalPositionX = dragObject.transform.position.x;
                FinalPositionY = dragObject.transform.position.y;
                swipeAction = true;
            }

            if (Input.touches[0].phase == TouchPhase.Ended && swipeAction == true && htpIsOpen == false)
            {
                if (FinalPositionX <= 310 || FinalPositionX >= 750 || FinalPositionY >= 1150 || FinalPositionY <= 550)
                {
                    if (levelName == "kingscups")
                    {
                        CanvasFinder.GetComponent<KingsCupBehaviour>().drawAnother = true;
                        CanvasFinder.GetComponent<KingsCupBehaviour>().GenerateCard();
                        gameObject.transform.position = new Vector3(initPositionX, initPositionY, 0);
                        FinalPositionX = initPositionX;
                        FinalPositionY = initPositionY;
                        
                    }
                }
                else
                {
                    if (levelName == "kingscups")
                    {
                        gameObject.transform.position = new Vector3(initPositionX, initPositionY, 0);
                    }
                }
            }
        }
    }
    public void HtpChangeTxt()
    {
    switch (number)
    {
        case "0":
            htpDbBoxText.text = "Para jogar e nescessario um copo e no minimo 3 jogadores // Deslize para direta ou para esquerda para receber a primeira carta, cada carta e um desafio a ser comprido!";
            break;
        case "A":
            htpDbBoxText.text = "A pessoa a direita do jogador que tirou essa carta começa a beber, Depois a pessoa direta de quem bebeu vai ter que beber até que chegue ao jogador que tirou a carta";
            break;

        case "2":
            htpDbBoxText.text = "O jogador que tirou essa carta tem o direito de escolher alguém para tomar um shot";
            break;

        case "3":
            htpDbBoxText.text = "O jogador que retirou essa carta deve tomar um shot";
            break;

        case "4":
            htpDbBoxText.text = "O jogador que tirou essa carta deve escolher duas pessoas para tomar um shot cada, enquanto ele toma dois shot";
            break;

        case "5":
            htpDbBoxText.text = "Todos os jogadores do sexo masculino devem beber";
            break;

        case "6":
            htpDbBoxText.text = "Todos os jogadores do sexo feminino devem beber";
            break;

        case "7":
            htpDbBoxText.text = "Ao Tirar essa carta todo mundo deve levantar a mão e o ultimo que levantar deve beber um shot";
            break;

        case "8":
            htpDbBoxText.text = "Ao Retirar essa carta o jogador deve escolher um parceiro. E toda vez que o jogador tiver que beber o parceiro também terá que beber, até outro grupo de parceiro ser retirado";
            break;

        case "9":
            htpDbBoxText.text = "O jogador que tirou essa carta deve falar um palavra e a pessoa a direta deve falar outra que rime com a palavra escolhida, seguindo a direita o proximo fala uma palavra que rime com a anterior. O jogo continua até que alguém do grupo erre a rima. QUEM ERRA A RIMA BEBE!";
            break;

        case "10":
            htpDbBoxText.text = "O jogador que pegou essa carta escolhe um categoria ai a pessoa a sua direita deve falar algo relacionado a categoria escolhida. O jogodores seguem a direita até que alguém fale algo fora da categoria. Exemplo.: Marca de carro: Volkwagen, Ford, entre outro. O jogador que falar algo que não seja da categoria tera que tomar um SHOT!";
            break;

        case "J":
            htpDbBoxText.text = "O jogador pode escolher uma regra e qualquer pessoa que quebrar essa regra deve beber";
            break;

        case "Q":
            htpDbBoxText.text = "O jogador que tirou essa carta faz uma pergunta para algum jogador, e o jogador escolhido deve responder a pergunta com outra pergunta escolhendo outra pessoa. O jogo continua ate que alguém erre! Quem Errar deve tomar um shot!";
            break;

        case "K":
            htpDbBoxText.text = "O Primeiro jogador que pegar essa carta adiciona 1/4 de bebida no copo, O Segundo coloca mais 1/4, a terceira mais um 1/4 e a quarta pessoa deve colocar mais 1/4 e beber em seguida";
            break;
        }
    }      
}
