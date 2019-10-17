using UnityEngine;
using System.Collections;

public class Grass : MonoBehaviour
{
    Manager manager;
    Vector2Int position;
    int id;
    [SerializeField] bool hasAnimal;
    GameObject eventSystem;

    void Start()
    {
        eventSystem = GameObject.Find("EventSystem");
        manager = eventSystem.GetComponent<Manager>();
        hasAnimal = false;
    }

    public void SetInfo(int id, int x, int y)
    {
        this.id = id;
        this.position.x = x;
        this.position.y = y;
    }

    public void SetAnimal()
    {
        this.hasAnimal = true;
    }

    public void DestroyGrass()
    {
        manager.UpdateTurn();
        //もしAnimalを見つけたら
        if (this.hasAnimal)
        {
            manager.GameClear();
        }
        Destroy(this.gameObject);
    }
}
