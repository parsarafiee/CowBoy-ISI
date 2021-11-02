using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public bool restartThePlayer = false;
    public KeyCode keycode;
    public bool gunShoot;
    public bool isAlive;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            PlayerContoroller();
            if (restartThePlayer)
            {
                ResetPlayer();
            }
        }

        if (!isAlive)
        {
            dead();
        }

    }
    void PlayerContoroller()
    {
        if (Input.GetKeyDown(keycode))
        {
            Debug.Log("name :" + name);
            gunShoot = true;
        }
    }

    public void ResetPlayer()
    {
        isAlive = true;
        this.transform.localEulerAngles += new Vector3(90, 0, 0);
    }

    public void dead()
    {
        this.gameObject.SetActive(false);

    }

}
