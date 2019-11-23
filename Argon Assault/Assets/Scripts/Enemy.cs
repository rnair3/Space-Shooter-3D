using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyDeathFX;
    [SerializeField] Transform parent;
    [SerializeField] int damage = 20;
    ScoreDisplay scoreDisplay;
    [SerializeField] int hits = 3;

    private void Start()
    {
        AddBoxCollider();

        scoreDisplay = FindObjectOfType<ScoreDisplay>();
    }

    private void AddBoxCollider()
    {
        BoxCollider collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        scoreDisplay.ScoreHit(damage);
        hits--;
        if(hits <= 0)
        {
            KillEnemy();
        }
        
    }

    private void KillEnemy()
    {
        GameObject vfx = Instantiate(enemyDeathFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }
}
