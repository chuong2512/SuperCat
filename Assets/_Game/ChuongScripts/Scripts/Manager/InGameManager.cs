using System;
using _Game.ChuongScripts.Scripts.Runtime;
using DG.Tweening;
using UnityEngine;

namespace ChuongCustom
{
    public class InGameManager : Singleton<InGameManager>
    {
        private void OnEnable()
        {
            OnGameStart();
        }

        private void OnGameStart()
        {
            ScoreManager.Score = 0;
            CountScore();
        }

        public void OnLose()
        {
            ScoreManager.OnUpdateHighScore();
            ScreenManager.Instance.OpenScreen(ScreenType.Lose);
            Time.timeScale = 0f;
            RoadSpeedController.Instance.SetSpeed(0f);
            transform.DOKill();
        }

        public void CountScore()
        {
            DOVirtual.DelayedCall(1f, () =>
            {
                ScoreManager.Score += 1;
            }).SetTarget(transform).SetLoops(-1);
        }

        public void Revive()
        {
            Time.timeScale = 1f;
            RoadSpeedController.Instance.SetSpeed();
            transform.DOKill();
            CountScore();
        }

        private void OnDisable()
        {
            Time.timeScale = 1f;
        }
    }
}