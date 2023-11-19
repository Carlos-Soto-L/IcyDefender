using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{

    public float velocidadMovimiento = 5f; // Velocidad de movimiento del objeto
                                           
	// Awake is good to get references from the same object or others in the scene
    private void Awake()
	{
		Debug.Log("I'm attached as a component of an object in the Scene!");
	}

	// Start is called before the first frame update
	void Start()
	{
		Debug.Log("You have just pressed PLAY BUTTON!");
	}

	// Update is called once per frame
	void Update()
	{
		/* Let's check some
		 * input from keyboard
		 * and change colors! */
		if (Input.GetKeyDown(KeyCode.R)) {
			this.GetComponent<SpriteRenderer>().color = Color.red;
		}

		if (Input.GetKeyDown(KeyCode.Y)) {
			this.GetComponent<SpriteRenderer>().color = Color.yellow;
		}

		if (Input.GetKeyDown(KeyCode.C)) {
			this.GetComponent<SpriteRenderer>().color = Color.cyan;
		}

		if (Input.GetKeyDown(KeyCode.G)) {
			this.GetComponent<SpriteRenderer>().color = Color.green;
		}

        // Mover hacia arriba
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * velocidadMovimiento * Time.deltaTime);
        }

        // Mover hacia abajo
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * velocidadMovimiento * Time.deltaTime);
        }

        // Mover hacia la izquierda
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * velocidadMovimiento * Time.deltaTime);
        }

        // Mover hacia la derecha
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * velocidadMovimiento * Time.deltaTime);
        }
    }
}
