using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class PlayerController : MonoBehaviour
    {
        public Transform bulletsUI;
        public GameObject bulletUI;
        [SerializeField] private float maxHealth = 20f;
        private float currentHealth;
        private bool isDeath;
        public GameObject damageFlash;
        public AudioSource hurt01;
        public AudioSource hurt02;
        public AudioSource hurt03;
        public GameObject realPistol;
        private string loadToScene = "GameOver";
        public SceneFader fader;
        // Start is called before the first frame update
        void Start()
        {
            currentHealth = maxHealth;
            foreach (Transform child in bulletsUI)
            {
                Destroy(child.gameObject);
            }
            for (var i = 0; i < PlayerStats.Instance.BulletCount; i++)
            {
                Instantiate(bulletUI, bulletsUI);
            }

            if (PlayerStats.Instance.HasGun)
            {
                realPistol.SetActive(true);
            }
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
            fader.FadeTo(loadToScene);
        }

        IEnumerator DamageEffect()
        {
            damageFlash.SetActive(true);
            CinemachineShake.Instance.ShakeCamera(1f, 1f);
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
}
