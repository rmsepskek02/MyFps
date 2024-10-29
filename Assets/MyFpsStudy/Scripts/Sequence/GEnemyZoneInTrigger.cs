using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{

    public class GEnemyZoneInTrigger : MonoBehaviour
    {
        public Transform gunMan;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                gunMan.GetComponent<GunEnemy>().SetState(EnemyState.E_Chase);
            }
        }
    }
}
