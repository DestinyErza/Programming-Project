using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Manager : Singleton<UI_Manager>
{
    public TMP_Text itemText;
    public TMP_Text enemyCountText;
    public void UpdateEnemyCount(int _enemyCount)
    {
        enemyCountText.text = "Enemy Count: " + _enemyCount.ToString();
    }

    //health bar
}
