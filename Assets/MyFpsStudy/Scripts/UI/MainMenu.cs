using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace MyFps
{
    public class MainMenu : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainScene01";

        private AudioManager audioManager;
        public GameObject mainMenuUI;
        public GameObject optionUI;
        public GameObject optionExitButton;
        public Slider bgmSlider;
        public Slider sfxSlider;
        public AudioMixer audioMixer;
        public GameObject creditUI;
        #endregion

        private void Start()
        {
            //bgmSlider.onValueChanged.AddListener(SetBgmVolume);
            //sfxSlider.onValueChanged.AddListener(SetSfxVolume);
            //게임 저장데이터, 저장된 옵션값 불러오기
            LoadOptions();
            //씬 페이드인 효과
            fader.FromFade();

            //참조
            audioManager = AudioManager.Instance;

            //Bgm 플레이
            audioManager.PlayBgm("MenuBgm");
        }

        public void NewGame()
        {
            audioManager.Stop(audioManager.BgmSound);            
            audioManager.Play("MenuButton");

            fader.FadeTo(loadToScene);
        }

        public void LoadGame()
        {
            Debug.Log("Goto LoadGame");
        }

        public void Options()
        {
            audioManager.Play("MenuButton");

            Debug.Log("Show Options");
            optionUI.SetActive(true);
            mainMenuUI.SetActive(false);
        }

        public void Credits()
        {
            Debug.Log("Show Credits");
            mainMenuUI.SetActive(false);
            creditUI.SetActive(true);
        }

        public void QuitGame()
        {
            Debug.Log("Quit Game");
            Application.Quit();
        }

        public void ExitOption()
        {
            SaveOptions();
            optionUI.SetActive(false);
            mainMenuUI.SetActive(true);
        }

        // AudioMix Bgm -40~0
        public void SetBgmVolume(float value)
        {
            audioMixer.SetFloat("BgmVolume", value);
            Debug.Log(value);
        }

        public void SetSfxVolume(float value)
        {
            audioMixer.SetFloat("SfxVolume", value);
        }

        private void SaveOptions()
        {
            PlayerPrefs.SetFloat("BgmVolume", bgmSlider.value);
            PlayerPrefs.SetFloat("SfxVolume", sfxSlider.value);
        }
        private void LoadOptions()
        {
            float bgmVolume = PlayerPrefs.GetFloat("BgmVolume", 0);
            float sfxVolume = PlayerPrefs.GetFloat("SfxVolume", 0);
            SetBgmVolume(bgmVolume);
            bgmSlider.value = bgmVolume;
            SetSfxVolume(sfxVolume);
            sfxSlider.value = sfxVolume;
        }
    }
}