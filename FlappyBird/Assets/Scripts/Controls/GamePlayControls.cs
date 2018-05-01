using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayControls : MonoBehaviour {

    public static GamePlayControls instance;

    [SerializeField]
    private Button instructionButton;

    [SerializeField]
    private Text scoreText, endScore, bestScore;

    [SerializeField]
    private GameObject panel;
    void Awake()
    {
        Time.timeScale = 0;
        _MakeInstance();
    }

    void _MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void InstructionButton()
    {
        Time.timeScale = 1;
        instructionButton.gameObject.SetActive(false);
    }

    public void _SetScore(int score)
    {
        scoreText.text = "" + score;
    }

    public void _BirdDieShowPanel(int score)
    {
        endScore.text = "" + score;
        panel.SetActive(true);
        if (score > GameManager.instance.GetHightScore())
        {
            GameManager.instance.SetHightScore(score);
        }
        bestScore.text = "" + GameManager.instance.GetHightScore();
        endScore.text = "" + score;
    }

    public void _MenuButton()
    {
        Application.LoadLevel("MainMenu");
    }

    public void _RestartGame()
    {
        Application.LoadLevel("GamePlay");
    }
}
