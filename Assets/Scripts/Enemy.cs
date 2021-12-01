using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
  //  public EnemyType myType;
   // public PatrolType patrolType;
    int patrolPoint = 0;  //needed for linear patrol
    bool reverse = false;  //eneeded for repeat patrol
    public EnemyManager _EM;
    public Transform moveToPos;
    Transform startPos;
    float baseSpeed = 2f;
    float baseHealth = 100f;
    public float mySpeed;
    public float myHealth;
    Transform endPos;
    public int _damage = 1;

    Animator anim;
    NavMeshAgent agent;
    int currentWaypoint;
    float detectDistance = 10;
    float detectTime = 5;

    // Start is called before the first frame update
    void Start()
    {
    
        startPos = transform;
        _EM = FindObjectOfType<EnemyManager>();
        moveToPos = _EM.spawnPoints[Random.Range(0, _EM.spawnPoints.Length)];
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        /*  void ChangeSpeed(float _speed)
          {
              agent.speed = _speed;
          }*/

       

       /* void Attack()
        {
            if(!attacking)
            {
                attacking = true;
                AnimationEvent.SetTrigger("Attack" + RandomAnimation());
                StartCouroutine(ResetAttack());
            }
        }

        IEnumerator ResetAttack()
        {
            yielf return new WaitForSeconds(2);
            attacking = false;
        }

        int RandomAnimation()
       {
       return Random.Range(1,4);
       }*/

    }
    
    
    public void Hit(int _damage)
    {
        Debug.Log("test");
        myHealth -= _damage;
        if (myHealth <= 0)
            Die();
        else
            GameEvents.ReportEnemyHit(gameObject);
    }

    void Die()
    {
        GameEvents.ReportEnemyDied(gameObject);
    }
}
