using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

public class Navegacion : MonoBehaviour
{
    // Start is called before the first frame update
    public void irLogin()
    {
        SceneManager.LoadScene("Login");
    }

    public void irRegistro()
    {
        SceneManager.LoadScene("Registro");
    }

    public void irAcerca()
    {
        SceneManager.LoadScene("Acerca");
    }

    public void irReglas()
    {
        SceneManager.LoadScene("Reglas");
    }

    public void irComenzar()
    {
        SceneManager.LoadScene("cinOficinaTurismo");
    }

    public void irInicio()
    {
        try
        {
            DatosPlayer oDatosPlayer = DatosPlayer.DatosPlayerinstance;
            oDatosPlayer.DestruirDatosPlayer();
        }
        catch (System.Exception)
        {
            Debug.Log("Error");
        }

        SceneManager.LoadScene("Inicio");
    }

    public void irComenzarOmitirHistoria()
    {
        SceneManager.LoadScene("Nivel 1");
    }

    public void irScore()
    {
        SceneManager.LoadScene("Puntuaciones");
    }

    public void salir()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
