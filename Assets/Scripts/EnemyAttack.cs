using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private EnemyMovement enemymovement;
    private Transform player;
    public float attackRange = 10f;

    public Material defaultMaterial;
    public Material attackMaterial;
    private Renderer rend;

    private bool foundPlayer;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemymovement = GetComponent<EnemyMovement>();
        rend = GetComponent<Renderer>();
    }



    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            rend.sharedMaterial = attackMaterial;
            enemymovement.badGuy.SetDestination(player.position);
            foundPlayer = true;

        } 
         else if (foundPlayer)
        {
            rend.sharedMaterial = defaultMaterial;
            enemymovement.newLocation();
            foundPlayer = false;
        }
    }
}
