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
        private int sceneNumber;
        public int SceneNumber
        {
            get { return sceneNumber; }
            set { sceneNumber = value; }
        }

        private int nowSceneNumber;
        public int NowSceneNumber
        {
            get { return nowSceneNumber; }
            set { nowSceneNumber = value; }
        }

        [SerializeField] private int bulletCount;
        private bool[] puzzleKeys;
        public int BulletCount
        {
            get { return bulletCount; }
            set { bulletCount = value; }
        }
        private bool hasGun;
        public bool HasGun
        {
            get { return hasGun; }
            private set { hasGun = value; }
        }
        // Start is called before the first frame update
        void Start()
        {
            //BulletCount = 0;
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
        public bool SetHasGun(bool value)
        {
            HasGun = value;
            return value;
        }

        public void PlayerStatInit(PlayData playData)
        {
            if(playData != null)
            {
                SceneNumber = playData.sceneNumber;
                BulletCount = playData.bulletCount;
                hasGun = playData.hasGun;
            }
            else // ¿˙¿Âµ» µ•¿Ã≈Õ∞° æ¯¿ª∂ß
            {
                sceneNumber = 0;
                bulletCount = 0;
                hasGun = false;
            }
        }
    }
}
