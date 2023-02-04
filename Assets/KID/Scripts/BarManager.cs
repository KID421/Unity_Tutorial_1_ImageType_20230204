using UnityEngine;
using UnityEngine.UI;

namespace KID
{
    /// <summary>
    /// 吧條管理器
    /// </summary>
    public class BarManager : MonoBehaviour
    {
        [SerializeField, Header("血量圖片")]
        private Image imgHp;
        [SerializeField, Header("血量"), Range(0, 500)]
        private float hp = 100;

        private float hpMax;

        [SerializeField, Header("魔力圖片")]
        private Image imgMp;
        [SerializeField, Header("魔力"), Range(0, 500)]
        private float mp = 300;

        private float mpMax;

        private void Awake()
        {
            hpMax = hp;
            mpMax = mp;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) UpdateHp(-30);
            if (Input.GetKeyDown(KeyCode.Alpha2)) UpdateHp(+30);

            if (Input.GetKeyDown(KeyCode.Alpha3)) UpdateMp(-30);
            if (Input.GetKeyDown(KeyCode.Alpha4)) UpdateMp(+30);
        }

        /// <summary>
        /// 更新血量
        /// </summary>
        /// <param name="increase">要添加的血量</param>
        private void UpdateHp(float increase)
        {
            hp += increase;
            hp = Mathf.Clamp(hp, 0, hpMax);
            imgHp.fillAmount = hp / hpMax;
        }

        /// <summary>
        /// 更新血量
        /// </summary>
        /// <param name="increase">要添加的魔力</param>
        private void UpdateMp(float increase)
        {
            mp += increase;
            mp = Mathf.Clamp(mp, 0, mpMax);
            imgMp.fillAmount = mp / mpMax;
        }
    }
}
