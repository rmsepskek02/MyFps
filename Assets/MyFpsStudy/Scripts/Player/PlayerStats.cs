using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFps
{
    //���� ������ ȹ�� ����
    public enum PuzzleKey
    {
        ROOM01_KEY,
        MAX_KEY             //���� ������ ����
    }
    public class PlayerStats : Singleton<PlayerStats>
    {
        private int bulletCount;
        public TextMeshProUGUI bulletText;
        private bool[] puzzleKeys;
        public int BulletCount
        {
            get { return bulletCount; }
            private set { bulletCount = value; }
        }
        // Start is called before the first frame update
        void Start()
        {
            BulletCount = 0;
            DontDestroyOnLoad(this.gameObject);
        }

        // Update is called once per frame
        void Update()
        {
            bulletText.text = $"{BulletCount}";
        }
        public void SetBullet(int count)
        {
            BulletCount = count;
        }
        public bool UseBullet(int count)
        {
            if(BulletCount < count)
            {
                return false;
            }
            BulletCount -= count;
            return true;
        }
        public void DecreaseBullet(int count = 1)
        {
            BulletCount -= count;
        }
        public void IncreaseBullet()
        {
            BulletCount++;
        }
        //���� ������ ȹ��
        public void AcquirePuzzleItem(PuzzleKey key)
        {
            puzzleKeys[(int)key] = true;
        }

        //���� �������� ���� ����
        public bool HasPuzzleItem(PuzzleKey key)
        {
            return puzzleKeys[(int)key];
        }
    }
}
