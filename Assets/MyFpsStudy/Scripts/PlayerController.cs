using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float maxHealth = 20f;
    private float currentHealth;
    private bool isDeath;
    public GameObject damageFlash;
    public AudioSource hurt01;
    public AudioSource hurt02;
    public AudioSource hurt03;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float damage)
    {
        if (isDeath) return;
        currentHealth -= damage;
        StartCoroutine("DamageEffect");

        Debug.Log("Player hp = " + currentHealth);
        if (currentHealth <= 0 && !isDeath)
        {
            Die();
        }
    }

    void Die()
    {
        isDeath = true;
        Debug.Log("GAMEOVER");
    }

    IEnumerator DamageEffect()
    {
        damageFlash.SetActive(true);
        int randNumber = Random.Range(1, 4);
        if (randNumber == 1)
        {
            hurt01.Play();
        }
        else if (randNumber == 2)
        {
            hurt02.Play();
        }
        else if (randNumber == 3)
        {
            hurt03.Play();
        }

        yield return new WaitForSeconds(1.0f);
        damageFlash.SetActive(false);
    }
}
