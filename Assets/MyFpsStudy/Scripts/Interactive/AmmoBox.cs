using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class AmmoBox : Interactive
    {
        public Transform bulletsUI;
        public GameObject bulletUI;
        
        [SerializeField] private int giveBullet = 7;
        protected override void DoAction()
        {
            Debug.Log("탄환 7개를 지급 했습니다");
            m_Collider.SetActive(false);
            PlayerStats.Instance.SetBullet(giveBullet);
            foreach (Transform child in bulletsUI)
            {
                Destroy(child.gameObject);
            }
            for (var i = 0; i < giveBullet; i++)
            {
                Instantiate(bulletUI, bulletsUI);
            }
        }

        // Start is called before the first frame update
        protected override void Start()
        {
            action = "Pick Up Ammo Box";
        }
    }
}
