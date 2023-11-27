using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Proyectil : MonoBehaviour
{
    public int damage = 1;
    public float velocidad = 0;
    public Vector2 direccion;

    public float tiempoVida = 3f;

    public Color colorInicial;
    public Color colorFinal;

    private float _comienzoVida;
    private SpriteRenderer _renderer;

    private bool _returning;
    private Rigidbody2D _rigidbody;




    private void Awake()
    {
        // Referencia a la misma bala
        _renderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Interpolacion lineal, cambiar un valor inicial a un valor final de acuerdo al tiempo
        _comienzoVida = Time.time; // Obtenemos juesto el momento en el que se ha instanciado la bala.

        //en este contexto this.gameObject es igual a GetComponent<SpriteRenderer>() 
        //Los dos son refencia al objeto que tenga el script, en este caso, el proyectil
        Destroy(this.gameObject, tiempoVida); // Destruye el proyectil despues de x tiempo


    }

    // Update is called once per frame
    void Update()
    {
        // Siempre hay que normalizar
        // Vector2 = eje x con eje y
        // Vector3 = eje x, eje y incluyendo el eje z
        Vector2 movimiento = direccion.normalized * velocidad * Time.deltaTime;
        // traslada mi objeto a la nueva posicion desde mi actual posicion.
        transform.Translate(movimiento);

        // Obtenemos el porcentaje vivido del proyectil, tomando como referencia que el 100% es el valor 
        // contenido en la variable tiempoVida
        float _tiempoTranscurrido = Time.time - _comienzoVida;
        float _porcentajeVivido = _tiempoTranscurrido / tiempoVida;

        // Cambiará el color con ayuda de la interpolación lineal 
        _renderer.color = Color.Lerp(colorInicial, colorFinal, _porcentajeVivido);
    }

    private void FixedUpdate()
    {
        //  Move object
        Vector2 movement = direccion.normalized * velocidad;
        _rigidbody.velocity = movement;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_returning == false && collision.CompareTag("Player"))
        {
            // Tell player to get hurt
            collision.SendMessageUpwards("AddDamage", damage);
            // Instancia el prefab en la posición del jugador
            Destroy(gameObject);
        }

        if (_returning == true && collision.CompareTag("Enemy"))
        {
            collision.SendMessageUpwards("AddDamage");
            Destroy(gameObject);
        }
    }

    public void AddDamage()
    {
        _returning = true;
        direccion = direccion * -1f;
    }
}
