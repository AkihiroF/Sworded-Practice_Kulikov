using System;
using Cinemachine;
using Code.Events;
using Scripts.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Scripts.UI
{
    public class SurvivalMenuUIComponent : MonoBehaviour
    {

        [SerializeField] private Text timer;
        
        [Header("EndGame")]
        [SerializeField] private GameObject EndMenu;
        [SerializeField] private GameObject Whistle;

        private CinemachineBasicMultiChannelPerlin perlin;
        private float shakeTimer;

        private void Awake()
        {
            Signals.Get<OnStartGame>().AddListener(StartGame);
            Signals.Get<OnStopGame>().AddListener(FinishGame);
        }

        private void FinishGame()
        {
            Signals.Get<OnStartGame>().RemoveListener(StartGame);
            Signals.Get<OnStopGame>().RemoveListener(FinishGame);
            
            Whistle.SetActive(true);
            EndMenu.SetActive(true);
        }

        private void StartGame()
        {
            Whistle.SetActive(true);
        }

        private void Update()
        {
            shakeTimer += Time.deltaTime;
            timer.text = $"{Mathf.RoundToInt(shakeTimer)}";
        }
    }
}