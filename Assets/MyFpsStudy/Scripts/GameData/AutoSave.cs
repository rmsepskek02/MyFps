using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyFps
{
    // �÷��̾��� �����ϸ� �ڵ����� ���ӵ����� ����
    public class AutoSave : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            AutoSaveData();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void AutoSaveData()
        {
            //int sceneNumber = PlayerPrefs.GetInt("PlayerCene", 0);
            int sceneNumber = PlayerStats.Instance.SceneNumber;
            int playScene = SceneManager.GetActiveScene().buildIndex;
            if (playScene > sceneNumber)
            {
                Debug.Log("Save");
                Debug.Log($"SaveSN={sceneNumber}");
                Debug.Log($"SavePC={playScene}");
                //PlayerPrefs.SetInt("PlayScene", playScene);
                PlayerStats.Instance.SceneNumber = playScene;
                SaveLoad.SaveData();
            }
        }
    }
}
