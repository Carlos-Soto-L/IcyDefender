using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombies : MonoBehaviour
{

    public GameObject jugador;       // Asigna el transform del jugador desde el Inspector
    private Animator oAnimatorPlayer;
    public float velocidad = 2f;

    DatosPlayer datosPlayer;

    public float distanciaDetencion = 0.30f;

    //private Rigidbody2D rb;
    private Animator oAnimator;
    private bool isCongelado = false;
    private bool fueCongelado = false;
    public Transform oTransformZombie;
    public int iTotalVida = 10;

    private void Awake()
    {
        // Obtener la referencia al componente Rigidbody2D
        //rb = GetComponent<Rigidbody2D>();
        oAnimator = GetComponent<Animator>();
        oTransformZombie = GetComponent<Transform>();
        datosPlayer = DatosPlayer.DatosPlayerinstance;
        oAnimatorPlayer = jugador.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (iTotalVida <= 0)
        {
            oAnimator.SetBool("isMuerto", true);
        }
        else
        {
            if (isCongelado && !fueCongelado)
            {
                StartCoroutine(IAZombie());
                fueCongelado = true;
            }
            else if (isCongelado == false && fueCongelado == false)
            {
                if (jugador != null)
                {
                    float distanciaAlJugador = Vector3.Distance(transform.position, jugador.transform.position);

                    if (distanciaAlJugador <= distanciaDetencion)
                    {
                        DatosPlayer.DatosPlayerinstance.hurtPlayer();
                        //oTransformZombie.position = new Vector3(oTransformZombie.position.x, oTransformZombie.position.y, 0f);
                    }
                    else
                    {
                        //oAnimatorPlayer.SetBool("isHurt", false);
                        Vector2 direccion = jugador.transform.position - transform.position;
                        direccion.Normalize();
                        transform.Translate(direccion * velocidad * Time.deltaTime);

                        oAnimator.SetFloat("fHorizontal", direccion.x);
                        oAnimator.SetFloat("fVertical", direccion.y);
                        oAnimator.SetFloat("fVelocidad", direccion.sqrMagnitude);
                    }
                }
            }
        }
        
    }

    public IEnumerator IAZombie()
    {
        fueCongelado = true;
        oAnimator.SetBool("isCongelado", true);
        datosPlayer.restarPuntos(25);
        oTransformZombie.position = new Vector3(oTransformZombie.position.x, oTransformZombie.position.y, 0f);
        yield return new WaitForSeconds(1f);
        oAnimator.SetBool("isCongelado", false);
        isCongelado = false;
        fueCongelado = false;


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (datosPlayer != null)
        {
            if (collision.gameObject.CompareTag("ProyectilFuego"))
            {
                datosPlayer.sumarPuntos(10);
                iTotalVida--;
            }
        }
        if (collision.gameObject.CompareTag("ProyectilHelado"))
        {
            if (!fueCongelado)
            {
                isCongelado = true;
            }
        }


    }

    private void Morir()
    {
        Destroy(gameObject);
    }
}
