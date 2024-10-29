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
        // 로봇의 현태상태
        private RobotState currentState;
        // 로봇의 이전상태
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
        // 2초마다 공격
        void AttackOnTimer()
        {
            atkTimer -= atkDelay * Time.deltaTime;
            if (atkTimer < 0f)
            {
                // 공격
                Debug.Log("ATTACK");
                PlayerController pc = thePlayer.GetComponent<PlayerController>();
                if(pc != null)
                {
                    pc.TakeDamage(atkDamage);
                }

                // 타이머 초기화
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

        // 로봇의 상태 변경
        public void SetState(RobotState newState)
        {
            // 현재 상태 체크
            if (currentState == newState)
                return;

            // 이전 상태 저장
            beforeState = currentState;
            // 상태 변경
            currentState = newState;

            // 상태 변경에 따른 구현 내용
            animator.SetInteger("RobotState", (int)newState);
        }
    }
}
