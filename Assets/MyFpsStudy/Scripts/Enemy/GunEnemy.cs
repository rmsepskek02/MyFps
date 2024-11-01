using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MyFps
{
    public enum EnemyState
    {
        E_Idle,     //���
        E_Walk,     //�ȱ� - ���� ���������� ���� ���
        E_Attack,   //���Ž� ����
        E_Death,    //�ױ�
        E_Chase,    //�߰�(�ȱ�) - ���� �������� ���
    }
    public class GunEnemy : MonoBehaviour, IDamageable
    {
        public Transform thePlayer;
        private Animator animator;
        private NavMeshAgent agent;
        // �κ��� ���»���
        private EnemyState currentState;
        // �κ��� ��������
        private EnemyState beforeState;
        [SerializeField] private float maxHealth = 20f;
        [SerializeField] private float detectRange = 20f;
        private float currentHealth;
        private bool isDeath;

        //[SerializeField] private float moveSpeed = 5f;

        [SerializeField] private float atkRange = 1.5f;
        [SerializeField] private float atkDamage = 5f;

        public Transform[] wayPoints;
        private int nowWayPoints = 0;
        private Vector3 startPosition; //������ġ, Ÿ���� �Ҿ����� ���ƿ��� ����
        // Start is called before the first frame update
        void Start()
        {
            thePlayer = GameObject.Find("Player").transform;
            animator = GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();

            currentHealth = maxHealth;
            SetState(EnemyState.E_Idle);
            nowWayPoints = 0;

            if (wayPoints.Length > 0)
            {
                SetState(EnemyState.E_Walk);
                GoNextPoint();
            }
            else
            {
                SetState(EnemyState.E_Idle);
            }
        }
        private void GoNextPoint()
        {
            nowWayPoints++;
            if (nowWayPoints >= wayPoints.Length)
            {
                nowWayPoints = 0;
            }
            agent.SetDestination(wayPoints[nowWayPoints].position);
        }
        // �κ��� ���� ����
        public void SetState(EnemyState newState)
        {
            // ���� ���� üũ
            if (currentState == newState)
                return;

            // ���� ���� ����
            beforeState = currentState;
            // ���� ����
            currentState = newState;
            if (currentState == EnemyState.E_Chase)
            {
                animator.SetInteger("EnemyState", 1);
                animator.SetLayerWeight(1, 1f);
            }
            else
            {
                animator.SetInteger("EnemyState", (int)newState);
                animator.SetLayerWeight(1, 0f);
            }
            agent.ResetPath();
        }
        // Update is called once per frame
        void Update()
        {
            if (isDeath) return;

            Vector3 dir = thePlayer.transform.position - transform.position;
            float distance = Vector3.Distance(thePlayer.transform.position, transform.position);
            bool isAiming = distance <= detectRange;


            if (distance <= atkRange)
            {
                SetState(EnemyState.E_Attack);
            }
            
            switch (currentState)
            {
                case EnemyState.E_Idle:
                    break;
                case EnemyState.E_Walk:
                    if (isAiming)
                    {
                        SetState(EnemyState.E_Chase);
                    }
                    // ���� ����
                    if (agent.remainingDistance <= 0.2f)
                    {
                        GoNextPoint();
                    }
                    //else
                    //{
                    //    SetState(EnemyState.E_Idle);
                    //}
                    break;
                case EnemyState.E_Attack:
                    transform.LookAt(thePlayer.position);
                    if (distance > atkRange)
                    {
                        SetState(EnemyState.E_Chase);
                    }
                    break;
                case EnemyState.E_Death:
                    break;
                case EnemyState.E_Chase:
                    if (!isAiming)
                    {
                        GoStartPosition();
                    }
                    else
                    {
                        agent.SetDestination(thePlayer.position);
                    }
                    break;
            }
        }
        public void Attack()
        {
            IDamageable ida = thePlayer.GetComponent<IDamageable>();
            if (ida != null)
            {
                ida.TakeDamage(atkDamage);
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
        public void GoStartPosition()
        {
            if (isDeath) return;

            SetState(EnemyState.E_Walk);
            nowWayPoints = 0;
            agent.SetDestination(wayPoints[0].position);
        }
        private void Die()
        {
            SetState(EnemyState.E_Death);
            isDeath = true;
            transform.GetComponent<BoxCollider>().enabled = false;
            Destroy(gameObject, 3f);
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            // ������ �� �׸���
            Gizmos.DrawWireSphere(transform.position, detectRange);
        }
    }
}
