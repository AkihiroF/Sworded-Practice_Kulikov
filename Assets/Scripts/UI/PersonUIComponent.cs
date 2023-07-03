using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Scripts.UI
{
    public class PersonUIComponent : MonoBehaviour
    {
        [SerializeField] private Text DamageText;
        [SerializeField] private Text XPText;
        [SerializeField] private GameObject XPFX;
        [SerializeField] private GameObject NewLevel;
        [SerializeField] private GameObject UIobj;
        [SerializeField] private Image LevelLine;
        [SerializeField] private Text LevelText;
        [SerializeField] private Text nameText;
        [SerializeField] private Text healtyText;
        [SerializeField] private Transform healtyLine;
        [SerializeField] private Transform damageLine;
        [SerializeField] private Transform body;
        [Inject]private RectTransform HolderStats;
        [SerializeField] private RectTransform UI_Element;
        [Inject]private Camera Cam;
        [Inject]private GameUI gameUI;
        private bool _isBot;
        float startsize;
        
        private void Start()
        {
            transform.parent = HolderStats;
            startsize = Cam.fieldOfView;
        }

        public void UpdateStats(string name, bool isBot)
        {
            nameText.text = name;
            _isBot = isBot;
        }
        
        private void Update()
        {
            XPFX.transform.rotation = Quaternion.identity;
            Vector2 ViewportPosition = Cam.WorldToViewportPoint(body.position);
            Vector2 WorldObject_ScreenPosition = new Vector2(
                ((ViewportPosition.x * HolderStats.sizeDelta.x) - (HolderStats.sizeDelta.x * 0.5f)),
                ((ViewportPosition.y * HolderStats.sizeDelta.y) - (HolderStats.sizeDelta.y * 0.5f)));
            UI_Element.localScale = Vector2.one * startsize / Cam.fieldOfView;
            //now you can set the position of the ui element
            UI_Element.anchoredPosition =Vector2.Lerp(UI_Element.anchoredPosition, WorldObject_ScreenPosition, 8*Time.deltaTime);
            damageLine.localScale = Vector3.up + Vector3.right * Mathf.MoveTowards(damageLine.localScale.x, healtyLine.localScale.x, Time.deltaTime/3);
        }

        public void UpdateAddHp(int damage, int maxHp, float hp)
        {
            if (damage < 0) 
            {
                DamageText.text=(-damage).ToString(); 
                DamageText.fontSize=Mathf.Clamp(-damage * 160 / maxHp, 50,85);
                if (-damage > maxHp / 4)
                {
                    DamageText.color = Color.red;
                }
                else DamageText.color = Color.white;
                DamageText.transform.localPosition=Vector3.right * Random.Range(-50, 50) + Vector3.forward *Random.Range(-50, 50);
                
                healtyText.text = hp.ToString();
                healtyLine.localScale = Vector3.up + Vector3.right * (hp / maxHp);
            }
        }

        public void UpdateAddPoint(int addedPoints,float endFill, int level)
        {
            if (addedPoints > 0)
            {
                if (!_isBot)
                {
                    XPText.text = "+" + addedPoints + "xp";
                    XPText.GetComponent<Animation>().Stop();
                    XPText.GetComponent<Animation>().Play();
                }
                XPFX.SetActive(true);
                NewLevel.SetActive(true);
                NewLevel.transform.localScale = Vector3.one;
            }
            LevelLine.fillAmount = endFill;
            LevelText.text = (level).ToString();
        }

        public void UpdateLevel()
        {
            NewLevel.transform.localScale = Vector3.one*1.5f;
            LevelLine.fillAmount = 0;
        }
        public void OnDeath()
        {
            UIobj.SetActive(false);
        }
        public class Factory : PlaceholderFactory<PersonUIComponent>
        {
        }
    }
}