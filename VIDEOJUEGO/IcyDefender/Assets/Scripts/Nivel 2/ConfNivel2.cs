using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfNivel2 : MonoBehaviour
{

    // Cursor
    public Texture2D cursorTexture; // Asigna aquí la textura del nuevo cursor
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    private DatosPlayer datosPlayer;
    private bool isAcaboNivel = false;
    //private GameObject[] aParedSalida;
    public GameObject alertaWin;

    private void Awake()
    {
        datosPlayer = DatosPlayer.DatosPlayerinstance;
        DatosPlayer.reasignarJugador();
        //aParedSalida = GameObject.FindGameObjectsWithTag("Salida");
    }
    // Start is called before the first frame update
    void Start()
    {
        setCursor();
        Sonido.instance.CambiarMusicaNivel2();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject anObjectWithTag = GameObject.FindWithTag("Zombie");
        if (anObjectWithTag == null && isAcaboNivel == false)
        {
            isAcaboNivel = true;
            Debug.Log("Acabo nivel");
            // Habilitamos las salidas.
            //foreach (GameObject oSalida in aParedSalida)
            //{
            //    oSalida.SetActive(false);
            //}

            if (isAcaboNivel)
            {
                alertaWin.SetActive(true);
            DBMongo.ActualizarScore(datosPlayer.getPuntuacion());
            }
            // TODO: Mover a cuando carga la pagina.
        }
    }

    private void setCursor()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
}
