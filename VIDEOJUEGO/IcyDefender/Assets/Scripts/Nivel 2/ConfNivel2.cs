using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfNivel2 : MonoBehaviour
{

    // Cursor
    public Texture2D cursorTexture; // Asigna aquí la textura del nuevo cursor
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;


    // Start is called before the first frame update
    void Start()
    {
        setCursor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void setCursor()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
}
