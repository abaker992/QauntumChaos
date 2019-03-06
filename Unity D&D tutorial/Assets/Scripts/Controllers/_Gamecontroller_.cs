using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Gamecontroller_ : MonoBehaviour
{
    public static _Gamecontroller_ gameController { get; private set; }
    static int playerScore = 0;
    static int enemyScore = 0;


    private void Awake()
    {
        if (gameController == null)
        {
            gameController = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void KeepScore (GameObject card, int score)
    {
        bool isPlayer = card.GetComponent<_GenericCardBehavior_>().ofPlayer;
        Debug.Log(isPlayer);

        if ( playerScore <= (3) && isPlayer )
        {
            playerScore += score;
            Debug.Log(playerScore);
            if (playerScore == 4)
            {
                playerScore = 0;
                enemyScore = 0;
                Debug.Log("you win");
            }
        }
        else if(enemyScore <= (3) && !(isPlayer))
        {
            enemyScore += score;
            Debug.Log(enemyScore);
            if (enemyScore == 4)
            {
                playerScore = 0;
                enemyScore = 0;
                Debug.Log("you lose");
            }
        }

         


    }

    public void PlayerTurn()
    {
        _PlayerController_.playerController.SetTurn();
        Debug.Log(_PlayerController_.playerController.GetTurn());
    }

}
