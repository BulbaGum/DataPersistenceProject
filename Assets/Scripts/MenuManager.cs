using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public TMP_InputField playerNameField;
    public TextMeshProUGUI bestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        bestScoreText.text = "Best Score : " + DataPersistenceManager.Instance.bestPlayerName + " : " + DataPersistenceManager.Instance.bestScore;        

        playerNameField.text = DataPersistenceManager.Instance.playerName;
    }

    // Update is called once per frame
    void Update()
    {
        EnterPlayerName();
    }

    public void StartGameButton()
    {
        DataPersistenceManager.Instance.SavePlayerData();
        SceneManager.LoadScene(1);
    }

    public void EnterPlayerName()
    {
        DataPersistenceManager.Instance.playerName = playerNameField.text;
    }

    public void ExitButton()
    {
        DataPersistenceManager.Instance.SavePlayerData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }
}
