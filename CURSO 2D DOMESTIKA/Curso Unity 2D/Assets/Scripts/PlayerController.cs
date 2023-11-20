using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Atriutos:
    public float speed = 2.5f;
    public float jumpForce = 2.5f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius;

    // LongIdleTime
    public float longIdleTime = 5f;
    private float _longIdleTimer;

    // Referencias
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    //Movimento
    private Vector2 _movement;
    private bool _facingRight = true;
    private bool _isGrounded;

    // Atacar
    private bool _isAttacking;

    public GameObject puntoPartida;

    private SpriteRenderer _renderer;

    // Awake = referencias.
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // En update es muy recomendable utilizarlo para recoger las teclas presionadas por el usuario.
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        _movement = new Vector2(horizontalInput, 0f);
        //<>
        if (horizontalInput < 0f && _facingRight == true)
        {
            Flip();
        }else if (horizontalInput > 0f && _facingRight == false)
        {
            Flip();
        }

        // Comprobamos si el personaje está en el suelo utilizando un círculo de colisión
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Verificamos si se presiona el botón de salto, el personaje está en el suelo y no está atacando
        if (Input.GetButtonDown("Jump") && _isGrounded == true && _isAttacking == false)
        {
            // Aplicamos una fuerza hacia arriba para simular el salto
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        // Verificamos si se presiona el botón de ataque, el personaje está en el suelo y no está atacando
        if (Input.GetButtonDown("Fire1") && _isGrounded == true && _isAttacking == false)
        {
            // Detenemos el movimiento y la velocidad del personaje
            _movement = Vector2.zero;
            _rigidbody.velocity = Vector2.zero;

            // Activamos la animación de ataque mediante un disparador en el animador
            _animator.SetTrigger("Attack");
        }
    }

    // Es donde tenemos que mover cualquier objeto con físicas en unity (Rigidbody2D)
    private void FixedUpdate()
    {
        // Verificamos si el personaje no está atacando
        if (_isAttacking == false)
        {
            // Calculamos la velocidad horizontal multiplicando la dirección normalizada del movimiento por la velocidad
            float horizontalVelocity = _movement.normalized.x * speed;

            // Actualizamos la velocidad del cuerpo rígido, manteniendo la velocidad vertical sin cambios
            _rigidbody.velocity = new Vector2(horizontalVelocity, _rigidbody.velocity.y);
        }

    }

    // Antes de pintar (recomendado para ejecutar codigo relacionado para animaciones)
    private void LateUpdate()
    {
        _animator.SetBool("Idle", _movement == Vector2.zero);
        _animator.SetBool("isGrounded", _isGrounded);
        _animator.SetFloat("VerticalVelocity", _rigidbody.velocity.y);

        // Dame el estado actual de la animación
        // (Revisar el tag en la ventana inspector)
        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            _isAttacking = true;
        }
        else
        {
            _isAttacking = false;
        }

        // Mientras se este animando Idle que tiene la tag "espara"
        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("espera"))
        {
            _longIdleTimer += Time.deltaTime;
            if (_longIdleTimer >= longIdleTime)
            {
                _animator.SetTrigger("LongIdle");
            }
        }
        else
        {
            _longIdleTimer = 0f;
        }
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        float localScaleX = transform.localScale.x;
        localScaleX = localScaleX * -1f;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    public void RetrayPlayer()
    {
        _renderer.color = Color.white;
        this.transform.position = puntoPartida.transform.position;
    }


}
