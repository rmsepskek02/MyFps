using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public enum RobotState
    {
        R_Idle,
        R_Walk,
        R_Attack,
        R_Death,
    }
    public class RobotController : MonoBehaviour, IDamageable
    {
        public AudioSource bgm01;
        public AudioSource bgm02;
        public GameObject thePlayer;
        private Animator animator;
        // �κ��� ���»���
        private RobotState currentState;
        // �κ��� ��������
        private RobotState beforeState;

        [SerializeField] private float maxHealth = 20f;
        private float currentHealth;
        private bool isDeath;
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float atkDamage = 5f;
        [SerializeField] private float atkRange = 1.5f;
        [SerializeField] private float atkDelay= 2.0f;
        private float atkTimer = 0f;
        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();

            currentHealth = maxHealth;
            SetState(RobotState.R_Idle);
        }

        // Update is called once per frame
        void Update()
        {
            if (isDeath)
                return;
            Vector3 dir = thePlayer.transform.position - transform.position;
            float distance = Vector3.Distance(thePlayer.transform.position, transform.position);
            if (distance <= atkRange)
            {
                SetState(RobotState.R_Attack);
            }
            switch (currentState)
            {
                case RobotState.R_Idle:
                    break;
                case RobotState.R_Walk:
                    transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);
                    transform.LookAt(thePlayer.transform);
                    break;
                case RobotState.R_Attack:
                    //Attack();
                    if (distance > atkRange)
                    {
                        SetState(RobotState.R_Walk);
                    }
                    break;
                case RobotState.R_Death:
                    break;
            }
        }
        // 2�ʸ��� ����
        void AttackOnTimer()
        {
            atkTimer -= atkDelay * Time.deltaTime;
            if (atkTimer < 0f)
            {
                // ����
                Debug.Log("ATTACK");
                PlayerController pc = thePlayer.GetComponent<PlayerController>();
                if(pc != null)
                {
                    pc.TakeDamage(atkDamage);
                }

                // Ÿ�̸� �ʱ�ȭ
                atkTimer = atkDelay;
            }
        }

        public void Attack()
        {
            PlayerController pc = thePlayer.GetComponent<PlayerController>();
            if (pc != null)
            {
                pc.TakeDamage(atkDamage);
            }
        }
        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0 && !isDeath)
            {
                Die();
            }
        }
        void Die()
        {
            isDeath = true;
            SetState(RobotState.R_Death);
            bgm02.Stop();
            bgm01.Play();
            Debug.Log("Die");
            transform.GetComponent<BoxCollider>().enabled = false;
        }

        // �κ��� ���� ����
        public void SetState(RobotState newState)
        {
            // ���� ���� üũ
            if (currentState == newState)
                return;

            // ���� ���� ����
            beforeState = currentState;
            // ���� ����
            currentState = newState;

            // ���� ���濡 ���� ���� ����
            animator.SetInteger("RobotState", (int)newState);
        }
    }
}
