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

    SceneController sceneController;
    // Start is called before the first frame update
    void Start()
    {
        currentTurn = maxTurn;
        turnText.text = maxTurn.ToString();
        resultPlane.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTurn == 0)
        {
            resultPlane.SetActive(true);
        }
    }

    //Update turn
    public void updateTurn()
    {
        currentTurn--;
        turnText.text = currentTurn.ToString();
    }
    
}
