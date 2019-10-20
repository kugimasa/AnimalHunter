using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public bool isFirst;
    public int tryTotal;
    public int clearTotal;

    //くま
    public GameObject BearFU;
    public GameObject BearFD;
    public GameObject BearFR;
    public GameObject BearFL;
    public GameObject Bear;
    //とり
    public GameObject BirdFU;
    public GameObject BirdFD;
    public GameObject BirdFR;
    public GameObject BirdFL;
    public GameObject Bird;
    //ウサギ
    public GameObject RabbitFU;
    public GameObject RabbitFD;
    public GameObject RabbitFR;
    public GameObject RabbitFL;
    public GameObject Rabbit;
    //リス
    public GameObject SquirrelFU;
    public GameObject SquirrelFD;
    public GameObject SquirrelFR;
    public GameObject SquirrelFL;
    public GameObject Squirrel;

    //Fieldに渡す値
    GameObject currentFU;
    GameObject currentFD;
    GameObject currentFR;
    GameObject currentFL;
    GameObject currentAnimal;

    void Awake()
    {
        isFirst = true;
        tryTotal = 0;
        clearTotal = 0;
        DontDestroyOnLoad(this.gameObject);
    }

    public string[] GetFieldData()
    {
        float random = Random.value;
        if (0f <= random && random < 0.25f)
        {
            string[] fieldData = {"H", "None", "A", "FD",
                                  "None", "H", "None", "FL",
                                  "FU", "FU", "FR", "FL",
                                  "H", "None", "FU", "FL",};
            return fieldData;
        }
        else if (0.25f <= random && random < 0.5f)
        {
            string[] fieldData = {"H", "None", "None", "H",
                                  "None", "A", "H", "None",
                                  "None", "FL", "FD", "FR",
                                  "H", "None", "FL", "FD",};
            return fieldData;
        }
        else if (0.5f <= random && random < 0.75f)
        {
            string[] fieldData = {"A", "FD", "FD", "None",
                                  "None", "None", "FL", "None",
                                  "None", "H", "FL", "H",
                                  "H", "None", "FL", "FD",};
            return fieldData;
        }
        else
        {
            string[] fieldData = {"FR", "FD", "H", "None",
                                  "FR", "FL", "FD", "None",
                                  "FR", "None", "None", "H",
                                  "FU", "A", "None", "None",};
            return fieldData;
        }
    }
    //Animalを選択
    public void SetAnimal()
    {
        float random = Random.value;
        if (0f <= random && random < 0.25f)
        {
            currentFU = BearFU;
            currentFD = BearFD;
            currentFR = BearFR;
            currentFL = BearFL;
            currentAnimal = Bear;
        }
        else if (0.25f <= random && random < 0.5f)
        {
            currentFU = BirdFU;
            currentFD = BirdFD;
            currentFR = BirdFR;
            currentFL = BirdFL;
            currentAnimal = Bird;
        }
        else if (0.5f <= random && random < 0.75f)
        {
            currentFU = RabbitFU;
            currentFD = RabbitFD;
            currentFR = RabbitFR;
            currentFL = RabbitFL;
            currentAnimal = Rabbit;
        }
        else
        {
            currentFU = SquirrelFU;
            currentFD = SquirrelFD;
            currentFR = SquirrelFR;
            currentFL = SquirrelFL;
            currentAnimal = Squirrel;
        }
    }
    //Fieldにオブジェクトを渡すメソッド
    public GameObject GetObject(string dataName)
    {
        switch (dataName)
        {
            case "FU":
                return currentFU;
            case "FD":
                return currentFD;
            case "FR":
                return currentFR;
            case "FL":
                return currentFL;
            case "A":
                return currentAnimal;
            default:
                return null;
        }
    }
}
