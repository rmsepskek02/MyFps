using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    // 파일에 저장할 게임 플레이 데이터 목록
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
