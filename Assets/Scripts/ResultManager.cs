using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    public Text tryTotalText;
    public Text clearTotalText;

    GameData gameData;

    // Start is called before the first frame update
    void Start()
    {
        gameData = GameObject.Find("GameData").GetComponent<GameData>();
        tryTotalText.text = gameData.tryTotal.ToString();
        clearTotalText.text = gameData.clearTotal.ToString();
    }

}
