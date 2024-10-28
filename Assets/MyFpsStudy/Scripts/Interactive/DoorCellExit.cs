using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class DoorCellExit : Interactive
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainScene02";

        private Animator animator;
        public AudioSource creakyDoor; //문여는 소리

        public AudioSource bgm01;         //배경음
        #endregion

        protected override void Start()
        {
            //참조
            animator = GetComponent<Animator>();
        }
        protected override void DoAction()
        {
            //1.문여는 애니메이션
            //2.문여는 사운드
            animator.SetBool("IsOpen", true);

            creakyDoor.Play();

            ChangeScene();
        }

        void ChangeScene()
        {
            //씬마무리, .... bmg stop
            bgm01.Stop();

            //다음씬으로 이동
            fader.FadeTo(loadToScene);
        }
    }
}
