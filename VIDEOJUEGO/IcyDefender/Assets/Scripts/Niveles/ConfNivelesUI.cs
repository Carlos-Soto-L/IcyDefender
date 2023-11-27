using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfNivelesUI : MonoBehaviour
{

    public Texture2D cursorTextureNormal; // Asigna aquí la textura del nuevo cursor
    public Texture2D cursorTextureJuego;
    public CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpotNormal = Vector2.zero;
    private Vector2 hotSpotJuego = new Vector2(16, 33);

    // Referencia al texto del panel
    [SerializeField] private TMP_Text txtScore;

    private DatosPlayer datosPlayer;

    public GameObject alertaSalir;
    private bool isPaused = false;
    public RectTransform heardUI;

    public GameObject alertaGameOver;

    private bool isGameOver = false;

    private void Awake()
    {
        datosPlayer = DatosPlayer.DatosPlayerinstance;
        heardUI = GetComponent<RectTransform>();

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txtScore.text = datosPlayer.getPuntuacion().ToString();

        if (datosPlayer.getVida() < 1 && isGameOver == false)
        {
            isGameOver = true;
            datosPlayer.desactivarPlayer();
            // TODO: Mover a cuando carga la pagina.
            DBMongo.ActualizarScore(datosPlayer.getPuntuacion());
            mostrarGameOver();
            this.TogglePause();
        }

    }

    public void mostrarAlertaSalir()
    {
        this.setCursorNormal();
        alertaSalir.SetActive(true);
    }

    public void ocultarAlertaSalir()
    {
        this.setCursorJuego();
        alertaSalir.SetActive(false);
    }

    public void mostrarGameOver()
    {
        this.setCursorNormal();
        alertaGameOver.SetActive(true);
    }

    public void ocultarGameOver()
    {
        this.setCursorJuego();
        alertaGameOver.SetActive(false);
    }

    public void reitentarJuego()
    {
        Time.timeScale = 1f;
        datosPlayer.retry();
        datosPlayer.DestruirDatosPlayer();
        SceneManager.LoadScene("Nivel 1");
    }


    public void setCursorNormal()
    {
        Cursor.SetCursor(cursorTextureNormal, hotSpotNormal, cursorMode);
    }


    private void setCursorJuego()
    {
        Cursor.SetCursor(cursorTextureJuego, hotSpotJuego, cursorMode);
    }

    // Otro código puede ir aquí

    // Método para manejar la pausa/despausa
    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // Pausa el tiempo en el juego
        }
        else
        {
            Time.timeScale = 1f; // Restaura el tiempo normal en el juego
        }
    }

}
