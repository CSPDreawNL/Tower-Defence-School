using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public WaveData[] Waves;

    public int m_Wave;
    private float m_WaveTimer;

    public int ActiveEnemies;

    

    // Start is called before the first frame update
    void Start()
    {
        m_Wave = 0;
        m_WaveTimer = 8;

        StartCoroutine(Countdown());
    }

    private void Update()
    {
        if (m_Wave == 6 && ActiveEnemies == 0)
        {
            InterfaceManager.instance.ShowNextLevel();
        }
    }

    public void AddEnemy()
    {
        ActiveEnemies++;
    }

    public void RemoveEnemy()
    {
        ActiveEnemies--;
    }

    IEnumerator Countdown()
    {
        while (m_WaveTimer > 0)
        {
            yield return new WaitForSeconds(1);
            m_WaveTimer--;
            InterfaceManager.instance.WaveUI.text = string.Format("NEXT WAVE in: {0}", m_WaveTimer);
        }
        InterfaceManager.instance.WaveUI.text = "";
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        if (m_Wave == 6)
        {
            yield return new WaitUntil(()=>m_Wave == 20);
        }

        for (int i = 0 ; i < Waves[m_Wave].Enemies.Length ; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(Waves[m_Wave].Enemies[i], transform.position, Quaternion.identity);
        }
        m_Wave++;
        m_WaveTimer = 8;


        if (GameManager.instance.IsGameOver)
            yield return null;
        StartCoroutine(Countdown());
    }
}
