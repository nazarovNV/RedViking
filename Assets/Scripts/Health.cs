using System.Collections;
using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health;
    public Action<int,GameObject> OnTakeHit;
    private Animator animator;
    private EnemyPatrol enemypatrol;
    public Player player;
    public int CurrentHealth
    {
        get { return health; }
    }

    private void Start()
    {
        GameManager.Instance.healthContainer.Add(gameObject,this);
        animator = GetComponent<Animator>();

    }

    public void TakeHit(int damage,GameObject attacker)
    {
        health -= damage;

        if(OnTakeHit!=null)
        {
            OnTakeHit(damage,attacker);
        }


        if (health <= 0)
        {
            if (gameObject.tag == "Wolf")
            {
                enemypatrol.blockMovement = true;
                animator.SetTrigger("Death");
            }
            if (gameObject.tag == "Player")
            {
                gameObject.tag = "DeadBody";
                player.BlockMovement = true;
                animator.SetTrigger("Death");
            }
        }
    }

    public void SetHealth(int bonusHealth)
    {
        health += bonusHealth;
       
    }
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}

