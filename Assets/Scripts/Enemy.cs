using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : GameBehaviour
{
    //  public EnemyType myType;
    // public PatrolType patrolType;
    int patrolPoint = 0;  //needed for linear patrol
    bool reverse = false;  //eneeded for repeat patrol

    public EnemyType myType;
    public PatrolType patrolType;


    
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
    float attackDistance = 3.5f;
    public bool attacking;

    public float distToPlayer;
    public float distToWaypoint;



    void Start()
    {
        anim = GetComponent<Animator>();
        startPos = transform;
       // _EM = FindObjectOfType<EnemyManager>();
        moveToPos = _EM.spawnPoints[Random.Range(0, _EM.spawnPoints.Length)];
        agent = GetComponent<NavMeshAgent>();
        SetNav();
        Setup();

    }

    // Update is called once per frame
    void Update()
    {
        void ChangeSpeed(float _speed)
        {
            agent.speed = _speed;
        }



        void Attack()
        {
            if (!attacking)
            {
                attacking = true;
                anim.SetTrigger("Attack" + RandomAnimation());
                StartCoroutine(ResetAttack());
            }
        }

        IEnumerator ResetAttack()
        {
            yield return new WaitForSeconds(2);
            attacking = false;
        }

        int RandomAnimation()
        {
            return Random.Range(1, 4);
        }

        float distToPlayer = Vector3.Distance(transform.position, _P.transform.position);

        if (distToPlayer <= detectDistance)
        {
            patrolType = PatrolType.Detect;

        }
        if (distToPlayer <= attackDistance)
        {
            patrolType = PatrolType.Attack;

        }

        //controls the patrols of enemy between detect attack and chase
        switch (patrolType)
        {
            case PatrolType.Attack:
                agent.SetDestination(transform.position);
                transform.LookAt(new Vector3(_P.transform.position.x, 0, _P.transform.position.z));
                Attack();
                break;
            case PatrolType.Chase:
                agent.SetDestination(_P.transform.position);
                ChangeSpeed(mySpeed * 2);
                if (distToPlayer > detectDistance)
                    patrolType = PatrolType.Detect;
                break;
            case PatrolType.Detect:
                agent.SetDestination(transform.position);
                ChangeSpeed(0);
                detectTime -= Time.deltaTime;
                if (detectTime <= 0)
                {
                    if (distToPlayer <= detectDistance)
                    {
                        if (patrolType != PatrolType.Chase)
                        {
                            detectTime = 5;
                        }

                    }
                    else
                    {
                        patrolType = PatrolType.Patrol;
                        SetNav();
                    }
                }
                break;

            case PatrolType.Patrol:
                float distToWaypoint = Vector3.Distance(transform.position, _EM.spawnPoints[currentWaypoint].position);
                if (distToWaypoint < 1)
                    SetNav();
                detectTime = 5;


                break;
        }
    }
    void SetNav()
    {
        currentWaypoint = Random.Range(0, _EM.spawnPoints.Length);
        agent.SetDestination(_EM.spawnPoints[currentWaypoint].position);
        ChangeSpeed(mySpeed);
    }
    void ChangeSpeed(float _speed)
    {
        agent.speed = _speed;
    }

    public void Hit(int _damage)
    {
        Debug.Log("test");
        myHealth -= _damage;
        anim.SetTrigger("Hit");
        if (myHealth <= 0)
            Die();
        else
            GameEvents.ReportEnemyHit(gameObject);
    }

    void Die()
    {
        anim.SetTrigger("Die");
        GameEvents.ReportEnemyDied(gameObject);
    }

    void Attack()
    {
        if (!attacking)
        {
            attacking = true;
            anim.SetTrigger("Attack" + RandomAnimation());
            StartCoroutine(ResetAttack());
        }
    }
    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(2);
        attacking = false;
    }
    int RandomAnimation()
    {
        return Random.Range(1, 3);
    }

    void Setup()
    {
        switch (myType)
        {
            case EnemyType.OneHand:
                mySpeed = baseSpeed;
                myHealth = baseHealth;
                break;
            case EnemyType.TwoHand:
                mySpeed = baseSpeed / 2f;
                myHealth = baseHealth * 2f;
                break;
        
        }

    }
}
