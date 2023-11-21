using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScriptMSG : MonoBehaviour
{

    public TMP_InputField passwordInput;
    public TMP_Text toggleButtonText;

    private bool isPasswordVisible = false;

    public void TogglePasswordVisibility()
    {
        isPasswordVisible = !isPasswordVisible;
        passwordInput.contentType = isPasswordVisible ? TMP_InputField.ContentType.Standard : TMP_InputField.ContentType.Password;
        passwordInput.Select();
        toggleButtonText.text = isPasswordVisible ? "Ocultar" : "Ver";
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
}
