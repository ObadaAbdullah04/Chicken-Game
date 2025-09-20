using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class handmadecounter : MonoBehaviour
{
    public static handmadecounter instance;
    public TMP_Text scoretext;
    public int currentscore = 0;

    public TMP_Text missedtext;
    public int missedscore = 0;

    public TMP_Text icecreamtext;
    public int icecreamscore = 3;


    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoretext.text = "Score: " + currentscore.ToString();
        missedtext.text = "Missed " + missedscore.ToString() + " /8";
        icecreamtext.text = "Chance  " + icecreamscore.ToString() + " /3";
    }

    public void Increasecoins(int v)
    {
        //currentscore += v;
        //scoretext.text = "Score: " + currentscore.ToString();
        handmadeScore.instance.Updatescore();
    }
    public void Missedscore(int m)
    {
        missedscore += m;
        missedtext.text = "Missed " + missedscore.ToString() + " /8";
        if (missedscore == 8)
        {
            Invoke("GameOverWithDelay", 0.5f);
        }
    }
    public void Icecreamscore(int i)
    {
        icecreamscore -= i;
        icecreamtext.text = "Chance  " + icecreamscore.ToString() + " /3";
        if (icecreamscore == 0)
        {
            
            
            Invoke("GameOverWithDelay", 1.6f);
        }
    }
    private void GameOverWithDelay()
    {
        GameManager.instance.GameOver();
    }
}
