using UnityEngine;
using UnityEngine.UI;

namespace KID
{
    /// <summary>
    /// 音效管理器
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : MonoBehaviour
    {
        [Header("音效")]
        [SerializeField]
        private AudioClip soundHpAdd, soundHpSub, soundMpAdd, soundMpSub, soundSkill;

        private AudioSource aud;
        private Button btnSkill;

        private void Awake()
        {
            aud = GetComponent<AudioSource>();
            btnSkill = GameObject.Find("技能閃電").GetComponent<Button>();
            btnSkill.onClick.AddListener(() => PlaySound(soundSkill));
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) PlaySound(soundHpSub);
            if (Input.GetKeyDown(KeyCode.Alpha2)) PlaySound(soundHpAdd);
            if (Input.GetKeyDown(KeyCode.Alpha3)) PlaySound(soundMpSub);
            if (Input.GetKeyDown(KeyCode.Alpha4)) PlaySound(soundMpAdd);
        }

        /// <summary>
        /// 播放音效
        /// </summary>
        /// <param name="sound">音效</param>
        private void PlaySound(AudioClip sound)
        {
            aud.PlayOneShot(sound);
        }
    }
}
