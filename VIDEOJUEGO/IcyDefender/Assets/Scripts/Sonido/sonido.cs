using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonido : MonoBehaviour
{

    public static Sonido instance;

    // Variable para almacenar el componente AudioSource
    private AudioSource audioSource;

    public AudioClip sonidoInicio;

    public AudioClip sonidoCinematicas;

    public AudioClip sonidoNivel1;
    public AudioClip sonidoNivel2;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        // Verifica si ya existe una instancia de AudioManager
        if (instance == null)
        {
            // Si no existe, establece esta instancia como la instancia �nica
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Si ya existe una instancia, destruye este objeto para evitar duplicados
            Destroy(gameObject);
        }
    }

    // M�todo para cambiar la m�sica
    public void CambiarMusicaCine()
    {
        // Cambia la m�sica al nuevo AudioClip proporcionado
        audioSource.clip = sonidoCinematicas;

        // Reproduce la nueva m�sica
        audioSource.Play();
    }

    public void CambiarMusicaInicio()
    {
        // Cambia la m�sica al nuevo AudioClip proporcionado
        audioSource.clip = sonidoInicio;

        // Reproduce la nueva m�sica
        audioSource.Play();
    }

    public void CambiarMusicaNivel1()
    {
        // Cambia la m�sica al nuevo AudioClip proporcionado
        audioSource.clip = sonidoNivel1;

        // Reproduce la nueva m�sica
        audioSource.Play();
    }

    public void CambiarMusicaNivel2()
    {
        // Cambia la m�sica al nuevo AudioClip proporcionado
        audioSource.clip = sonidoNivel2;

        // Reproduce la nueva m�sica
        audioSource.Play();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
