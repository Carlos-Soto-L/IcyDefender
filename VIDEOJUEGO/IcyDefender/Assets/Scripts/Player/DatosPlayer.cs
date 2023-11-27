using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatosPlayer : MonoBehaviour
{
    private int _puntuacion = 0;
    private bool isHurt = false;
    public static DatosPlayer DatosPlayerinstance;
    private GameObject player;
    private Animator oAnimatorPlayer;
    private int iTotalVida = 5;
    private Corazones _corazones;

    private DatosPlayer() { }

    private void Awake()
    {
        if (DatosPlayerinstance == null)
        {
            DatosPlayerinstance = this;
            DatosPlayerinstance.oAnimatorPlayer = reencontrarPlayer();
            DontDestroyOnLoad(DatosPlayerinstance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Animator reencontrarPlayer()
    {
        player = GameObject.FindWithTag("Player");
        return player.GetComponent<Animator>();
    }

    public static void reasignarJugador()
    {
        GameObject player = GameObject.FindWithTag("Player");
        DatosPlayerinstance.player = player;
        DatosPlayerinstance.oAnimatorPlayer = player.GetComponent<Animator>();
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void sumarPuntos(int iPuntos)
    {

        DatosPlayerinstance._puntuacion += iPuntos;
    }

    public void restarPuntos(int iPuntos)
    {
        if (DatosPlayerinstance._puntuacion > 0)
        {
            DatosPlayerinstance._puntuacion -= iPuntos;
            if (DatosPlayerinstance._puntuacion < 0)
            {
                DatosPlayerinstance._puntuacion = 0;
            }
        }
    }

    public void mostrarPuntos()
    {
        Debug.LogFormat("Puntuación actual: {0}", DatosPlayerinstance._puntuacion);
    }

    public int getPuntuacion()
    {
        return DatosPlayerinstance._puntuacion;
    }

    public void hurtPlayer()
    {
        if (isHurt == false)
        {
            StartCoroutine(causarHurt());
        }
    }

    public IEnumerator causarHurt()
    {
        
        DatosPlayerinstance.oAnimatorPlayer.SetBool("isHurt", true);
        
        isHurt = true;
        yield return new WaitForSeconds(0.3f);
        DatosPlayerinstance.iTotalVida--;
        DatosPlayerinstance.restarPuntos(50);
        Corazones.resetSize(DatosPlayerinstance.iTotalVida);
        DatosPlayerinstance.oAnimatorPlayer.SetBool("isHurt", false);
        isHurt = false;

    }

    public int getVida()
    {
        return DatosPlayerinstance.iTotalVida;
    }

    public void restarVida()
    {
        DatosPlayerinstance.iTotalVida = DatosPlayerinstance.iTotalVida - 1;
    }

    public void activarPlayer()
    {
        player.SetActive(true);
    }


    public void desactivarPlayer()
    {
        player.SetActive(false);
    }

    // Función para destruir el objeto DatosPlayer
    public void DestruirDatosPlayer()
    {
        Destroy(gameObject);
    }

    public void retry()
    {
        DatosPlayerinstance.isHurt = false;
        DatosPlayerinstance.iTotalVida = 5;
        DatosPlayerinstance._puntuacion = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
