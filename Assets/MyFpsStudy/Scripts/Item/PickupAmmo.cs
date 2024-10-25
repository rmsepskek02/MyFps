using UnityEngine;

namespace MyFps
{
    public class PickupAmmo : PickupItem
    {
        public Transform bulletsUI;
        public GameObject bulletUI;
        #region Variables
        [SerializeField] private int giveBullet = 7;
        #endregion

        protected override bool OnPickup()
        {
            //탄환 7개 지급
            PlayerStats.Instance.SetBullet(giveBullet);
            for (var i = 0; i < giveBullet; i++)
            {
                Instantiate(bulletUI, bulletsUI);
            }
            return true;
        }
    }
}