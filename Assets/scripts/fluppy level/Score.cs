using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance;

    [SerializeField] private TextMeshProUGUI currentScoretext;
    [SerializeField] private TextMeshProUGUI currentScoretext2;
    [SerializeField] private TextMeshProUGUI highScoretext;

    private int score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        currentScoretext.text = score.ToString();
        currentScoretext2.text = score.ToString();
        highScoretext.text = PlayerPrefs.GetInt("HighScore",0).ToString();
        Updatehighscore();
    }
    private void Updatehighscore()
    {
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore",score);
            highScoretext.text = score.ToString();
        }
    }
    public void Updatescore()
    {
        score++;
        currentScoretext.text = score.ToString();
        currentScoretext2.text = score.ToString();
        Updatehighscore();
    }
}
