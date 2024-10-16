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
        // ���������
        [SerializeField] private float fireDelay = 0.5f;
        private bool isFire = false;
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
                StartCoroutine(Shoot());
            }
        }
        IEnumerator Shoot()
        {
            isFire = true;
            // �� �� 100m �ȿ� ���� ������ ������ ������� �ش�.
            float maxDistance = 100f;
            RaycastHit hit;
            if(Physics.Raycast(firePoint.position, firePoint.TransformDirection(Vector3.forward), out hit, maxDistance))
            {
                Debug.Log(hit.collider.gameObject.name);
                RobotController robot = hit.transform.GetComponent<RobotController>();
                if(robot != null)
                {
                    robot.TakeDamage(attackDamage);
                }
            }
            // ��ȿ�� - VFX, SFX
            Debug.Log("Shoot");
            animator.SetTrigger("Fire");
            muzzle.gameObject.SetActive(true);
            pistolSound.Play();
            muzzle.Play();
            yield return new WaitForSeconds(fireDelay);
            muzzle.Stop();
            muzzle.gameObject.SetActive(false);

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
