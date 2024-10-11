using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFps
{
    public class PickupPistol : Interactive
    {
        public GameObject realPistol;
        public GameObject arrow;
        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
            action = "Pickup Pistol";
        }

        // Update is called once per frame
        protected override void Update()
        {
            base.Update();
        }
        protected override void OnMouseOver()
        {
            base.OnMouseOver();
        }
        //���콺�� ����� �׼� UI�� �����
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
            realPistol.SetActive(true);
            arrow.SetActive(false);
            Destroy(gameObject);
        }
    }
}