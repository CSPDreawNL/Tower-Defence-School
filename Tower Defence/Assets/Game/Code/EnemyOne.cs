using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyOne : MonoBehaviour
{
    public EnemyData Data;

    private bool ReachedEnd = false;

    public Spawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        spawner = FindObjectOfType<Spawner>();
        spawner.AddEnemy();

        GetComponent<NavMeshAgent>().speed = Data.Speed;
        GetComponent<Health>().HitPoints = Data.Health;

        GameObject _goal = GameObject.FindGameObjectWithTag("Finish");
        GetComponent<NavMeshAgent>().SetDestination(_goal.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Finish"))
        {
            Health _goalHealth = collision.collider.GetComponent<Health>();
            if (_goalHealth)
            {
                _goalHealth.ModifyHealth(-1);
            }
            ReachedEnd = true;
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        if (!ReachedEnd)
        {
            GameManager.instance.ModifyCurrency(Data.Value);
        }
        spawner.RemoveEnemy();
    }
}
