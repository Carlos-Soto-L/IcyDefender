using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float lastSpawnTime;
    public float spawnDelay = 1.5f;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press and after the delay, send dog
        if (Input.GetKeyDown(KeyCode.Space) && Time.time - lastSpawnTime > spawnDelay)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            lastSpawnTime = Time.time; // Actualizar el tiempo del último spawn
        }
    }
}