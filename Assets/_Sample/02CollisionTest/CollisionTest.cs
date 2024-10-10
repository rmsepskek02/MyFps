using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySample
{
    public class CollisionTest : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnCollisionEnter(Collision collision)
        {
            MoveObject moveObject = collision.gameObject.GetComponent<MoveObject>();
            if(moveObject != null)
                moveObject.MoveRight();

            //Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            //rb.AddForce(Vector3.left * 3f, ForceMode.Impulse);
        }
        private void OnCollisionStay(Collision collision)
        {
            Debug.Log("C STAY = " + collision.gameObject.name);
        }
        private void OnCollisionExit(Collision collision)
        {
            MoveObject moveObject = collision.gameObject.GetComponent<MoveObject>();
            if (moveObject != null)
                moveObject.MoveRight();

            //Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            //rb.AddForce(Vector3.left * 3f, ForceMode.Impulse);
        }
    }
}
