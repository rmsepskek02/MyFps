using UnityEngine;
using TMPro;

namespace MyFps
{
    public class DoorCellOpen : Interactive
    {
        #region Variables
        //action
        private Animator animator;
        private Collider m_Collider;
        public AudioSource audioSource;
        #endregion

        protected override void Start()
        {
            base.Start();
            animator = GetComponent<Animator>();
            m_Collider = GetComponent<BoxCollider>();
            action = "Open The Door";
        }

        protected override void Update()
        {
            base.Update();
        }

        //마우스를 가져가면 액션 UI를 보여준다
        protected override void OnMouseOver()
        {
            base.OnMouseOver();
        }

        //마우스가 벗어나면 액션 UI를 감춘다
        protected override void OnMouseExit()
        {
            base.OnMouseExit();
        }

        protected override void ShowActionUI()
        {
            base.ShowActionUI();
        }

        protected override void HideActionUI()
        {
            base.HideActionUI();
        }
        protected override void DoAtion()
        {
            //문이 열리는 액션
            GetComponent<Collider>().enabled = false;
            animator.SetBool("IsOpen", true);
            audioSource.Play();
        }
    }
}