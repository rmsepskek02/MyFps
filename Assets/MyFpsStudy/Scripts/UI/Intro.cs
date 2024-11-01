using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFps
{
    public class Intro : MonoBehaviour
    {
        public GameObject textUI;
        public GameObject houseLight;
        public SceneFader fader;
        private string loadToScene = "PlaySceneStudy";

        public CinemachineDollyCart cart;
        private bool[] isArrive;
        [SerializeField] private int wayPointIndex = 0;
        private Animator cameraAnim;
        public GameObject virtualCamera;

        // Start is called before the first frame update
        void Start()
        {
            cart.m_Speed = 0f;
            wayPointIndex = 0;
            isArrive = new bool[5];
            StartCoroutine(StartIntro());
            cameraAnim = virtualCamera.GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (cart.m_Position >= wayPointIndex && isArrive[wayPointIndex] == false)
            {
                if (wayPointIndex == isArrive.Length - 1)
                {
                    StartCoroutine(EndIntro());
                }
                else
                {
                    StartCoroutine(StayIntro());
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GoToMainScene();
            }
        }

        IEnumerator StartIntro()
        {
            fader.FromFade();
            AudioManager.Instance.PlayBgm("IntroBgm");

            yield return new WaitForSeconds(1f);
            isArrive[wayPointIndex] = true;
            wayPointIndex++;
            cameraAnim.SetTrigger("ArroundTrigger");

            yield return new WaitForSeconds(3f);
            cart.m_Speed = 0.08f;
        }
        IEnumerator StayIntro()
        {
            isArrive[wayPointIndex] = true;
            wayPointIndex++;
            cart.m_Speed = 0f;
            cameraAnim.SetTrigger("ArroundTrigger");

            int nowIndex = wayPointIndex - 1;
            switch (nowIndex)
            {
                case 1:
                    textUI.SetActive(true);
                    break;
                case 2:
                    textUI.SetActive(false);
                    break;
                case 3:
                    houseLight.SetActive(true);
                    break;
            }

            yield return new WaitForSeconds(3f);
            cart.m_Speed = 0.08f;
        }
        IEnumerator EndIntro()
        {
            isArrive[wayPointIndex] = true;
            cart.m_Speed = 0f;
            yield return new WaitForSeconds(2f);
            houseLight.SetActive(false);
            yield return new WaitForSeconds(2f);
            AudioManager.Instance.StopBgm();
            fader.FadeTo(loadToScene);
        }

        private void GoToMainScene()
        {
            AudioManager.Instance.StopBgm();
            fader.FadeTo(loadToScene);
        }
    }
}