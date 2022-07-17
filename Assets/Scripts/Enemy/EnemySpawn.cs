using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy;
    public float repeatTime = 1f;
    public float waitTime = 1f;

    private int[] map = new int[] { -70, 120, -120, 70 };
    private const int length = 760;
    private Vector3 startPoint = new Vector3(-70f, 4f, -120f);
    private Vector3[] mmap = new Vector3[]
    {
        new Vector3(1, 0, 0),
        new Vector3(0, 0, 1),
        new Vector3(-1, 0, 0),
        new Vector3(0, 0, -1)
    };

    private void Start()
    {
        InvokeRepeating("spawn", waitTime, repeatTime);
    }

    private void spawn()
    {
        int len = Random.Range(0, length);
        int res = len / 190;
        Vector3 spawnPoint = startPoint;
        /*switch (res)
        {
            case 0:
                spawnPoint += len % 190 * mmap[res];
                break;
            case 1:
                spawnPoint += 190 * mmap[0];
                spawnPoint += len % 190 * mmap[res];
                break;
            case 2:
                spawnPoint += 190 * mmap[0];
                spawnPoint += 190 * mmap[1];
                spawnPoint += len % 190 * mmap[res];
                break;
            case 3:
                spawnPoint += 190 * mmap[0];
                spawnPoint += 190 * mmap[1];
                spawnPoint += 190 * mmap[2];
                spawnPoint += len % 190 * mmap[res];
                break;
            default:
                break;
        }*/
        for(int i = 0; i < res; i++)
        {
            spawnPoint += 190 * mmap[i];
        }
        spawnPoint += len % 190 * mmap[res];
        Instantiate(Enemy, spawnPoint, transform.rotation);
    }
}
