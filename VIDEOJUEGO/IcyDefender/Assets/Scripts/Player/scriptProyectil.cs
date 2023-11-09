using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptProyectil : MonoBehaviour
{

    [SerializeField] private float fVelocidad = 6f;

    private Rigidbody2D origidbody2Proyectil;

    private void Awake()
    {
        origidbody2Proyectil = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void lanzarProyectil(Vector2 direccion)
    {
        origidbody2Proyectil.velocity = direccion * fVelocidad;
        Destroy(this.gameObject, 3f);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
