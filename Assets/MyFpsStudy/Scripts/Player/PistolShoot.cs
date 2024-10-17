using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{

    public class PistolShoot : MonoBehaviour
    {
        public ParticleSystem muzzle;
        private Animator animator;
        public AudioSource pistolSound;
        public Transform cam;
        public Transform firePoint;
        public float attackDamage = 5f;
        public ParticleSystem muzzleFlash;
        // 연사딜레이
        [SerializeField] private float fireDelay = 0.5f;
        private bool isFire = false;
        public GameObject hitImpactPrefab;
        [SerializeField] private float impactForce = 1f;
        public Transform bulletsUI;
        
        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetButtonDown("Fire") && !isFire)
            {
                if (PlayerStats.Instance.UseBullet(1) == false)
                {
                    Debug.Log("You need to reload");
                    return;
                }
                StartCoroutine(Shoot());
            }
        }
        IEnumerator Shoot()
        {
            isFire = true;
            // 내 앞 100m 안에 적이 있으면 적에게 대미지를 준다.
            float maxDistance = 100f;
            RaycastHit hit;
            if(Physics.Raycast(firePoint.position, firePoint.TransformDirection(Vector3.forward), out hit, maxDistance))
            {
                Debug.Log(hit.collider.gameObject.name);
                IDamageable damageable = hit.transform.GetComponent<IDamageable>();
                if(damageable != null)
                {
                    damageable.TakeDamage(attackDamage);
                }
                GameObject eff = Instantiate(hitImpactPrefab, hit.point, Quaternion.LookRotation(hit.normal));
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce, ForceMode.Impulse);
                }
                Destroy(eff, 2f);
            }
            // 슛효과 - VFX, SFX
            Debug.Log("Shoot");
            Destroy(bulletsUI.GetChild(0).gameObject);
            animator.SetTrigger("Fire");
            muzzle.gameObject.SetActive(true);
            muzzleFlash.gameObject.SetActive(true);
            pistolSound.Play();
            muzzle.Play();
            muzzleFlash.Play();
            yield return new WaitForSeconds(fireDelay);
            muzzle.Stop();
            muzzleFlash.Stop();
            muzzle.gameObject.SetActive(false);
            muzzleFlash.gameObject.SetActive(false);

            isFire = false;
        }

        private void OnDrawGizmosSelected()
        {
            float maxDistance = 100f;
            RaycastHit hit;
            bool isHit = Physics.Raycast(firePoint.position, firePoint.TransformDirection(Vector3.forward), out hit, maxDistance);

            Gizmos.color = Color.red;
            if (isHit)
            {
                Gizmos.DrawRay(firePoint.position, firePoint.forward * hit.distance);
            }
            else
            {
                Gizmos.DrawRay(firePoint.position, firePoint.forward * maxDistance);
            }
        }
    }
}
