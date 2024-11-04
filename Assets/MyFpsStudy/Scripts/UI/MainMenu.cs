using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MyFps
{
    public class MainMenu : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "Intro";
        private string sceneKey = "PlayScene";
        //private int sceneIndex = 0;
        private AudioManager audioManager;
        public GameObject mainMenuUI;
        public GameObject optionUI;
        public GameObject optionExitButton;
        public Slider bgmSlider;
        public Slider sfxSlider;
        public AudioMixer audioMixer;
        public GameObject creditUI;
        public GameObject loadButton;
        #endregion

        private void Start()
        {
            //게임 저장데이터, 저장된 옵션값 불러오기
            //LoadOptions();
            InitGameData();
            Debug.Log($"로드 SceneNumber = {PlayerStats.Instance.SceneNumber}");
            //bgmSlider.onValueChanged.AddListener(SetBgmVolume);
            //sfxSlider.onValueChanged.AddListener(SetSfxVolume);
            //씬 페이드인 효과
            fader.FromFade();

            //참조
            audioManager = AudioManager.Instance;

            //Bgm 플레이
            audioManager.PlayBgm("MenuBgm");

            //sceneIndex = PlayerPrefs.GetInt(sceneKey, 0); // 예시로 int형 데이터를 가져옴

            if (PlayerStats.Instance.SceneNumber > 0)
            {
                loadButton.SetActive(true);
                Debug.Log("데이터가 존재합니다.");
                // 데이터를 불러와 사용할 수 있습니다.
            }
            else
            {
                loadButton.SetActive(false);
                Debug.Log("데이터가 존재하지 않습니다.");
                // 필요한 경우 초기값을 설정하거나 다른 작업을 수행합니다.
            }
        }
        public void NewGame()
        {
            audioManager.Stop(audioManager.BgmSound);            
            audioManager.Play("MenuButton");

            fader.FadeTo(loadToScene);
        }

        public void LoadGame()
        {
            
            SceneManager.LoadScene(PlayerStats.Instance.SceneNumber);
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
            SaveLoad.DeleteFile();
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

        private void InitGameData()
        {
            //게임설정값, 저장된 옵션값 불러오기
            LoadOptions();

            //게임 플레이 데이터 로드
            PlayData playData = SaveLoad.LoadData();
            PlayerStats.Instance.PlayerStatInit(playData);
        }
    }
}