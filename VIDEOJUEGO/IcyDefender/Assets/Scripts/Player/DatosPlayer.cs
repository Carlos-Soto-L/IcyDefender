using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatosPlayer : MonoBehaviour
{
    private int _puntuacion = 0;
    private bool isHurt = false;
    public static DatosPlayer DatosPlayerinstance;
    public GameObject player;
    private Animator oAnimatorPlayer;

    private DatosPlayer() { }

    private void Awake()
    {
        if (DatosPlayerinstance == null)
        {
            DatosPlayerinstance = this;
            DatosPlayerinstance.oAnimatorPlayer = player.GetComponent<Animator>();
            DontDestroyOnLoad(DatosPlayerinstance);
        }
        else
        {
            Destroy(gameObject);
        }
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
        yield return new WaitForSeconds(0.1f);
        DatosPlayerinstance.oAnimatorPlayer.SetBool("isHurt", false);
        isHurt = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
