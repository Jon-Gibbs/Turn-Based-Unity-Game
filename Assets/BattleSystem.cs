using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState{START, PLAYERTURN, ENEMYTURN, WON, LOST, PLAYERTURNINPROGRESS }

public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    public BattleState state;

    public TextMeshProUGUI dialougeText;
   
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI playerLevelText;
    public TextMeshProUGUI playerHPText;

    public TextMeshProUGUI enemyNameText;
    public TextMeshProUGUI enemyLevelText;
    public TextMeshProUGUI enemyHPText;

    Unit playerUnit;
    Unit enemyUnit;



    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetUpBattle());
    }
    IEnumerator SetUpBattle()
    {
       GameObject playerGO =  Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();

       GameObject enemyGO =  Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        //setting the inital dialouge text box
        dialougeText.text = "A " + enemyUnit.unitName + " approaches...";
     

        //below i am setting up each battle hud
        playerNameText.text = playerUnit.unitName;
        playerLevelText.text = "Lvl: " + playerUnit.unitLevel.ToString();
        playerHPText.text = "HP: " + playerUnit.currentHP.ToString() + "/" + playerUnit.maxHP.ToString();

        enemyNameText.text = enemyUnit.unitName;
        enemyLevelText.text = "Lvl: " + enemyUnit.unitLevel.ToString();
        setHPHUD(enemyUnit, enemyHPText);

        yield return new WaitForSeconds(2f);
        state = BattleState.PLAYERTURN;
        PlayerTurn();

    }

    void PlayerTurn()
    {
        dialougeText.text = "Choose an Action:";
    }

    public void onAttackButton()
    {
        if(state != BattleState.PLAYERTURN)
        {
            return;
        }
        StartCoroutine(PlayerAttack());
    }
    public void onHealButton()
    {
        if(state != BattleState.PLAYERTURN)
        {
            return;
        }
        StartCoroutine(PlayerHeal());
    }

    IEnumerator PlayerHeal()
    {
        playerUnit.Heal();
        state = BattleState.PLAYERTURNINPROGRESS;
        setHPHUD(playerUnit, playerHPText);
        dialougeText.text = "heal was succesful!";
        yield return new WaitForSeconds(2.5f);
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());

    }
    IEnumerator PlayerAttack()
    {
        state = BattleState.PLAYERTURNINPROGRESS;
        //last line of code written at 3:00 Pm 7/30/2024, video timestamp: 21:37
      bool isAlive =  enemyUnit.takeDamage(playerUnit.damage);

        setHPHUD(enemyUnit, enemyHPText);
        //damage the enemy
        dialougeText.text = "attack was succesful!";
        yield return new WaitForSeconds(2f);
        

        //check if he ded
        if(!isAlive )
        {
            state = BattleState.WON;
            endBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
        //change state
    }
    IEnumerator EnemyTurn()
    {
        dialougeText.text = enemyUnit.unitName + " attacks!";
        bool isAlive = playerUnit.takeDamage(enemyUnit.damage);
        setHPHUD(playerUnit, playerHPText);
        yield return new WaitForSeconds(2f);
        if(!isAlive )
        {
            state = BattleState.LOST;
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }
    private void endBattle()
    {
        if(state == BattleState.WON)
        {
            dialougeText.text = "You Won!";
        }
        else if(state == BattleState.LOST)
        {
            dialougeText.text = "You Lost!";
        }

    }

    private void setHPHUD(Unit unit, TextMeshProUGUI HpText)
    {
        HpText.text = "HP: " + unit.currentHP.ToString() + "/" + unit.maxHP.ToString();
    }
    
        
    
}
