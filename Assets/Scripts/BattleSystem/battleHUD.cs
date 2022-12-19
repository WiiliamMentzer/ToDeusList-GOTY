using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class battleHUD : MonoBehaviour
{
    public Text nameText;
    public Text levelText;
    public Slider hpSlider;

    public void SetPlayerHud(PlayerStats player){
        nameText.text = player.playerName;
    }
        public void SetEnemyHud(ToDoListStats toDo){
        nameText.text = toDo.toDoListName;
    }
}
