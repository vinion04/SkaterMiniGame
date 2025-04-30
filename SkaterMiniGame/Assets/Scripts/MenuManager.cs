using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    private Button playBtn;
    private Button quitBtn;

    void Start()
    {
        playBtn = GameObject.Find("PlayBtn").GetComponent<Button>(); //find buttons to use
        quitBtn = GameObject.Find("QuitBtn").GetComponent<Button>();

        playBtn.onClick.AddListener(OnPlay);    //play game on button click
        quitBtn.onClick.AddListener(OnQuit);    //quit game on button click
    }

    public void OnPlay()
    {
        SceneManager.LoadScene("Story");
    }

    public void OnQuit()
    {
        Application.Quit();
        Debug.Log("Quit Game!");
    }
}
