using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class patronEnemigo : MonoBehaviour
{
    public float speed = 1.0f;
    public float minX;
    public float maxX;
    public float tiempoEspera = 2f;

    private GameObject _target;
    // Start is called before the first frame update

    //private Animator _animator;
    private Pistola _pistola;

    private Animator _animator;

    private void Awake()
    {
        // Referencia a Amimator del objeto (enemigo)
        _animator = GetComponent<Animator>();
        // Referencia a la pistola 
        // Traime el hijo de mi objeto que tenga como componente el script pistola
        _pistola = GetComponentInChildren<Pistola>();
        

    }
    void Start()
    {
        UpdateTarget();
        // Se llama la funcion corrutina
        StartCoroutine("PatrolToTarget");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   private void UpdateTarget()
    {
        if (_target == null)
        {
            // Creamos un objeto referecia
            _target = new GameObject("Target");
            // Inicializamos su posicion en el limite izquierdo de la pantalla.
            _target.transform.position = new Vector2(minX, transform.position.y);
            transform.localScale = new Vector3(-1, 1, 1);
            // Si es la primera vez, solo creame el target y posicionamelo.
            return;
        }
        // Si el enemigo se encuentra en el limite izquierdo
        if (_target.transform.position.x == minX)
        {
            // Nuestro objeto de referencia se colocará ahora en el limite derecho de la pantallas
            _target.transform.position = new Vector2(maxX, transform.position.y);
            // Giramos el enemigo a la derecha
            transform.localScale = new Vector3(1, 1, 1);
        }
        // Si el enemigo se encuentra en el limite derecho de la pantalla
        else if (_target.transform.position.x == maxX)
        {
            // Nuestro objeto de referencia se colocará ahora en el limite izquierdo de la pantallas
            _target.transform.position = new Vector2(minX, transform.position.y);
            // Giramos el enemigo a la izquierda
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    // Función corrutina: permite ejecutar pasos intercalando las acciones y incluyendo tiempos de espera.
    // Las funciones cirrutinas simpre devuelve un tipo de dato IEnumerator
    private IEnumerator PatrolToTarget()
    {// Inicio del metodo 
        // Miestras la distancia entre el enemigo y el target sea mayor a 0.5
        while (Vector2.Distance(transform.position, _target.transform.position) > 0.5f)
        {
            // Actualiza el animator (cuando se esta moviendo)
            _animator.SetBool("isDelay", false);

            // Obtenemos la dirección entre el target y el enemigo
            Vector2 direccion = _target.transform.position - transform.position;
            float xDireccion = direccion.x;

            transform.Translate(direccion.normalized * speed * Time.deltaTime);
            // ejecuta el metodo desde el inicio nuevamente.
            yield return null;
        }

        Debug.Log("Target alcanzado");
        transform.position = new Vector2(_target.transform.position.x, transform.position.y);
        UpdateTarget();
        // Actualiza el animator (cuando se esta moviendo)
        _animator.SetBool("isDelay", true);

        Debug.Log("Esperando " + tiempoEspera + "segundos");
        // Ejecuta las siguientes lineas de codigo despues de esperar x segundos.
        if (_pistola != null)
        {
            _animator.SetTrigger("Disparo");
            _pistola.disparar();
        }
        yield return new WaitForSeconds(tiempoEspera);

        Debug.Log("Actualizando posición del target para el movimiento del enemigo");
        // Vuelve a llamar la funcion corrutina
        StartCoroutine("PatrolToTarget");


    } // fin del metodo
}
