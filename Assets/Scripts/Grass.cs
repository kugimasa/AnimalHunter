using UnityEngine;
using System.Collections;

public class Grass : MonoBehaviour
{
    Vector2Int position;
    int id;
    bool canClick;
    [SerializeField] string data;

    Manager manager;
    Animator animator;
    GameObject eventSystem;

    void Awake()
    {
        canClick = true;
        data = "None";

        eventSystem = GameObject.Find("EventSystem");
        manager = eventSystem.GetComponent<Manager>();
        animator = this.GetComponent<Animator>();
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
        if(canClick)
        {
            animator.Play("MoveGrass");
        }
    }

    public void DestroyGrass()
    {
        //Grass(マス)にクリックできるときのみ
        if (canClick)
        {
            manager.UpdateTurn();
            //もしAnimalを見つけたら
            if (data == "A")
            {
                manager.GameClear();
            }
            Destroy(this.gameObject);
        }
    }
}
