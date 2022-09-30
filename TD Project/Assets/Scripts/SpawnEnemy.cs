using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public static int enemycount = 0;
    public Wave[] waves;
    public Transform start;
    public float waverate = 3;

    private void Start()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        foreach(Wave wave in waves)
        {
            for(int i = 0; i < wave.count; i++)
            {
                GameObject.Instantiate(wave.enemy, start.position, Quaternion.identity);
                enemycount++;
                if(i != wave.count - 1)
                    yield return new WaitForSeconds(wave.spawnrate);
            }
            
            while(enemycount > 0)
            {
                yield return 0;
            }
            yield return new WaitForSeconds(waverate);
        }
    }
}
