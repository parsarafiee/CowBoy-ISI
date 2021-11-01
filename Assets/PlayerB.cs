using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerB : MonoBehaviour
{
    public gameManager manager;
    bool canShoot;
    public bool alive = true;
    public bool win;
    public bool shootWrongTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {

            if (manager.playerCanShoot)
            {
                canShoot = true;
            }
            if (canShoot)
            {
                PlayerControler();
            }
        }
        if (win)
        {
            Debug.Log("player B Win");
        }

    }
    void PlayerControler()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            win = true;
        }
    }

}
