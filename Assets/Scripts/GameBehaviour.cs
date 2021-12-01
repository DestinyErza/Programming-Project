using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    //singleton references list
    protected static GameManager _GM { get { return GameManager.instance; } }
    protected static EnemyManager _EM { get { return EnemyManager.instance; } }
    protected static UI_Manager _UI { get { return UI_Manager.instance; } }
    protected static PlayerMovement _P { get { return PlayerMovement.instance; } }
    protected static InventoryScript _I { get { return InventoryScript.instance; } }
}
