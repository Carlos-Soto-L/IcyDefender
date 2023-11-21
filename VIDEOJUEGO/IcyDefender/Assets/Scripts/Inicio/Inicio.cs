using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inicio : MonoBehaviour
{

    public GameObject botonesSesion;
    public GameObject botonScore;
    private Session _session;

    [SerializeField] private TMP_Text textoWelcome;

    private void Awake()
    {
        _session = Session.Sessioninstance;
    }
    // Start is called before the first frame update
    void Start()
    {
        mostrarBotones();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void mostrarBotones()
    {
        if (_session.isLogin())
        {
            if (_session.sNickname != "")
            {
                textoWelcome.text = "Hola: " + _session.sNickname;
            }
            botonesSesion.SetActive(false);
            botonScore.SetActive(true);
        }
        else
        {

            botonesSesion.SetActive(true);
            botonScore.SetActive(false);
        }
    }
}
