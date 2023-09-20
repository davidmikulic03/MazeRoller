using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{


    GameObject Score;

    GameObject Heart1;
    GameObject Heart2;
    GameObject Heart3;


    TextMeshProUGUI ScoreText;

    private void Awake()
    {
        SetupReferences();
    }
    private void SetupReferences()
    {
        Score = transform.Find("Score").gameObject;
        ScoreText = Score.GetComponent<TextMeshProUGUI>();

        Heart1 = transform.Find("Heart1").gameObject;
        Heart2 = transform.Find("Heart2").gameObject;
        Heart3 = transform.Find("Heart3").gameObject;
    }


    public void SetScore(uint score)
    {
        ScoreText.text = "Score: " + score.ToString();
    }
    public void SetLives(uint lives)
    {
        switch (lives)
        {
            case 0:
                {
                    Heart1.SetActive(false);
                    Heart2.SetActive(false);
                    Heart3.SetActive(false);
                }
                break;
                case 1:
                {
                    Heart1.SetActive(true);
                    Heart2.SetActive(false);
                    Heart3.SetActive(false);
                }
                break;
            case 2:
                {
                    Heart1.SetActive(true);
                    Heart2.SetActive(true);
                    Heart3.SetActive(false);
                }
                break;
            case 3:
                {
                    Heart1.SetActive(true);
                    Heart2.SetActive(true);
                    Heart3.SetActive(true);
                }
                break;
        }
    }
}
