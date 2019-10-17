using UnityEngine;
using System.Collections;

public class Grass : MonoBehaviour
{
    Manager manager;
    Vector2Int position;
    int id;
    GameObject eventSystem;

    void Start()
    {
        eventSystem = GameObject.Find("EventSystem");
        manager = eventSystem.GetComponent<Manager>();
    }

    public void SetInfo(int id, int x, int y)
    {
        this.id = id;
        this.position.x = x;
        this.position.y = y;
    }

    public void DestroyGrass()
    {
        manager.updateTurn();
        Destroy(this.gameObject);
    }
}
