using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySample
{
    public class MoveObject : MonoBehaviour
    {
        private Rigidbody rb;

        [SerializeField] private float movePower = 3f;
        private float moveX;
        private Material material;
        Color originColor;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.AddForce(Vector3.right * movePower, ForceMode.Impulse);
            material = GetComponent<Renderer>().material;
            originColor = material.color;
        }

        // Update is called once per frame
        void Update()
        {
            moveX = Input.GetAxis("Horizontal");
        }

        private void FixedUpdate()
        {
            rb.AddForce(Vector3.right * moveX * movePower, ForceMode.Force);
        }

        public void MoveRight()
        {
            rb.AddForce(Vector3.right * movePower, ForceMode.Force);
        }

        public void MoveLeft()
        {
            rb.AddForce(Vector3.left * movePower, ForceMode.Force);
        }

        public void ChangeColor(Color matColor)
        {
            material.color = matColor;
        }

        public void ResetColor()
        {
            material.color = originColor;
        }
    }
}