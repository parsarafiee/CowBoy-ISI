using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{

    public MeshRenderer startBall;
    public bool playerCanShoot;
    public bool playerCanNotShoot;

    public GameObject playerA;
    public GameObject playerB;

    float randomNumber;
    float timeToChange = 0;

    bool playerA_Shooted;
    bool playerB_Shooted;

    bool gameReload = true;
    float timeToReload = 0;

    // Start is called before the first frame update
    void Start()
    {
        randomNumber = Random.Range(0f, 7.0f);
        startBall.material.color = Color.red;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameReload)
        {

            PlayerControler();

            timeToChange += Time.deltaTime;

            if (timeToChange > randomNumber)
            {
                startBall.material.color = Color.green;
                playerCanShoot = true;
            }
            if (playerCanShoot && playerA_Shooted)
            {
                Debug.Log("playerA won");
                GamePose();
            }
            if (!playerCanShoot && playerA_Shooted)
            {
                Debug.Log("playerA Lost");
                GamePose();
            }
            if (playerCanShoot && playerB_Shooted)
            {
                Debug.Log("playerB won");
                GamePose();
            }
            if (!playerCanShoot && playerB_Shooted)
            {
                Debug.Log("playerB Lose");
                GamePose();
            }

        }

        if (!gameReload)
        {
            timeToReload += Time.deltaTime;
            if (timeToReload>4)
            {
                Reset();
            }
        }


    }

    void PlayerControler()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerB.transform.localEulerAngles = new Vector3(-90, 0, 0);
            playerA_Shooted = true;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            playerA.transform.localEulerAngles = new Vector3(90, 0, 0);
            playerB_Shooted = true;
        }

    }
    void GamePose()
    {
        gameReload = false;
        

    }
    private void Reset()
    {
        
    }
}
