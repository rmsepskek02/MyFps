using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class CSecondTrigger : MonoBehaviour
    {
        public GameObject theDoor;
        private 
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
            FirstPersonController fpc = other.gameObject.GetComponent<FirstPersonController>();
            if (fpc != null)
            {
                Animator anim = theDoor.GetComponent<Animator>();
                anim.SetBool("IsOpen", true);
            }
        }
    }
}
