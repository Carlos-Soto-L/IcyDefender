using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTeclas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Parametro 0 = clic izquiero del raton
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("El clic izquierdo del rato esta fue presionado");
        }

        if (Input.GetMouseButton(0))
        {
            Debug.Log("El clic iaquierdo del rato esta siendo presionado");
        }

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("El clic izquierdo del rato se ha soltado");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("");
        }

        // Edit - Proyect setting - Input
        if (Input.GetButtonDown("Jump"))
        {
            //Debug.Log("Estas saltando");
        }

        // Movimiento de teclas A, W, S, D 
        float horizontal = Input.GetAxis("Horizontal");  // valores de -1 a 1 solamante
        float vertical = Input.GetAxis("Vertical"); // valores de -1 a 1 solamantes

        //><
        if (horizontal < 0f || horizontal > 0f)
        {
            //Debug.Log("El objeto se esta miviendo a la derecha o izquierda. Valor: " + horizontal);
        }

        if (vertical < 0f || vertical > 0f)
        {
            //Debug.Log("El objeto se esta miviendo arriba o abajo. Valor: " + vertical);
        }
    }
}
