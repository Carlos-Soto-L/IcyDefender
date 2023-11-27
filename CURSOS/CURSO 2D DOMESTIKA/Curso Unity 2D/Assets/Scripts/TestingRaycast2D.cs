using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingRaycast2D : MonoBehaviour
{
    private Animator _animator;
    private Pistola _pistola;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _pistola = GetComponentInChildren<Pistola>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _animator.SetBool("isDelay", true);   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _animator.SetTrigger("Disparo");
        }

    }

    void puedeDisparar()
    {
        if (_pistola != null)
        {
            // Hacer disparo
            StartCoroutine(_pistola.DisparoConRaycast());
        }
    }
}
