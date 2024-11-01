using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MyFps
{
    // 마우스로 그라운드를 클릭하면 클릭한 지점으로 Agent를 이동시키기
    public class AgentController : MonoBehaviour
    {
        #region Variables
        private NavMeshAgent agent;

        [SerializeField] private Vector3 worldPosition; // 이동 목표지점
        #endregion
        // Start is called before the first frame update
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            //agent.SetDestination(worldPosition);
            //if (agent.isOnNavMesh)
            //{
            //    agent.SetDestination(worldPosition);
            //}
            //else
            //{
            //}
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                SetDestinationToMousePosition();
            }
        }

        private void SetDestinationToMousePosition()
        {
            Vector3 hitPosition = Vector3.zero;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }

    }
}