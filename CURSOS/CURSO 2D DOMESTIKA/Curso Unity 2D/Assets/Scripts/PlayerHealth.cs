using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int totalHealth = 3;

    private int health ;

    private SpriteRenderer _renderer;

    public RectTransform heardUI;
    private float heardSize = 16f;

    public GameObject hordes;
    public RectTransform gameOverMenu;
    private Animator _animator;
    private PlayerController _playerController;
    private void Awake()
    {
        health = totalHealth;
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _playerController = GetComponent<PlayerController>();
    }

    void Start()
    {
        
    }

    public void AddDamage(int amount)
    {
        //Debug.Log(health);
        health = health - amount;

        // Visual Feedback
        StartCoroutine("VisualFeedback");

        // Game  Over
        if (health <= 0)
        {
            health = 0;
            gameObject.SetActive(false);
        }

        heardUI.sizeDelta = new Vector2 (heardSize * health, heardSize);

        //Debug.Log("Player got damaged. His current health is " + health);



    }

    public void AddHealth(int amount)
    {
        health = health + amount;

        // Max health
        if (health > totalHealth)
        {
            health = totalHealth;
        }

        heardUI.sizeDelta = new Vector2(heardSize * health, heardSize);

        //Debug.Log("Player got some life. His current health is " + health);
    }

    private IEnumerator VisualFeedback()
    {
        _renderer.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        _renderer.color = Color.white;
    }

    private void OnEnable()
    {
        health = totalHealth;
    }

    private void OnDisable()
    {
        try
        {
            gameOverMenu.gameObject.SetActive(true);
            hordes.SetActive(false);
            _animator.enabled = false;
            _playerController.enabled = false;
        }
        catch (System.Exception e)
        {
            Debug.Log("ERROR: " + e.Message);
        }

    }
}
