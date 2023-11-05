using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 1f;
    private Rigidbody2D oRigidbody2D;
    float fMovimientoX = 0f;
    float fMovimientoY = 0f;
    private Vector2 oMovimientoEntrada;
    private Animator oAnimator;

    //private Vector2 PosicionMause;

    //private Camera oCamara;

    public GameObject oPistola;

    public GameObject oPistolaHelada;

    public void Awake()
    {
        oRigidbody2D = GetComponent<Rigidbody2D>();
        oAnimator = GetComponent<Animator>();
        //oCamara = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fMovimientoX = Input.GetAxisRaw("Horizontal");
        fMovimientoY = Input.GetAxisRaw("Vertical");
        oMovimientoEntrada = new Vector2(fMovimientoX, fMovimientoY).normalized;
        oAnimator.SetFloat("fHorizontal", fMovimientoX);
        oAnimator.SetFloat("fVertical", fMovimientoY);
        oAnimator.SetFloat("fVelocidad", oMovimientoEntrada.sqrMagnitude);

        if (Input.GetButtonDown("Jump"))
        {
            if (oPistola.activeSelf)
            {
                oPistola.SetActive(false);
                oPistolaHelada.SetActive(true);
            }
            else
            {
                oPistola.SetActive(true);
                oPistolaHelada.SetActive(false);
            }
        }
    }

    private void FixedUpdate()
    {
        oRigidbody2D.MovePosition(oRigidbody2D.position + oMovimientoEntrada * speed * Time.fixedDeltaTime);
    }
}
