using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PistolaController : MonoBehaviour
{
    private float fVelocidadRotacion = 100;

    private Camera oCamara;

    private Animator oAnimatorPistola;

    public GameObject prefabProyectol;

    private Transform oPuntaPistola;

    private Vector2 PosicionMause;

    private Vector2 localscale;






    private void Awake()
    {
        oCamara = Camera.main;
        oAnimatorPistola = GetComponent<Animator>();
        oPuntaPistola = this.transform.Find("PuntoDisparo");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PosicionMause = oCamara.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direccion = PosicionMause - (Vector2)transform.position;

        //Debug.Log(direccion.normalized.x + "," + direccion.normalized.y);
        localscale = transform.localScale;

        // Izquierda
        if (direccion.normalized.x < 0)
        {
            localscale.x = 1;
            transform.localScale = localscale;

            transform.right = Vector2.MoveTowards(transform.right, direccion, -fVelocidadRotacion * Time.deltaTime);
        }
        else
        {
            localscale.x = -1;
            transform.localScale = localscale;
            transform.right = Vector2.MoveTowards(transform.right, direccion, fVelocidadRotacion * Time.deltaTime);
        }

        //Debug.Log("" +transform.right);

        

        if (Input.GetButtonDown("Fire1"))
        {
            oAnimatorPistola.SetTrigger("Disparo");
        }
    }

    public void disparar()
    {
        //Instanciamos un proyectil en la posicion adecuada 
        GameObject miProyectil = Instantiate(prefabProyectol, oPuntaPistola.position, Quaternion.identity) as GameObject;

        // Instanciamos un objeto de la clase Proyectil
        scriptProyectil proyectilComponente = miProyectil.GetComponent<scriptProyectil>();

        // Ajustamos la dirección del disparo según la rotación actual del objeto
        proyectilComponente.lanzarProyectil(transform.right * Mathf.Sign(localscale.x * -1));
    }
}
