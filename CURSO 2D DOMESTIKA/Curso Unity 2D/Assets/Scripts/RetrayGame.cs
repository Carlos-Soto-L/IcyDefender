using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetrayGame : MonoBehaviour
{

    public void limpiarEscenario()
    {
        // Encuentra todos los objetos de juego con el tag "Enemy"
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemy");

        // Itera sobre cada objeto y lo destruye
        foreach (GameObject enemigo in enemigos)
        {
            Destroy(enemigo);
        }

        // Encuentra todos los objetos de juego con el tag "Enemy"
        GameObject[] polvos = GameObject.FindGameObjectsWithTag("Polvo");

        // Itera sobre cada objeto y lo destruye
        foreach (GameObject povs in polvos)
        {
            Destroy(povs);
        }
    }
}
