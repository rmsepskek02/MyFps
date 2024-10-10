using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFps
{
    public class BFirstTrigger : MonoBehaviour
    {
        public TextMeshProUGUI textBox;
        public GameObject arrow;
        private string sequence = "Looks like a weapon on that table.";
        private bool isFirst = true;
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
            FirstPersonController fpc = other.gameObject.GetComponent< FirstPersonController >();
            if (fpc != null)
            {
                StartCoroutine(PlaySequence(other.gameObject));
            }
        }
        IEnumerator PlaySequence(GameObject other)
        {
            if (isFirst)
            {
                other.SetActive(false);
                textBox.gameObject.SetActive(true);
                textBox.text = sequence;
                yield return new WaitForSeconds(2f);
                arrow.SetActive(true);
                yield return new WaitForSeconds(1f);
                textBox.gameObject.SetActive(false);
                textBox.text = "";
                other.SetActive(true);
                isFirst = false;
            }
            //transform.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
