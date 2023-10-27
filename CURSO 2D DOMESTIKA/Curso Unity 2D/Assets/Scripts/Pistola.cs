using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola : MonoBehaviour
{
    public GameObject prefabProyectil;

    private Transform _puntoPartida;

    public GameObject pistolero;

    // Se utliza para buscar y agregar referencias s
    private void Awake()
    {
        // En este paso se esta agregando la referencia al ObjetGame hijo llamado puntoPartida
        _puntoPartida = this.transform.Find("puntoPartida");
    }

    // Start is called before the first frame update
    void Start()
    {
        // Metodo a llamar, tiempo a pasar antes de llamar el metodo
        //Invoke("disparar", 1f);
        //Invoke("disparar", 2f);
        //Invoke("disparar", 3f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void disparar()
    {
        if (prefabProyectil != null && _puntoPartida != null && pistolero != null)
        {
            //Instanciamos un proyectil en la posicion adecuada 
            GameObject miProyectil = Instantiate(prefabProyectil, _puntoPartida.position, Quaternion.identity) as GameObject;

            // Instanciamos un objeto de la clase Proyectil
            Proyectil proyectilComponente = miProyectil.GetComponent<Proyectil>();

            // si la escala del eje x es 1, es decir, es mayor a 0 significa que esta volveando al lado derecho
            if (pistolero.transform.localScale.x > 0f)
            {
                proyectilComponente.direccion = Vector2.right; // esto es igual a: new Vector2( 1f, 0)
            }
            // si la escala del eje x es -1, es decir es menos a 0 significa que esta volveando al lado izquierdo
            else
            {
                proyectilComponente.direccion = Vector2.left; // esto es igual a: new Vector2( -1f, 0)
            }
        }
    }
}
