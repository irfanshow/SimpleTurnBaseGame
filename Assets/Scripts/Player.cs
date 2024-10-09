using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float playerHP = 100f;
    public float playerAttack = 10f;
    public float playerDef = 100f;
    public bool isPlayerDefending;

    //Player UI
    public TextMeshProUGUI playerATK_text;
    public TextMeshProUGUI playerDEF_text;
    public Slider playerHealth_Slider;

    GameManager gameManager;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        string playerATK_Status = "ATK" + playerAttack.ToString();
        string playerDEF_Status = "DEF" + playerDef.ToString();

        playerATK_text.text = playerATK_Status;
        playerDEF_text.text = playerDEF_Status;
        playerHealth_Slider.value = playerHP;





    }

    public void PlayerAttackEnemy()
    {
        gameManager.PlayerAttackEnemyAction();
        StaticVariable.enemyTurn = (EnemyAction)Random.Range(0, 2);

    }

    public void PlayerDefending()
    {
        gameManager.PlayerDefendingAction();
        StaticVariable.enemyTurn = (EnemyAction)Random.Range(0, 2);
    }
}
