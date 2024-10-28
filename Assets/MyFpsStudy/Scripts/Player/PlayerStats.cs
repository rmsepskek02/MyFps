using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFps
{
    //∆€¡Ò æ∆¿Ã≈€ »πµÊ ø©∫Œ
    public enum PuzzleKey
    {
        ROOM01_KEY,
        LEFTEYE_KEY,
        RIGHTEYE_KEY,
        MAX_KEY             //∆€¡Ò æ∆¿Ã≈€ ∞πºˆ
    }
    public class PlayerStats : Singleton<PlayerStats>
    {
        private int bulletCount;
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
            puzzleKeys = new bool[(int)PuzzleKey.MAX_KEY];
        }

        // Update is called once per frame
        void Update()
        {

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
        //∆€¡Ò æ∆¿Ã≈€ »πµÊ
        public void AcquirePuzzleItem(PuzzleKey key)
        {
            puzzleKeys[(int)key] = true;
        }

        //∆€¡Ò æ∆¿Ã≈€¿ª º“¡ˆ ø©∫Œ
        public bool HasPuzzleItem(PuzzleKey key)
        {
            return puzzleKeys[(int)key];
        }
    }
}
