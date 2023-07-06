using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Fighter
{
    enum States { patrol, pursuit }

    [SerializeField]
    States state = States.patrol;
    [SerializeField]
    float searchRange = 10;
    [SerializeField]
    float stoppingDistance = 3;
    [SerializeField]
    float AttackCoolDown = 2;
    [SerializeField] private float vida;


    Transform player;
    Vector3 target;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // se asigna el target para los enemigos
        InvokeRepeating("SetTarget", 0, 5);   //se delimita el area en el que los enemigos nos detectan
        InvokeRepeating("SendAttack", 0, AttackCoolDown); // se asigna un cooldown al ataque de los enemigos
    }

    void SendAttack()
    {
        if(state != States.pursuit)
        {
            return;
        }
        if(vel.magnitude != 0)
        {
            return;
        }
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Attack") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Death ")) //se confirma que el enemigo no este en mitad de otra animacion antes de atacar
        {
            anim.SetTrigger("SetAttack");
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, searchRange);
        Gizmos.DrawWireSphere(target, 0.2f);
    }

    void SetTarget()
    {
        if (state != States.patrol)
            return;
        target = new Vector2(transform.position.x + Random.Range(-searchRange, searchRange), Random.Range(LimitsY.y, LimitsY.x)); // se asigna el movimiento mientras se escucha en el modo patrulla
    }

    Vector2 vel;
    void Update()
    {
        if (state == States.pursuit)
        {
            target = player.transform.position;
            if (Vector3.Distance(target, transform.position) > searchRange * 1.2f) // si es que el personaje no se encuentra en rango el enemigo vuelve a el estado de patrulla
            {
                target = transform.position;
                state = States.patrol;
                return;
            }
        }
        else if (state == States.patrol)
        {
            var ob = Physics2D.CircleCast(transform.position, searchRange, Vector2.up); // si es que el protagonista se encuentra en rango se inicia el modo patrulla
            if (ob.collider != null)
            {
                if (ob.collider.CompareTag("Player"))
                {
                    state = States.pursuit;
                    return;
                }
            }
        }
        vel = target - transform.position;
        sr.flipX = vel.x < 0;
        if(vel.magnitude < stoppingDistance)
            vel = Vector2.zero; 
        vel.Normalize();
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Attack") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_Death ")) // se limita el movimiento del enemigo si este se encuentra atacando o muriendo
        {
            anim.SetBool("isWalking", vel.magnitude != 0);
        }
        else
        {
            vel = Vector2.zero;
        }
        rb.velocity = new Vector2(vel.x * horizontalSpeed, vel.y * verticalSpeed);

    }
     public void TomarDano(float dano) // se usa el mismo sistema de vida que con el protagonista
    {
        vida-=dano;
        if(vida<=0)
        {
            anim.SetTrigger("Death");
            Destroy(gameObject,1.3f);
          
            //
        }
    }

}
