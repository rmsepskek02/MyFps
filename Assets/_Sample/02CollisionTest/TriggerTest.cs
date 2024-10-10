using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySample
{
    public class TriggerTest : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            MoveObject moveObject = other.gameObject.GetComponent<MoveObject>();
            if (moveObject != null)
                moveObject.MoveRight();
            moveObject.ChangeColor(Color.red);
            //Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            //rb.AddForce(Vector3.right * 3f, ForceMode.Impulse);
            //Renderer rend = other.GetComponent<Renderer>();
            //rend.material.color = Color.red;
        }

        private void OnTriggerStay(Collider other)
        {
            Debug.Log("T STAY = " + other.gameObject.name);
        }
        private void OnTriggerExit(Collider other)
        {
            MoveObject moveObject = other.gameObject.GetComponent<MoveObject>();
            if (moveObject != null)
                moveObject.MoveRight();
            moveObject.ResetColor();
            //Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            //rb.AddForce(Vector3.right * 3f, ForceMode.Impulse);
            //Renderer rend = other.GetComponent<Renderer>();
            //Color origin = rend.material.color;
            //rend.material.color = origin;
        }
    }
}
