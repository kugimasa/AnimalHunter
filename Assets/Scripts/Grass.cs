using UnityEngine;
using System.Collections;

public class Grass : MonoBehaviour
{
    Vector2Int position;
    int id;
    bool canClick;
    public bool isGrass;
    [SerializeField] string data;

    public GameObject Frame;

    Manager manager;
    Animator animator;
    AudioManager audioManager;
    GameObject eventSystem;
    GameObject FrameObject;

    void Awake()
    {
        canClick = false;
        isGrass = true;
        data = "None";

        eventSystem = GameObject.Find("EventSystem");
        manager = eventSystem.GetComponent<Manager>();
        animator = this.GetComponent<Animator>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    public void SetInfo(int id, int x, int y)
    {
        this.id = id;
        this.position.x = x;
        this.position.y = y;
    }

    public void SetData(string data)
    {
        this.data = data;
    }

    public void HighLightGrass()
    {
        if(canClick && isGrass)
        {
            animator.Play("MoveGrass");
            audioManager.PlayGrassMove();
        }
    }

    public void SetCanClick()
    {
        canClick = true;
        FrameObject = Instantiate(Frame) as GameObject;
        FrameObject.transform.parent = this.transform;
        FrameObject.transform.position = this.transform.position;
    }

    public void SetCannotClick()
    {
        canClick = false;
        Destroy(FrameObject);
    }

    public void DestroyGrass()
    {
        //Grass(マス)にクリックできるときのみ
        if (canClick)
        {
            isGrass = false;
            this.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            //モグラでなければ現在の位置を更新
            if (data != "H")
            {
                manager.currentPos = id;
                audioManager.PlayOK();
            }
            //モグラだったらNG音再生
            if (data == "H")
            {
                audioManager.PlayNG();
            }
            //位置がが更新されてからクリック可能を更新
            manager.UpdateTurn();
            //もしAnimalを見つけたら
            if (data == "A")
            {
                audioManager.PlayCorrect();
                manager.GameClear();
            }
        }
    }
}
