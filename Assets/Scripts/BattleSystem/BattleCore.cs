using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState { Start, ToDoTurn, PlayerTurn, Won, Lost }

public class BattleCore : MonoBehaviour
{

    public BattleState state;
    public Text dialogueText;

    public battleHUD playerHUD;
    public battleHUD toDoHUD;
    // public Transform playerBattleStation;
    // public Transform enemyBattleStation;

    PlayerStats playerUnit;
    ToDoListStats enemyUnit;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.Start;
        StartBattle();
    }

    void StartBattle()
    {
        // Instantiate(playerUnit, playerBattleStation);
        // Instantiate(enemyUnit, enemyBattleStation);
        GameObject playerOb = Instantiate(playerPrefab);
        playerUnit = playerOb.GetComponent<PlayerStats>();

        GameObject enemyOb = Instantiate(enemyPrefab);
        enemyUnit = enemyOb.GetComponent<ToDoListStats>();

        dialogueText.text = enemyUnit.toDoListName + "THE DEFILED";
    }
}
