using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corazones : MonoBehaviour
{
    // Start is called before the first frame update

    public static RectTransform heardUI;
    private DatosPlayer _datosPlayer;

    private void Awake()
    {
        heardUI = GetComponent<RectTransform>();
        _datosPlayer = DatosPlayer.DatosPlayerinstance;
    }

    private void Start()
    {
        heardUI.sizeDelta = new Vector2(70f * _datosPlayer.getVida(), 80f);
    }


    public static void resetSize(int iTotalVidas)
    {
        heardUI.sizeDelta = new Vector2(70f * iTotalVidas, 80f);
    }
}
