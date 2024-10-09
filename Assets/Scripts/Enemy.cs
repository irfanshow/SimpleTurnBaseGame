using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float enemyHP = 100f;
    public float enemyAttack = 10f;
    public float enemyDef = 100f;
    public bool isEnemyDefending;

    //Enemy UI
    public TextMeshProUGUI enemyATK_text;
    public TextMeshProUGUI enemyDEF_text;
    public Slider enemyHealth_Slider;
    

    private void Update()
    {
        string enemyATK_Status = "ATK" + enemyAttack.ToString();
        string enemyDEF_Status = "DEF" + enemyDef.ToString();

        enemyATK_text.text = enemyATK_Status;
        enemyDEF_text.text = enemyDEF_Status;
        enemyHealth_Slider.value = enemyHP;
    }

}
