using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    int currentTurn;
    public int currentPos;
    public int maxTurn;

    public Text turnText;
    public GameObject turnPannel;
    public GameObject resultPannel;
    public GameObject infoPannel;
    public Text resultText;
    Field field;

    GameData gameData;
    AudioManager audioManager;

    void Start()
    {
        //GameData
        gameData = GameObject.Find("GameData").GetComponent<GameData>();
        //AudioManager
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        //field
        field = this.GetComponent<Field>();
        currentTurn = maxTurn;
        //ターン数テキストの初期化
        turnText.text = maxTurn.ToString();
        turnText.fontSize = 30;
        turnText.color = new Color(0.240566f, 0.4380339f, 0.9622642f, 1f);
        //結果パネルの非表示
        resultPannel.SetActive(false);
        //１トライ加算
        gameData.tryTotal++;

        //Infoパネルを表示
        if (gameData.isFirst)
        {
            infoPannel.SetActive(true);
        }
        else
        {
            StartGame();
        }
    }

    void Update()
    {
        if (currentTurn == 0)
        {
            resultText.text = "おわり！";
            resultPannel.SetActive(true);
            if (gameData.isFirst)
            {
                gameData.isFirst = false;
            }
        }
    }

    //InfoPannel用
    //閉じる
    public void InfoClose()
    {
        audioManager.PlayOKButton();
        infoPannel.SetActive(false);
        StartGame();
    }
    //説明1
    public void Info1()
    {
        audioManager.PlayOKButton();
        infoPannel.transform.GetChild(0).gameObject.SetActive(false);
        infoPannel.transform.GetChild(1).gameObject.SetActive(false);
        infoPannel.transform.GetChild(2).gameObject.SetActive(false);
        infoPannel.transform.GetChild(3).gameObject.SetActive(true);
        infoPannel.transform.GetChild(4).gameObject.SetActive(true);
        infoPannel.transform.GetChild(5).gameObject.SetActive(true);
        infoPannel.transform.GetChild(6).gameObject.SetActive(false);
        infoPannel.transform.GetChild(7).gameObject.SetActive(false);
        infoPannel.transform.GetChild(8).gameObject.SetActive(false);
    }
    //もどる
    public void Back()
    {
        audioManager.PlayOKButton();
        infoPannel.transform.GetChild(0).gameObject.SetActive(true);
        infoPannel.transform.GetChild(1).gameObject.SetActive(true);
        infoPannel.transform.GetChild(2).gameObject.SetActive(true);
        infoPannel.transform.GetChild(3).gameObject.SetActive(false);
        infoPannel.transform.GetChild(4).gameObject.SetActive(false);
        infoPannel.transform.GetChild(5).gameObject.SetActive(false);
    }
    public void Info2()
    {
        audioManager.PlayOKButton();
        infoPannel.transform.GetChild(3).gameObject.SetActive(false);
        infoPannel.transform.GetChild(4).gameObject.SetActive(false);
        infoPannel.transform.GetChild(5).gameObject.SetActive(false);
        infoPannel.transform.GetChild(6).gameObject.SetActive(true);
        infoPannel.transform.GetChild(7).gameObject.SetActive(true);
        infoPannel.transform.GetChild(8).gameObject.SetActive(true);
    }

    //ゲーム開始
    void StartGame()
    {
        turnPannel.SetActive(true);
        //CurrentPosを初期化
        SetCurrentPos();
        //Fieldセット
        //FieldDataをFieldにセット
        field.SetFieldData(gameData.GetFieldData());
        //Animalをセット
        gameData.SetAnimal();
        //Dataのオブジェクトをセット
        field.SetObject(gameData.GetObject("FU"), "FU");
        field.SetObject(gameData.GetObject("FD"), "FD");
        field.SetObject(gameData.GetObject("FR"), "FR");
        field.SetObject(gameData.GetObject("FL"), "FL");
        field.SetObject(gameData.GetObject("A"), "A");
        //位置をセット
        field.SetField(currentPos);
        field.UpdateCanClickGrass(currentPos);
    }

    //ターン更新
    public void UpdateTurn()
    {
        currentTurn--;
        turnText.text = currentTurn.ToString();
        //残り３ターンで強調表示
        if (currentTurn <= 3)
        {
            turnText.fontSize = 40;
            turnText.color = Color.red;
        }
        //クリック可能を更新
        field.UpdateCanClickGrass(currentPos);
        //Playerを移動
        field.player.SetPosition(currentPos, field.fieldSize, field.fieldStep);
    }

    public void SetCurrentPos()
    {
        float random = Random.value;
        if (0f <= random && random < 0.25f)
        {
            currentPos = 8;
        }
        else if (0.25f <= random && random < 0.5f)
        {
            currentPos = 7;
        }
        else if (0.5f <= random && random < 0.75f)
        {
            currentPos = 10;
        }
        else
        {
            currentPos = 15;
        }
    }

    //ゲームクリア
    public void GameClear()
    {
        resultText.text = "クリア！！";
        gameData.clearTotal++;
        resultPannel.SetActive(true);
        if (gameData.isFirst)
        {
            gameData.isFirst = false;
        }
    }
    
}
