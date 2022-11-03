using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbox : MonoBehaviour
{
    public Animator animCoin;

    private float randomNumber;

    public int player1Wins;
    public int player1Black;
    public int player1White;

    public int player2Wins;
    public int player2Black;
    public int player2White;

    //-1 means player one / black & 1 means player two / white
    public int playerTurn = -1;
    public int coinChoise = -1;
    public int coinResult;
    bool canFlip = true;
    public int TotalFlipped = 0;

    // Start is called before the first frame update
    void Start()
    {

    }
    public void Restart()
    {
        playerTurn = -1;
        coinChoise = -1;
        canFlip = true;
        TotalFlipped = 0;
        player1Wins = 0;
        player1White = 0;
        player1Black = 0;
        player2Wins = 0;
        player2White = 0;
        player2Black = 0;
    }

    // Update is called once per frame
    void Update()
    {
        randomNumber = Random.Range(-10f, 10f);
        if (Input.GetKeyDown(KeyCode.Space) && canFlip == true)
        {
            FlipCoin();
        }

        if (playerTurn == -1 && Input.GetKeyUp(KeyCode.E) && canFlip == true)
        {
            canFlip = false;
            Invoke("BlackSide", 0.05f);
            animCoin.SetBool("ChangeToBlack", true);
        }

        else if (playerTurn == -1 && Input.GetKeyUp(KeyCode.Q) && canFlip == true)
        {
            canFlip = false;
            Invoke("WhiteSide", 0.05f);
            animCoin.SetBool("ChangeToWhite", true);
        }

        if (playerTurn == 1 && Input.GetKeyUp(KeyCode.U) && canFlip == true)
        {
            canFlip = false;
            Invoke("WhiteSide", 0.05f);
            animCoin.SetBool("ChangeToWhite", true);
        }
        else if (playerTurn == 1 && Input.GetKeyUp(KeyCode.O) && canFlip == true)
        {
            canFlip = false;
            Invoke("BlackSide", 0.05f);
            animCoin.SetBool("ChangeToBlack", true);
        }
        //ChooseTurn();
    }

    public void BlackSide()
    {
        canFlip = true;
        coinChoise = -1;
        animCoin.SetBool("ChangeToBlack", false);
    }

    public void WhiteSide()
    {
        canFlip = true;
        coinChoise = 1;
        animCoin.SetBool("ChangeToWhite", false);
    }

    void CollectPoint1()
    {
        player1Wins++;
        if (coinResult == -1)
        {
            player1Black++;
        }
        else if (coinResult == 1)
        {
            player1White++;
        }
    }

    void CollectPoint2()
    {
        player2Wins++;
        if (coinResult == -1)
        {
            player2Black++;
        }
        else if (coinResult == 1)
        {
            player2White++;
        }
    }

    void FlipCoin()
    {
        canFlip = false;
        if (randomNumber > 0)
        {
            animCoin.SetBool("FlipBlack", true);
            coinResult = -1;
        }
        else if (randomNumber <= 0)
        {
            animCoin.SetBool("FlipWhite", true);
            coinResult = 1;
        }
        if (coinChoise == coinResult)
        {
            if (playerTurn == -1)
            {
                CollectPoint1();
            }
            else if (playerTurn == 1)
            {
                CollectPoint2();
            }
        }
        TotalFlipped++;
        Invoke("EndTurn", 1.1f);
    }

    void EndTurn()
    {
        playerTurn = -playerTurn;
        animCoin.SetBool("FlipWhite", false);
        animCoin.SetBool("FlipBlack", false);
        canFlip = true;
    }
}
