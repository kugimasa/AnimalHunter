using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldData : MonoBehaviour
{
    
    public int fieldSize;
    public float fieldStep;
    public int[] noGrassList;
    public string[] fieldData;
    public GameObject field;
    public GameObject FootPrintUP;
    public GameObject FootPrintDOWN;
    public GameObject FootPrintRIGHT;
    public GameObject FootPrintLEFT;
    public GameObject Hole;
    public GameObject Animal;
    public GameObject Grass;

    Grass[] grass;
    int Id;

    void Start()
    {
        grass = new Grass[fieldSize * fieldSize];
        SetGrass();
        SetData();
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

    //Grassの配置
    void SetGrass()
    {
        Id = 0;
        for (int i = 0; i < fieldSize; i++)
        {
            for (int j = 0; j < fieldSize; j++)
            {
                if (isGrass(Id))
                {
                    GameObject grassObject = Instantiate(Grass) as GameObject;
                    grassObject.transform.position = new Vector3(i, j, 0) * fieldStep;
                    grass[Id] = grassObject.GetComponent<Grass>();
                    grass[Id].SetInfo(Id, i, j);
                    grassObject.transform.parent = field.transform;
                }
                Id++;
            }
        }
        field.transform.position = new Vector3(-fieldStep * (fieldSize - 1) / 2, -fieldStep * (fieldSize - 1) / 2, 0);
    }

    //データの入力
    void CreateData(int i, int j, string dataName, int id)
    {
        GameObject data;
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
            grass[id].SetAnimal();
            Debug.Log("YES Animal");
            Debug.Log(id);
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
        Object.transform.parent = this.transform;
    }

    //Fieldデータの配置
    void SetData()
    {
        Id = 0;
        for (int i = 0; i < fieldSize; i++)
        {
            for (int j = 0; j < fieldSize; j++)
            {
                CreateData(i, j, fieldData[Id], Id);
                Id++;
            }
        }
        this.transform.position = new Vector3(-fieldStep * (fieldSize - 1) / 2, -fieldStep * (fieldSize - 1) / 2, 0);
    }

}
