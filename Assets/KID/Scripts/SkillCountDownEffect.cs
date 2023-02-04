using UnityEngine;
using UnityEngine.UI;

namespace KID
{
    /// <summary>
    /// 技能冷卻效果
    /// </summary>
    public class SkillCountDownEffect : MonoBehaviour
    {
        [SerializeField, Header("技能冷卻時間"), Range(0, 10)]
        private float cdSkill = 3;
        [SerializeField, Header("技能按鈕")]
        private Button btnSkill;
        [SerializeField, Header("冷卻圖示")]
        private Image imgCountDown;

        private float cdTimer;

        private void Awake()
        {
            btnSkill.onClick.AddListener(ClickSkillButton);     // 技能按鈕點擊後執行【點擊技能方法】
        }

        private void Update()
        {
            CountDown();
        }

        /// <summary>
        /// 點擊技能按鈕
        /// </summary>
        private void ClickSkillButton()
        {
            cdTimer = cdSkill;                                  // 冷卻計時器 等於 技能冷卻時間
        }

        /// <summary>
        /// 冷卻
        /// </summary>
        private void CountDown()
        {
            if (cdTimer > 0)                                    // 如果 冷卻計時器 大於 0
            {
                cdTimer -= Time.deltaTime;                      // 冷卻計時器 扣除經過時間
                imgCountDown.fillAmount = cdTimer / cdSkill;    // 更新 冷卻圖示
                imgCountDown.raycastTarget = true;              // 開啟 冷卻圖示 遮擋 (不讓玩家選取技能)
            }
            else
            {
                imgCountDown.raycastTarget = false;             // 否則 冷卻計時器 小於等於 0 就 關閉 冷卻圖示 遮擋 (讓玩家可再次選取技能)
            }
        }
    }
}
