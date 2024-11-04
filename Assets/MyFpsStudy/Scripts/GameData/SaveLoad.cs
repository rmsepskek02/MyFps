using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace MyFps
{
    // ���� ������ ���� ����/�������� ���� - ����ȭ ����
    public static class SaveLoad
    {
        private static string fileName = "/playData.arr";
        public static void SaveData()
        {
            // �����̸�, ��� ����
            string path = Application.persistentDataPath + fileName;
            Debug.Log(path);

            // ������ �����͸� ����ȭ �غ�
            BinaryFormatter formatter = new BinaryFormatter();

            // ���� ���� - �����ϸ� ���� ��������, �������� ������ ���� ���� ����
            FileStream fs = new FileStream(path, FileMode.Create);

            // ������ ������ ����
            PlayData playData = new PlayData();
            Debug.Log($"Save SceneNumber= {playData.sceneNumber}");

            // �غ��� �����͸� ����ȭ ����
            formatter.Serialize(fs, playData);

            // ���� Ŭ����
            fs.Close();
        }
        public static PlayData LoadData()
        {
            PlayData playData;
            string path = Application.persistentDataPath + fileName;
            Debug.Log($"LOAD={File.Exists(path)}");

            // �����̸�, ��� ����

            // ������ ��ο� ����� ������ �ִ��� ������ üũ
            if(File.Exists(path) == true)
            {
                // ������ ����
                // ������ �����͸� ����ȭ �غ�
                BinaryFormatter formmater = new BinaryFormatter();

                // ���� ���� - �����ϸ� ���� ��������, �������� ������ ���� ���� ����
                FileStream fs = new FileStream(path, FileMode.Open);


                // ���Ͽ� ����ȭ�� ����� �����͸� ������ȭ�ؼ� �����´�
                playData = formmater.Deserialize(fs) as PlayData;
                Debug.Log($"Save SceneNumber= {playData.sceneNumber}");

                // ���� Ŭ����
                fs.Close();
            }
            else
            {
                // ������ ����
                Debug.Log("Not Found Load File");
                playData = null;
            }

            return playData;
        }
        public static void DeleteFile()
        {
            string path = Application.persistentDataPath + fileName;
            File.Delete(path);
        }
    }
}
