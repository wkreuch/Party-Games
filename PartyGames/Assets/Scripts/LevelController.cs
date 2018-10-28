using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelController : MonoBehaviour {

    private GameObject sceneController;
    public GameObject menu;
    public GameObject setting;
    public GameObject returnScene;
    public string lastSceneString;

	// Use this for initialization
	void Start () {
        sceneController = GameObject.Find("SceneController");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            lastSceneString = sceneController.GetComponent<DataSave>().lastSceneLoad;
            SceneManager.LoadScene(lastSceneString);
        }
    }

    #region  Controla a abertura e o fechamento do menu

    public void OpenMenu()
    {
        if (setting != null)
        {
            setting.SetActive(false);
        }
        if (returnScene != null)
        {
            returnScene.SetActive(false);
        }
        menu.SetActive(true);
    }       
    
    public void CloseMenu()
    {
        menu.SetActive(false);
        if (setting != null)
        {
            setting.SetActive(true);
        }
        if (returnScene != null)
        {
            returnScene.SetActive(true);
        }
        
    }

    #endregion

    #region Controle do menu

    public void ChangeDifficulty()
    {
        Scene lastSceneName = SceneManager.GetActiveScene();
        sceneController.GetComponent<DataSave>().lastSceneLoad = lastSceneName.name;
        SceneManager.LoadScene("Difficulty");
    }

    public void AboutUs()
    {
        Scene lastSceneName = SceneManager.GetActiveScene();
        sceneController.GetComponent<DataSave>().lastSceneLoad = lastSceneName.name;
        SceneManager.LoadScene("AboutUs");
    }

    public void Creditos()
    {
        Scene lastSceneName = SceneManager.GetActiveScene();
        sceneController.GetComponent<DataSave>().lastSceneLoad = lastSceneName.name;
        SceneManager.LoadScene("Credits");
    }

    #endregion

    #region Controla a Dificuldade e o menu de dificuldade do jogo

    public void SaveDifficulty()
    {
        PlayerPrefs.SetInt("showDifficultySelectScene", 1);
    }

    public void DontSaveDifficulty()
    {
        PlayerPrefs.SetInt("showDifficultySelectScene", 0);
    }

    public void DifficultyEasy()
    {
        PlayerPrefs.SetString("Difficulty", "Easy");
        SceneManager.LoadScene("SelectGame");
    }

    public void DifficultyNormal()
    {
        PlayerPrefs.SetString("Difficulty", "Normal");
        SceneManager.LoadScene("SelectGame");
    }

    public void DifficultyHard()
    {
        PlayerPrefs.SetString("Difficulty", "Hard");
        SceneManager.LoadScene("SelectGame");
    }

    public void DifficultyExtreme()
    {
        PlayerPrefs.SetString("Difficulty", "Extreme");
        SceneManager.LoadScene("SelectGame");
    }

    #endregion

    #region Games Scenes

    public void CallTruthOrDareScene()
    {
        SceneManager.LoadScene("TruthOrDare");
        Scene lastSceneName = SceneManager.GetActiveScene();
        sceneController.GetComponent<DataSave>().lastSceneLoad = lastSceneName.name;
        sceneController.GetComponent<DataSave>().lastGameLoad = "TruthOrDare";
        
    }
    public void CallNeverHadIEver()
    {
        SceneManager.LoadScene("NeverHadIEver");
        Scene lastSceneName = SceneManager.GetActiveScene();
        sceneController.GetComponent<DataSave>().lastSceneLoad = lastSceneName.name;
        sceneController.GetComponent<DataSave>().lastGameLoad = "NeverHadIEver";

    }
    public void CallKingsCups()
    {
        SceneManager.LoadScene("KingsCups");
        Scene lastSceneName = SceneManager.GetActiveScene();
        sceneController.GetComponent<DataSave>().lastSceneLoad = lastSceneName.name;
        sceneController.GetComponent<DataSave>().lastGameLoad = "KingsCups";
    }
    public void CallLastGame()
    {
        string lastScene = sceneController.GetComponent<DataSave>().lastGameLoad;
        SceneManager.LoadScene(lastScene);
    }
    public void CallSelectGameScene()
    {
        SceneManager.LoadScene("SelectGame");
        Scene lastSceneName = SceneManager.GetActiveScene();
        sceneController.GetComponent<DataSave>().lastSceneLoad = lastSceneName.name;
        sceneController.GetComponent<DataSave>().lastGameLoad = "SelectGame";
    }

    #endregion


}
