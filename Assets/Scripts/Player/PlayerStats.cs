using System.Collections;
using System.Collections.Generic;
using Scripts.Audio;
using Scripts.Enemy;
using Scripts.Feedback;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [Header("Stats")]
    public bool player;
    public bool botface;
    public float Damage=1;
    public int Level=1;
    public int Points;
    [Header("Tech")] 
    [SerializeField] private EnemyHealth health;

    [SerializeField] private PersonUIComponent personUIComponent;
    [SerializeField] private PersonFeedback feedback;
    [SerializeField] private GameObject crown;
    public GameUI gameUI;
    public BalanceSheet balance;
    public int lastHit;
    bool vibro;
    public float damagemod = 1;
    public bool vampire;
    private string _name;

    public string Name => _name;
    public GameObject Crown => crown;

    private void Start()
    {
        if (botface) _name = "Player" + Random.Range(1000, 10000);
        if (!botface) _name = PlayerPrefs.GetString("Name");
        if (!player)
        {
            if (PlayerPrefs.GetInt("Internet") == 1) botface = false;
            else botface = true;
        }
        AddHP(0);
        AddPoints(0);
        if (player&&PlayerPrefs.GetInt("Vibro") == 0) vibro = true;
        personUIComponent.UpdateStats(_name, botface);
    }

    public void AddHP(int hp)
    {
        health.AddHP(hp);
    }
    public void GiveXp(int p)
    {
        int d = (int)(Points - 5 * balance.XPcoeff * (Level - 1) * (Level + balance.XPcoeff - 1));
        AddPoints(-d);
        if (p!=0)
            gameUI.Stats[p].AddPoints((int)(d*1.5f + 25));
        else
            gameUI.Stats[p].AddPoints(d + 25);

    }
    public void AddPoints(int points)
    {
        Points += points;
        float pointsPL = 5 * balance.XPcoeff * (Level-1) * (Level-1 + balance.XPcoeff);
        if (Points > (5 * balance.XPcoeff * (Level) * (Level + balance.XPcoeff)))
        {
            if (!botface) feedback.FeedbackAddLevel();
            AddLevel(); 
        }
        else if (!botface) feedback.FeedbackAddPoint();

        AddHP((int)(10 * Mathf.Pow((float)Level, balance.HPcoeff)));
        if (Level>1) gameUI.FindKing();
        if (Points > 1) gameUI.checkPlayers();
        var endFill = 0.81f * ((Points- pointsPL) / ((5 * balance.XPcoeff * (Level) * (Level + balance.XPcoeff)) - pointsPL));
        personUIComponent.UpdateAddPoint(points,endFill,Level);
    }
    private void AddLevel()
    {
        Level++;
        if (Points > (5 * balance.XPcoeff * (Level) * (Level + balance.XPcoeff))) AddLevel();
        else
        {
            health.UpgradeMaxHp(Level);
        }
        personUIComponent.UpdateLevel();
    }
    // IEnumerator Respawn()
    // {
    //     yield return new WaitForSeconds(1);
    //     Player.position = Vector3.up * 3 + Vector3.right * Random.Range(-balance.MapSize, balance.MapSize) + Vector3.forward * Random.Range(-balance.MapSize, balance.MapSize);
    //     if (player) gameUI.ShakeCam(0, 0);
    //     yield return new WaitForSeconds(1);
    //     Player.gameObject.SetActive(true);
    //     UIobj.SetActive(true);
    //     Instantiate(RespawnFX, Player.position, Quaternion.identity);
    // }
}
