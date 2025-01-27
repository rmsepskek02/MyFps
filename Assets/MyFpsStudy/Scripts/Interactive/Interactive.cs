using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFps
{
    public abstract class Interactive : MonoBehaviour
    {
        protected abstract void DoAction();
        protected float theDistance;

        //action UI
        public GameObject actionUI;
        public TextMeshProUGUI actionText;
        [SerializeField] protected string action = "";
        public GameObject extraCross;
        public GameObject m_Collider;

        //true이면 Interactive 기능을 정지
        protected bool unInteractive = false;
        // Start is called before the first frame update
        protected virtual void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            theDistance = PlayerCasting.distanceFromTarget;
        }
        //마우스를 가져가면 액션 UI를 보여준다
        void OnMouseOver()
        {
            //거리가 2이하 일때
            if (theDistance <= 2f)
            {
                ShowActionUI();

                if (Input.GetButtonDown("Action"))
                {
                    HideActionUI();

                    DoAction();
                }
            }
            else
            {
                HideActionUI();
            }
        }

        //마우스가 벗어나면 액션 UI를 감춘다
        void OnMouseExit()
        {
            HideActionUI();
        }

        void ShowActionUI()
        {
            actionUI.SetActive(true);
            actionText.text = action;
            extraCross.SetActive(true);
        }

        void HideActionUI()
        {
            actionUI.SetActive(false);
            actionText.text = "";
            extraCross.SetActive(false);
        }
    }

}