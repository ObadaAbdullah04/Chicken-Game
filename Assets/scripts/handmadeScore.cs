using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class handmadeScore : MonoBehaviour
{
    public static handmadeScore instance;

    [SerializeField] private TextMeshProUGUI currentScoretextb;
    [SerializeField] private TextMeshProUGUI currentScoretext2b;
    [SerializeField] private TextMeshProUGUI highScoretextb;

    private int scoree;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        currentScoretextb.text = scoree.ToString();
        currentScoretext2b.text = scoree.ToString();
        highScoretextb.text = PlayerPrefs.GetInt("HighScoree", 0).ToString();
        Updatehighscore();
    }
    private void Updatehighscore()
    {
        if (scoree > PlayerPrefs.GetInt("HighScoree"))
        {
            PlayerPrefs.SetInt("HighScoree", scoree);
            highScoretextb.text = scoree.ToString();
        }
    }
    public void Updatescore()
    {
        scoree+=1;
        currentScoretextb.text = scoree.ToString();
        currentScoretext2b.text = scoree.ToString();
        Updatehighscore();
    }
}
