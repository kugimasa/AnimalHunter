using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerStep;

    public void SetPosition(int currentPos, int fieldSize, float fieldStep)
    {
        this.transform.localPosition = new Vector3(currentPos / fieldSize, currentPos % fieldSize, 0) * fieldStep + new Vector3(playerStep, playerStep / 2, 0);
    }

}
