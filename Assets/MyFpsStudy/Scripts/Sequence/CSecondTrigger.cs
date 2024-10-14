using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class CSecondTrigger : MonoBehaviour
    {
        public GameObject theDoor;
        public AudioSource doorBang;

        public AudioSource jumpScare;
        public GameObject theRobot;
        public GameObject pistol;
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
            if (pistol != null) return;
            FirstPersonController fpc = other.gameObject.GetComponent<FirstPersonController>();
            if (fpc != null)
            {
                Animator anim = theDoor.GetComponent<Animator>();
                anim.SetBool("IsOpen", true);
            }

            StartCoroutine("DisplaySounds");
        }

        IEnumerator DisplaySounds()
        {
            doorBang.Play();
            theRobot.SetActive(true);
            yield return new WaitForSeconds(1f);
            jumpScare.Play();
        }
    }
}
