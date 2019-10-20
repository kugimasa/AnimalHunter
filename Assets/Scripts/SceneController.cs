using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    AudioManager audioManager;
    GameObject AudioManager;
    GameObject GameData;

    private void Start()
    {
        AudioManager = GameObject.Find("AudioManager");
        GameData = GameObject.Find("GameData");
        audioManager = AudioManager.GetComponent<AudioManager>();
    }

    public void ChangeScene(string scene)
    {
        audioManager.PlayOKButton();
        if (scene == "TitleScene")
        {
            SceneManager.MoveGameObjectToScene(AudioManager, SceneManager.GetActiveScene());
            SceneManager.MoveGameObjectToScene(GameData, SceneManager.GetActiveScene());
        }
        SceneManager.LoadScene(scene);
    }
}
