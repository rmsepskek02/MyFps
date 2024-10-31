using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{

    public class CreditUI : MonoBehaviour
    {
        public GameObject mainMenu;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                HideCredits();
            }
        }

        private void HideCredits()
        {
            mainMenu.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
