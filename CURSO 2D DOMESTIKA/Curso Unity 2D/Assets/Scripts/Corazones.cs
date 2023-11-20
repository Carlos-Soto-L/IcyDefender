using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corazones : MonoBehaviour
{
    // Start is called before the first frame update

    public RectTransform heardUI;

    private void Awake()
    {
        heardUI = GetComponent<RectTransform>();
    }
    public void resetSize()
    {
        heardUI.sizeDelta = new Vector2(16f * 3, 16f);
    }
}
