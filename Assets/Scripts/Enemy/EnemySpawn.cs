using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy;
    public float repeatTime = 5f;
    public float waitTime = 1f;

    private const int length = 600;
    private Vector3 startPoint = new Vector3(-50f, 4f, -100f);
    private Vector3[] mmap = new Vector3[]
    {
        new Vector3(1, 0, 0),
        new Vector3(0, 0, 1),
        new Vector3(-1, 0, 0),
        new Vector3(0, 0, -1)
    };
    private float time = 0f;

    private void Start()
    {
        Invoke("spawn", waitTime);
    }

    private void spawn()
    {
        int len = Random.Range(0, length);
        int res = len / 150;
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
            spawnPoint += 150 * mmap[i];
        }
        spawnPoint += len % 150 * mmap[res];
        Instantiate(Enemy, spawnPoint, transform.rotation);

        time += Time.deltaTime;
        if (time < 40) repeatTime = 5 - 0.1f * time;
        else repeatTime = 0.5f;

        Invoke("spawn", repeatTime);
    }
}
