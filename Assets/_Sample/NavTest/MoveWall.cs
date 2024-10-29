using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySample
{

    public class MoveWall : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 1f;
        [SerializeField] private float moveTime = 1f;
        private float countDown = 0f;
        [SerializeField] private float dir = 1f;
        // Start is called before the first frame update
        void Start()
        {
            countDown = 1f;
        }

        // Update is called once per frame
        void Update()
        {
            if(countDown <= 0f)
            {
                dir *= -1;
                countDown = 1f;
            }
            countDown -= Time.deltaTime;

            transform.Translate(Vector3.right * dir * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}
