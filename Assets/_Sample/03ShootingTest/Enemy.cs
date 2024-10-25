using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySample
{
    public class Enemy : MonoBehaviour, IDamageable
    {
        [SerializeField] private float maxHealth = 20;
        private float currentHealth;
        private bool isDeath = false;
        // Start is called before the first frame update
        void Start()
        {
            currentHealth = maxHealth;
            isDeath = false;
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            Debug.Log($"hp = {currentHealth}");
            if(currentHealth <= 0 && !isDeath)
            {
                Die();
            }
        }
        void Die()
        {
            isDeath = true;

            Destroy(gameObject,3f);
        }
    }
}
