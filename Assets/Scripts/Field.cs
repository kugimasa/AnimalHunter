using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Field : MonoBehaviour
{

    public int fieldSize;
    public float fieldStep;
    public GameObject Grass;
    Grass[] grass;
    int grassId = 0;

    // Use this for initialization
    void Start()
    {
        grass = new Grass[fieldSize*fieldSize];
        SetGrass();

    }

    //Set Grass
    void SetGrass()
    {
        for (int i = 0; i < fieldSize; i++)
        {
            for (int j = 0; j < fieldSize; j++)
            {
                GameObject grassObject = Instantiate(Grass) as GameObject;
                grassObject.transform.position = new Vector3(i, j, 0) * fieldStep;
                grass[grassId] = grassObject.GetComponent<Grass>();
                grass[grassId].SetInfo(grassId, i, j);
                grassObject.transform.parent = this.transform;
                grassId++;
            }
        }
        this.transform.position = new Vector3(-fieldStep * (fieldSize - 1) / 2, -fieldStep * (fieldSize - 1) / 2, 0);
    }
}
