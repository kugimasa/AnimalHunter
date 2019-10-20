using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Field : MonoBehaviour
{
    Vector3 fieldPos;
    public int fieldSize;
    public float fieldStep;

    //各Dataのデータ配列
    string[] fieldData;

    //Grassの親オブジェクト
    public GameObject FieldGrid;
    //Dataの親オブジェクト
    public GameObject FieldData;
    //各Data
    GameObject FootPrintUP;
    GameObject FootPrintDOWN;
    GameObject FootPrintRIGHT;
    GameObject FootPrintLEFT;
    GameObject Animal;
    public GameObject Hole;
    public GameObject None;
    public GameObject Grass;
    public GameObject Player;

    Grass[] grass;
    public Player player;

    void Awake()
    {
        grass = new Grass[fieldSize * fieldSize];
        fieldPos = new Vector3(-fieldStep * (fieldSize - 1) / 2, -fieldStep * (fieldSize - 1) / 2, 0);
    }

    public void SetFieldData(string[] fieldData)
    {
        this.fieldData = fieldData;
    }

    public void SetObject(GameObject gameObject, string dataName)
    {
        switch (dataName)
        {
            case "FU":
                FootPrintUP = gameObject;
                break;
            case "FD":
                FootPrintDOWN = gameObject;
                break;
            case "FR":
                FootPrintRIGHT = gameObject;
                break;
            case "FL":
                FootPrintLEFT = gameObject;
                break;
            case "A":
                Animal = gameObject;
                break;
            default:
                break;
        }
    }

    public void SetField(int currentPos)
    {
        int Id = 0;
        for (int i = 0; i < fieldSize; i++)
        {
            for (int j = 0; j < fieldSize; j++)
            {
                //Grass(各マスの配置)
                GameObject grassObject = Instantiate(Grass) as GameObject;
                grass[Id] = grassObject.GetComponent<Grass>();
                grass[Id].SetInfo(Id, i, j);
                grassObject.transform.position = new Vector3(i, j, 0) * fieldStep;
                grassObject.transform.parent = FieldGrid.transform;
                if (Id == currentPos)
                {
                    grass[Id].isGrass = false;
                    grass[Id].GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                }
                //Data(各データの配置)
                CreateData(i, j, fieldData[Id], Id);
                Id++;
            }
        }

        //Player
        GameObject playerObject = Instantiate(Player) as GameObject;
        player = playerObject.GetComponent<Player>();
        playerObject.transform.parent = FieldGrid.transform;
        player.SetPosition(currentPos, fieldSize, fieldStep);

        FieldGrid.transform.position = fieldPos;
        FieldData.transform.position = fieldPos;
    }

    //データの入力
    void CreateData(int i, int j, string dataName, int id)
    {
        GameObject data;

        grass[id].SetData(dataName);
        
        if (dataName == "FU")
        {
            data = FootPrintUP;
        }
        else if (dataName == "FD")
        {
            data = FootPrintDOWN;
        }
        else if (dataName == "FR")
        {
            data = FootPrintRIGHT;
        }
        else if (dataName == "FL")
        {
            data = FootPrintLEFT;
        }
        else if (dataName == "A")
        {
            data = Animal;
        }
        else if (dataName == "H")
        {
            data = Hole;
        }
        else
        {
            data = None;
        }
        GameObject Object = Instantiate(data) as GameObject;
        Object.transform.position = new Vector3(i, j, 0) * fieldStep;
        Object.transform.parent = FieldData.transform;
    }

    //隣のマスの位置を指定してクリック可能を更新
    void UpdateNextGrass(int id, string place)
    {
        switch (place)
        {
            case "UP":
                grass[id + 1].SetCanClick();
                break;
            case "DOWN":
                grass[id - 1].SetCanClick();
                break;
            case "RIGHT":
                grass[id + fieldSize].SetCanClick();
                break;
            case "LEFT":
                grass[id - fieldSize].SetCanClick();
                break;
            default:
                break;
        }
    }

    //マスのクリック可能を更新
    public void UpdateCanClickGrass(int id)
    {
        //CanClickをfalseに初期化
        for (int i = 0; i < fieldSize * fieldSize; i++)
        {
            grass[i].SetCannotClick();
        }
        //四隅
        //左下
        if (id == 0)
        {
            UpdateNextGrass(id, "UP");
            UpdateNextGrass(id, "RIGHT");
        }
        //左上
        else if (id == fieldSize - 1)
        {
            UpdateNextGrass(id, "DOWN");
            UpdateNextGrass(id, "RIGHT");
        }
        //右下
        else if (id == fieldSize * fieldSize - fieldSize) 
        {
            UpdateNextGrass(id, "UP");
            UpdateNextGrass(id, "LEFT");
        }
        //右上
        else if (id == fieldSize * fieldSize - 1)
        {
            UpdateNextGrass(id, "DOWN");
            UpdateNextGrass(id, "LEFT");
        }

        //四辺
        //上辺
        else if ((id + 1) % fieldSize == 0)
        {
            UpdateNextGrass(id, "DOWN");
            UpdateNextGrass(id, "RIGHT");
            UpdateNextGrass(id, "LEFT");
        }
        //下辺
        else if (id % fieldSize == 0)
        {
            UpdateNextGrass(id, "UP");
            UpdateNextGrass(id, "RIGHT");
            UpdateNextGrass(id, "LEFT");
        }
        //左辺
        else if (1 <= id && id <= (fieldSize - 2))
        {
            UpdateNextGrass(id, "UP");
            UpdateNextGrass(id, "DOWN");
            UpdateNextGrass(id, "RIGHT");
        }
        //右辺
        else if ((fieldSize * fieldSize - fieldSize + 1) <= id && id <= (fieldSize * fieldSize - 2))
        {
            UpdateNextGrass(id, "UP");
            UpdateNextGrass(id, "DOWN");
            UpdateNextGrass(id, "LEFT");
        }

        //それ以外
        else
        {
            UpdateNextGrass(id, "UP");
            UpdateNextGrass(id, "DOWN");
            UpdateNextGrass(id, "RIGHT");
            UpdateNextGrass(id, "LEFT");
        }
    }
}
