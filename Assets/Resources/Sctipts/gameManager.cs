using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public KeyCode[] playerKeys;
    public float circleRadius;

    public MeshRenderer ball;
    GameObject playerPrefab;


    List<GameObject> players;
    float randomTimeforStarting;
    float timeBeforeShooting = 0;
    bool reloadTheGame = true;

    bool playerCanShoot = false;


    private void Awake()
    {
        playerPrefab = Resources.Load<GameObject>("Prefabs/player");
        players = new List<GameObject>();
        RespownInCircle();
    }



    private void Update()
    {

        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].GetComponent<Player>().gunShoot)
            {
                if (playerCanShoot)
                {
                    SomeoneDies(players[i]);
                    Debug.Log("player: i " + i);
                    players[i].GetComponent<Player>().gunShoot = false;
                }
                else
                {
                    players[i].GetComponent<Player>().dead();
                    players.Remove(players[i]);
                    players[i].GetComponent<Player>().gunShoot = false;

                }

            }
        }
        if (reloadTheGame)
        {
            ReloadTheGame();
            reloadTheGame = false;
        }


        timeBeforeShooting += Time.deltaTime;
        if (timeBeforeShooting > randomTimeforStarting)
        {
            ChangeTHeRedTOGreen();
        }

        PlayerShooted();
    }
    void ReloadTheGame()
    {
        randomTimeforStarting = Random.Range(0, 7.0f);
        timeBeforeShooting = 0;
        ball.material.color = Color.red;
        for (int i = 0; i < players.Count; i++)
        {
            players[i].GetComponent<Player>().ResetPlayer();
        }
    }

    void RespownInCircle()
    {
        float angleToRespown = 360 / playerKeys.Length;

        float radian = angleToRespown * Mathf.Deg2Rad;
        for (int i = 0; i < playerKeys.Length; i++)
        {
            Vector3 loc = new Vector3(Mathf.Sin(radian * (i + 1)), 1, Mathf.Cos(radian * (i + 1))) * circleRadius;

            GameObject player = GameObject.Instantiate<GameObject>(playerPrefab, loc, Quaternion.identity);
            player.gameObject.transform.forward = -player.transform.position.normalized;
            player.transform.localEulerAngles -= new Vector3(135, 0, 0);
            player.gameObject.name = ("player: " + (i));
            player.GetComponent<Player>().keycode = playerKeys[i];

            players.Add(player);

        }
    }
    void ChangeTHeRedTOGreen()
    {
        ball.material.color = Color.green;
        playerCanShoot = true;
    }

    void PlayerShooted()
    {

    }
    void SomeoneDies(GameObject shooter)
    {
        int number_of_Players = players.Count;
        while (players.Count == number_of_Players)
        {
            int randomPlayerToDie = Random.Range(0, players.Count + 1);
            for (int i = 0; i < players.Count; i++)
            {
                if (i == randomPlayerToDie && players[i] != shooter)
                {
                    players[i].GetComponent<Player>().isAlive = false;
                    players.Remove(players[i]);
                    return;
                    Debug.Log(players.Count)  ;
                }

            }

        }


    }
}
