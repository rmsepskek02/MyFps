using UnityEngine;
using TMPro;

namespace MyFps
{
    public class DoorCellOpen : Interactive
    {
        #region Variables
        //action
        private Animator animator;
        public AudioSource audioSource;
        #endregion

        protected override void Start()
        {
            base.Start();
            animator = GetComponent<Animator>();
            action = "Open The Door";
        }

        protected override void DoAction()
        {
            //문이 열리는 액션
            GetComponent<Collider>().enabled = false;
            m_Collider.SetActive(false);
            animator.SetBool("IsOpen", true);
            audioSource.Play();
        }
    }
}