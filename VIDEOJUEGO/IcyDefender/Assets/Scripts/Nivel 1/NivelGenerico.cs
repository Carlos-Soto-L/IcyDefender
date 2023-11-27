using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nivel : MonoBehaviour
{

    public Texture2D cursorTexture; // Asigna aquí la textura del nuevo cursor
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    private bool isAcaboNivel = false;
    private DatosPlayer datosPlayer;

    public GameObject alertaSalir;

   
   

    private void Awake()
    {
        datosPlayer = DatosPlayer.DatosPlayerinstance;
    }

    // Start is called before the first frame update
    void Start()
    {
        setCursor();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject anObjectWithTag = GameObject.FindWithTag("Zombie");
        if (anObjectWithTag == null && isAcaboNivel == false)
        {
            isAcaboNivel = true;
            Debug.Log("Acabo nivel");
            SceneManager.LoadScene("Nivel 2");
            // TODO: Mover a cuando carga la pagina.
            //DBMongo.ActualizarScore(datosPlayer.getPuntuacion());
        }
    }

    private void setCursor()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    public void ocultarAlertaSalir()
    {
        alertaSalir.SetActive(false);
    }

    public void mostrarAlertaSalir()
    {
        alertaSalir.SetActive(true);
    }





}
