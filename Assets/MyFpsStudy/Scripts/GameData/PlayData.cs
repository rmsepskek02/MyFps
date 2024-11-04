using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    // ���Ͽ� ������ ���� �÷��� ������ ���
    [System.Serializable]
    public class PlayData 
    {
        public int sceneNumber;
        public int bulletCount;
        public bool hasGun;

        public PlayData()
        {
            sceneNumber = PlayerStats.Instance.SceneNumber;
            bulletCount = PlayerStats.Instance.BulletCount;
            hasGun = PlayerStats.Instance.HasGun;
        }
    }
}
