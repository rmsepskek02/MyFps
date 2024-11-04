using MyFps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    public GameObject ammoUI;
    public GameObject weapon;
    public GameObject bulletUI;
    public Transform bulletsUI;
    private bool isLoad;
    // Start is called before the first frame update
    void Start()
    {
        isLoad = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(weapon.activeSelf)
            ShowAmmoUI();
    }

    private void ShowAmmoUI()
    {
        ammoUI.SetActive(true);

        if (isLoad)
        {
            foreach (Transform child in bulletsUI)
            {
                Destroy(child.gameObject);
            }
            for (var i = 0; i < PlayerStats.Instance.BulletCount; i++)
            {
                Instantiate(bulletUI, bulletsUI);
            }
            isLoad = false;
        }
    }
}
