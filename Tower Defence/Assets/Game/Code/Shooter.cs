using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject Bullet;

    public float ShootInterval;
    private float m_Timer;
    private bool m_CanShoot;


    private void Start()
    {
        m_Timer = ShootInterval;
    }

    private void Update()
    {
        if (m_Timer <= 0 && !m_CanShoot)
        {
            m_CanShoot = true;
        }
        else
        {
            m_Timer -= Time.deltaTime;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy") && m_CanShoot)
        {
            GameObject _bullet = Instantiate(Bullet, transform.position, Quaternion.identity);
            _bullet.GetComponent<Bullet>().Target = other.transform;

            m_CanShoot = false;
            m_Timer = ShootInterval;
        }
    }
}
