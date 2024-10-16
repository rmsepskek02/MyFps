using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyFps
{
    public class GameOverUI : MonoBehaviour
    {
        public Button retryButton;
        public Button quitButton;
        public SceneFader fader;
        [SerializeField] private string loadToScene = "PlaySceneStudy";
        // Start is called before the first frame update
        void Start()
        {
            fader.FromFade();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnClickRetryButton()
        {
            fader.FadeTo(loadToScene);
        }
        public void OnClickQuitButton()
        {

        }
    }
}
