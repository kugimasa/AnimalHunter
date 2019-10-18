using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    int currentTurn;
    public int maxTurn;

    public Text turnText;
    public GameObject resultPlane;
    public Text resultText;

    void Start()
    {
        currentTurn = maxTurn;
        turnText.text = maxTurn.ToString();
        resultPlane.SetActive(false);
    }

    void Update()
    {
        if (currentTurn == 0)
        {
            resultText.text = "おわり！";
            resultPlane.SetActive(true);
        }
    }

    //ターン更新
    public void UpdateTurn()
    {
        currentTurn--;
        turnText.text = currentTurn.ToString();
    }

    //ゲームクリア
    public void GameClear()
    {
        resultText.text = "クリア！！";
        resultPlane.SetActive(true);
    }
    
}
