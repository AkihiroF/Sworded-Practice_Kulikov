using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Scripts.UI
{
    public class PersonUIComponent : MonoBehaviour
    {
        [SerializeField] private bool botface;
        [SerializeField] private Text DamageText;
        [SerializeField] private Text XPText;
        [SerializeField] private GameObject XPFX;
        [SerializeField] private GameObject Crown;
        [SerializeField] private GameObject NewLevel;
        [SerializeField] private GameObject DamageVignette;
        [SerializeField] private GameObject UIobj;
        [SerializeField] private Image LevelLine;
        [SerializeField] private Text LevelText;
        [SerializeField] private Text nameText;
        [SerializeField] private string Name;
        [SerializeField] private Text healtyText;
        [SerializeField] private Transform healtyLine;
        [SerializeField] private Transform damageLine;
        [Inject]private RectTransform HolderStats;
        [SerializeField] private RectTransform UI_Element;
        [Inject]private Camera Cam;
        [Inject]private GameUI gameUI;
        [Inject]private PlayerIndex player;
        float startsize;
        
        private void Start()
        {
            if (!botface) nameText.text = "Player" + Random.Range(1000, 10000);
            if (!botface) nameText.text = PlayerPrefs.GetString("Name");
            Name = nameText.text;
            UI_Element = GetComponent<RectTransform>();
            transform.parent = HolderStats;
            startsize = Cam.fieldOfView;
        }
        
        private void Update()
        {
            XPFX.transform.rotation = Quaternion.identity;
            Vector2 ViewportPosition = Cam.WorldToViewportPoint(player.transform.position);
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
        
        

        public void OnDeath()
        {
            UIobj.SetActive(false);
        }
    }
}