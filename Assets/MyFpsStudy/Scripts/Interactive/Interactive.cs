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

        //true�̸� Interactive ����� ����
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
        //���콺�� �������� �׼� UI�� �����ش�
        void OnMouseOver()
        {
            //�Ÿ��� 2���� �϶�
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

        //���콺�� ����� �׼� UI�� �����
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