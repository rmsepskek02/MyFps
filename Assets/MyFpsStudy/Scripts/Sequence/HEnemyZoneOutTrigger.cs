using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MyFps
{
    public class HEnemyZoneOutTrigger : MonoBehaviour
    {
        public Transform gunMan;
        GunEnemy gunEnemy;
        public GameObject enemyZoneIn;
        // Start is called before the first frame update
        void Start()
        {
            gunEnemy = gunMan.GetComponent<GunEnemy>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                if(gunMan != null)
                    gunEnemy.GoStartPosition();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                this.gameObject.SetActive(false);
                enemyZoneIn.SetActive(true);
            }
        }
    }
}