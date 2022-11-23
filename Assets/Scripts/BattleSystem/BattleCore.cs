using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { Start, ToDoTurn, PlayerTurn, Won, Lost }

public class BattleCore : MonoBehaviour
{

    public BattleState state;
    public Text toDoText;

    public transform playerBattleStation;
    public transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.Start;
        StartBattle();
    }

    void StartBattle()
    {
        GameObject playerOb = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerOb.GetComponent<Unit>();

        GameObject enemyOb = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyOb.GetComponent<Unit>();

        toDoText.text = enemyUnit.unitName;
    }
}
