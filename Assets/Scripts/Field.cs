using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Field : MonoBehaviour
{
    Vector3 fieldPos;
    public int fieldSize;
    public float fieldStep;
    //Grassの無いマスの配列
    public int[] noGrassList;
    //各Dataのデータ配列
    public string[] fieldData;

    //Grassの親オブジェクト
    public GameObject FieldGrid;
    //Dataの親オブジェクト
    public GameObject FieldData;
    //各Data
    public GameObject FootPrintUP;
    public GameObject FootPrintDOWN;
    public GameObject FootPrintRIGHT;
    public GameObject FootPrintLEFT;
    public GameObject Hole;
    public GameObject Animal;
    public GameObject Grass;

    Grass[] grass;

    void Start()
    {
        grass = new Grass[fieldSize * fieldSize];
        fieldPos = new Vector3(-fieldStep * (fieldSize - 1) / 2, -fieldStep * (fieldSize - 1) / 2, 0);
        SetField();
    }

    void SetField()
    {
        int Id = 0;
        for (int i = 0; i < fieldSize; i++)
        {
            for (int j = 0; j < fieldSize; j++)
            {
                //Grass(各マスの配置)
                if (isGrass(Id))
                {
                    GameObject grassObject = Instantiate(Grass) as GameObject;
                    grassObject.transform.position = new Vector3(i, j, 0) * fieldStep;
                    grass[Id] = grassObject.GetComponent<Grass>();
                    grass[Id].SetInfo(Id, i, j);
                    grassObject.transform.parent = FieldGrid.transform;
                }
                //Data(各データの配置)
                CreateData(i, j, fieldData[Id], Id);
                Id++;
            }
        }
        FieldGrid.transform.position = fieldPos;
        FieldData.transform.position = fieldPos;
    }

    //Grassがあるかどうかの判定
    bool isGrass(int id)
    {
        for (int i = 0; i < noGrassList.Length; i++)
        {
            if (id == noGrassList[i])
            {
                return false;
            }
        }
        return true;
    }

    //データの入力
    void CreateData(int i, int j, string dataName, int id)
    {
        GameObject data;
        //Grass(マス)があれば
        if(isGrass(id))
        {
            grass[id].SetData(dataName);
        }
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
            data = new GameObject("None");
        }
        GameObject Object = Instantiate(data) as GameObject;
        Object.transform.position = new Vector3(i, j, 0) * fieldStep;
        Object.transform.parent = FieldData.transform;
    }
}
