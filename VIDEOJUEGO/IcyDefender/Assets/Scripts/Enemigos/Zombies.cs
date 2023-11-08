using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombies : MonoBehaviour
{

    public Transform jugador;       // Asigna el transform del jugador desde el Inspector
    public float velocidad = 2f;

    public float distanciaDetencion = 0.30f;

    private Rigidbody2D rb;
    private Animator oAnimator;
    private bool isCongelado = false;

    private void Awake()
    {
        // Obtener la referencia al componente Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
        oAnimator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(IAZombie());
    }

    public IEnumerator IAZombie()
    {
        if (jugador != null)
        {
            // Calcula la distancia entre el enemigo y el jugador
            float distanciaAlJugador = Vector3.Distance(transform.position, jugador.position);

            Debug.Log("Distancia al jugador: " + distanciaAlJugador);
            if (isCongelado)
            {
                rb.isKinematic = true;
                yield return new WaitForSeconds(12f);
                isCongelado =false;
                rb.isKinematic = false;
            }
            else
            {
                // Si la distancia es mayor que la distancia de detención, el enemigo se mueve hacia el jugador
                if (distanciaAlJugador < distanciaDetencion)
                {
                    // Detener el movimiento desactivando el componente Rigidbody2D
                    rb.isKinematic = true;
                }
                else
                {
                    // Calcula la dirección hacia el jugador
                    Vector2 direccion = jugador.position - transform.position;

                    // Normaliza la dirección para obtener un vector unitario
                    direccion.Normalize();

                    // Mueve al enemigo en la dirección del jugador
                    transform.Translate(direccion * velocidad * Time.deltaTime);

                    oAnimator.SetFloat("fHorizontal", direccion.x);
                    oAnimator.SetFloat("fVertical", direccion.y);
                    oAnimator.SetFloat("fVelocidad", direccion.sqrMagnitude);
                }
            }


        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ProyectilHelado"))
        {
            isCongelado = true;
        }
    }
}
