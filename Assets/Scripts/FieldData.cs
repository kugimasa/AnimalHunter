using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldData : MonoBehaviour
{
    
    public int fieldSize;
    public float fieldStep;
    public string[] fieldData;
    public GameObject field;
    public GameObject FootPrint;
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

    void SetGrass()
    {
        Id = 0;
        for (int i = 0; i < fieldSize; i++)
        {
            for (int j = 0; j < fieldSize; j++)
            {
                GameObject grassObject = Instantiate(Grass) as GameObject;
                grassObject.transform.position = new Vector3(i, j, 0) * fieldStep;
                grass[Id] = grassObject.GetComponent<Grass>();
                grass[Id].SetInfo(Id, i, j);
                grassObject.transform.parent = field.transform;
                Id++;
            }
        }
        field.transform.position = new Vector3(-fieldStep * (fieldSize - 1) / 2, -fieldStep * (fieldSize - 1) / 2, 0);
    }

    void SetData()
    {
        Id = 0;
        for (int i = 0; i < fieldSize; i++)
        {
            for (int j = 0; j < fieldSize; j++)
            {
                CreateData(i, j, fieldData[Id]);
                Id++;
            }
        }
        this.transform.position = new Vector3(-fieldStep * (fieldSize - 1) / 2, -fieldStep * (fieldSize - 1) / 2, 0);
    }

    void CreateData(int i, int j, string dataName)
    {
        GameObject data;
        if (dataName == "F")
        {
            data = FootPrint;
        }else if (dataName == "A")
        {
            data = Animal;
        }else if (dataName == "H")
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
}
