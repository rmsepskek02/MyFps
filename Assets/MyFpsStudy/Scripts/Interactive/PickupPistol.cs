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
        public GameObject ammoUI;

        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
            action = "Pickup Pistol";
        }

        protected override void DoAction()
        {
            ammoUI.SetActive(true);
            realPistol.SetActive(true);
            arrow.SetActive(false);
            Destroy(gameObject);
        }
    }
}