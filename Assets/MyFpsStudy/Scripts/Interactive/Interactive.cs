using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFps
{
    public abstract class Interactive : MonoBehaviour
    {
        protected abstract void DoAtion();
        protected float theDistance;

        //action UI
        public GameObject actionUI;
        public TextMeshProUGUI actionText;
        [SerializeField] protected string action = "";
        public GameObject extraCross;
        // Start is called before the first frame update
        protected virtual void Start()
        {

        }

        // Update is called once per frame
        protected virtual void Update()
        {
            theDistance = PlayerCasting.distanceFromTarget;
        }
        //���콺�� �������� �׼� UI�� �����ش�
        protected virtual void OnMouseOver()
        {
            //�Ÿ��� 2���� �϶�
            if (theDistance <= 2f)
            {
                ShowActionUI();

                if (Input.GetButtonDown("Action"))
                {
                    HideActionUI();

                    DoAtion();
                }
            }
            else
            {
                HideActionUI();
            }
        }

        //���콺�� ����� �׼� UI�� �����
        protected virtual void OnMouseExit()
        {
            HideActionUI();
        }

        protected virtual void ShowActionUI()
        {
            actionUI.SetActive(true);
            actionText.text = action;
            extraCross.SetActive(true);
        }

        protected virtual void HideActionUI()
        {
            actionUI.SetActive(false);
            actionText.text = "";
            extraCross.SetActive(false);
        }
    }
}
