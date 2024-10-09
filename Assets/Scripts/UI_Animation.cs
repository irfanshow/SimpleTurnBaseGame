using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Animation : MonoBehaviour
{
    // UI
    public GameObject dmgTakenUI_GameObj;
    public GameObject defTakenUI_GameObj;
    public TextMeshProUGUI dmgTakenUI;
    public TextMeshProUGUI defTakenUI;
    public Transform playerDmgTakenUI_Pos;
    public Transform enemyDmgTakenUI_Pos;

    //Animation
    public Animator dmgTakenAnimation;
    public Animator defDecreaseAnimation;


    public void playerDamageTakenAnimation(float damage)
    {
        dmgTakenUI.text = "-" + damage.ToString();
        GameObject spawnDmgUI = Instantiate(dmgTakenUI_GameObj, playerDmgTakenUI_Pos.position, Quaternion.identity);
        spawnDmgUI.transform.SetParent(playerDmgTakenUI_Pos.transform, false);
        dmgTakenAnimation.Play("DamageTaken");
        Destroy(spawnDmgUI, 1f);
    }

    public void playerDefenseDecreaseAnimation(float damage)
    {
        defTakenUI.text = "-" + damage.ToString();
        GameObject spawnDmgUI = Instantiate(defTakenUI_GameObj, playerDmgTakenUI_Pos.position, Quaternion.identity);
        spawnDmgUI.transform.SetParent(playerDmgTakenUI_Pos.transform, false);
        defDecreaseAnimation.Play("DefenseDecrease");
        Destroy(spawnDmgUI, 1f);
    }

    public void enemyDamageTakenAnimation(float damage)
    {
        dmgTakenUI.text = "-" + damage.ToString();
        GameObject spawnDmgUI = Instantiate(dmgTakenUI_GameObj, enemyDmgTakenUI_Pos.position, Quaternion.identity);
        spawnDmgUI.transform.SetParent(enemyDmgTakenUI_Pos.transform, false);
        dmgTakenAnimation.Play("DamageTaken");
        Destroy(spawnDmgUI, 1f);
    }

    public void enemyDefenseDecreaseAnimation(float damage)
    {
        defTakenUI.text = "-" + damage.ToString();
        GameObject spawnDmgUI = Instantiate(defTakenUI_GameObj, enemyDmgTakenUI_Pos.position, Quaternion.identity);
        spawnDmgUI.transform.SetParent(enemyDmgTakenUI_Pos.transform, false);
        defDecreaseAnimation.Play("DefenseDecrease");
        Destroy(spawnDmgUI, 1f);
    }


}
