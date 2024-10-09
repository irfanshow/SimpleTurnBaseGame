
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameState
{
    Start,
    PlayerTurn,
    EnemyTurn,
    GameOver
};

public enum EnemyAction
{
    Attack,
    Defending
}
public class GameManager : MonoBehaviour
{
    //GameObjects
    public GameObject inGameObject;

    //PlayerData
    public Player player;

    //Enemy Data
    public Enemy enemy;

    //Script
    UI_Animation ui_Animation;

    //UI
    public TextMeshProUGUI gameStateUI;
    public TextMeshProUGUI gameOvertext;
    public GameObject playerActionUI;
    public GameObject gameOverUI;
    public GameObject inGameUI;


    private void Start()
    {
        Time.timeScale = 1;
        //refence animation SCript
        ui_Animation = FindObjectOfType<UI_Animation>();

        StaticVariable.gameState = GameState.Start;
        Debug.Log("Game is Starting!");
        if (StaticVariable.gameState == GameState.Start)
        {
            StaticVariable.gameState = GameState.PlayerTurn;
        }
        Debug.Log("Player Turn");
        Debug.Log("Choose Action");
    }
    void Update()
    {

        CheckGameState();
        CheckDefenseStatus();

        //Game over condition
        if (player.playerHP <= 0)
        {
            gameOvertext.text = "You Lose";
            GameOver();
        }
        else if (enemy.enemyHP <= 0)
        {
            gameOvertext.text = "Win";
            GameOver();
        }

    }


    //Check the game state
    private void CheckGameState()
    {
        
        if (StaticVariable.gameState == GameState.PlayerTurn)
        {
            gameStateUI.text = "Player Turn";
            //Show UI for player attack and def
            if (StaticVariable.isPause == true)
            {
                playerActionUI.SetActive(false);
            }
            else
            {
                playerActionUI.SetActive(true);
            }

        }
        else if (StaticVariable.gameState == GameState.EnemyTurn)
        {
            playerActionUI.SetActive(false);
            gameStateUI.text = "Enemy Turn";
            //Hide UI for player attack and def
            StartCoroutine("EnemyTurnAction");
        }
    }


    // Enemy Action Function
    IEnumerator EnemyTurnAction()
    {

        yield return new WaitForSeconds(2.0f);

        //if the enemy random action are attacking
        if (StaticVariable.enemyTurn == EnemyAction.Attack)
        {

            enemy.isEnemyDefending = false;
            if (player.isPlayerDefending == true)
            {
                //Attack With defLeft
                if (player.playerDef >= 1 && player.playerDef <= 9)
                {
                    float damageTakenWithDef = enemy.enemyAttack - player.playerDef;
                    player.playerHP = damageTakenWithDef;
                    ui_Animation.playerDamageTakenAnimation(damageTakenWithDef);
                    StaticVariable.gameState = GameState.PlayerTurn;
                    StopCoroutine("EnemyTurnAction");
                }

                //Attack With No defLeft and PlayerNotDefending
                else if (player.playerDef <= 0)
                {
                    player.playerHP -= enemy.enemyAttack;
                    ui_Animation.playerDamageTakenAnimation(enemy.enemyAttack);
                    StaticVariable.gameState = GameState.PlayerTurn;
                    StopCoroutine("EnemyTurnAction");
                }
                //Attack WhilePlayerDefending and has more defLeft
                else
                {
                    player.playerDef -= enemy.enemyAttack;
                    ui_Animation.playerDefenseDecreaseAnimation(enemy.enemyAttack);
                    StaticVariable.gameState = GameState.PlayerTurn;
                    StopCoroutine("EnemyTurnAction");
                }

            }
            //Attack while player not defending
            else if (player.isPlayerDefending == false)
            {
                player.playerHP -= enemy.enemyAttack;
                ui_Animation.playerDamageTakenAnimation(enemy.enemyAttack);
                StaticVariable.gameState = GameState.PlayerTurn;
                StopCoroutine("EnemyTurnAction");
            }
        }

        //if the enemy random action are Defensing
        else if (StaticVariable.enemyTurn == EnemyAction.Defending)
        {

            enemy.isEnemyDefending = true;
            StaticVariable.gameState = GameState.PlayerTurn;
            StopCoroutine("EnemyTurnAction");
        }


    }

    public void PlayerAttackEnemyAction()
    {
        player.isPlayerDefending = false;

        if (enemy.isEnemyDefending == true)
        {
            //Attack With def Left
            if (enemy.enemyDef >= 1 && enemy.enemyDef <= 9)
            {

                float damageTakenWithDef = player.playerAttack - enemy.enemyDef;
                enemy.enemyHP = damageTakenWithDef;
                ui_Animation.enemyDamageTakenAnimation(damageTakenWithDef);
                StaticVariable.gameState = GameState.EnemyTurn;
            }

            //Attack with no defLeft and EnemyNotDefending
            if (enemy.enemyDef <= 0)
            {
                enemy.enemyHP -= player.playerAttack;
                ui_Animation.enemyDamageTakenAnimation(player.playerAttack);
                StaticVariable.gameState = GameState.EnemyTurn;

                Debug.Log("Enemy is Choosing Action");

            }
            //Attack WhileEnemyDefending and has more defLeft
            else
            {
                enemy.enemyDef -= player.playerAttack;
                ui_Animation.enemyDefenseDecreaseAnimation(player.playerAttack);
                StaticVariable.gameState = GameState.EnemyTurn;

                Debug.Log("Enemy is Choosing Action");
            }

        }

        //Attack while Enemy not defending
        else if (enemy.isEnemyDefending == false)
        {
            enemy.enemyHP -= player.playerAttack;
            ui_Animation.enemyDamageTakenAnimation(player.playerAttack);
            StaticVariable.gameState = GameState.EnemyTurn;

            Debug.Log("Enemy is Choosing Action");
        }

    }

    public void PlayerDefendingAction()
    {

        player.isPlayerDefending = true;
        StaticVariable.gameState = GameState.EnemyTurn;
        Debug.Log("Enemy Turn");
        Debug.Log("Enemy is Choosing Action");

    }

    //Check the Defense of player or Enemy
    private void CheckDefenseStatus()
    {
        if (player.playerDef <= 0)
        {
            player.playerDef = 0;
        }

        if (enemy.enemyDef <= 0)
        {
            enemy.enemyDef = 0;
        }
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
        inGameObject.SetActive(false);
        playerActionUI.SetActive(false);
        inGameUI.SetActive(false);

    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
