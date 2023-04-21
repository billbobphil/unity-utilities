using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Utilities
{
    public class Timer : MonoBehaviour
    {
        public enum TimerTypes {
            CountUp,
            CountDown,
            InfiniteCountUp
        }

        public enum TimerDisplayTypes
        {
            Seconds,
            Minutes,
            Hours,
            Days
        }

        public TimerTypes timerType;
        public TimerDisplayTypes timerDisplayType;
        private float _time;
        public float timerDurationSeconds = 180f;
        private bool _isRunning;
        public TextMeshProUGUI daysText;
        public TextMeshProUGUI hoursText;
        public TextMeshProUGUI minutesText;
        public TextMeshProUGUI secondsText;
        public bool displayLeadingZeroes = true;

        private void Start()
        {
            ResetTimer();
        }

        public void StartTimer()
        {
            _isRunning = true;
        }

        public void SetTime(float time)
        {
            _time = time;
        }

        public float GetTime()
        {
            return _time;
        }

        public void PauseTimer()
        {
            _isRunning = false;
        }

        public void StopTimer()
        {
            _isRunning = false;
            ResetTimer();
        }

        private void ResetTimer()
        {
            switch (timerType)
            {
                case TimerTypes.CountDown:
                    _time = timerDurationSeconds;
                    break;
                case TimerTypes.CountUp:
                case TimerTypes.InfiniteCountUp:
                    _time = 0;
                    break;
            }
        }

        private void Update()
        {
            if (!_isRunning) return;
            
            if (timerType == TimerTypes.CountDown && _time > 0)
            {
                _time -= Time.deltaTime;
            }
            else if(timerType == TimerTypes.CountUp && _time < timerDurationSeconds)
            {
                _time += Time.deltaTime;
            }
            else if(timerType == TimerTypes.InfiniteCountUp)
            {
                _time += Time.deltaTime;
            }
            
            UpdateTimerText();
        }

        public void UpdateTimerText()
        {
            if (_time <= 0)
            {
                _time = 0;
            }

            switch (timerDisplayType)
            {
                case TimerDisplayTypes.Days:
                {
                    float days = _time / 86400;
                    float remaining = _time % 86400;
                    float hours = remaining / 3600;
                    remaining %= 3600;
                    float minutes = remaining / 60;
                    remaining %= 60;
                
                    UpdateText(daysText, days);
                    UpdateText(hoursText, hours);
                    UpdateText(minutesText, minutes);
                    UpdateText(secondsText, remaining);
                    break;
                }
                case TimerDisplayTypes.Hours:
                {
                    float hours = _time / 3600;
                    float remaining = _time % 3600;
                    float minutes = remaining / 60;
                    remaining %= 60;
                
                    UpdateText(hoursText, hours);
                    UpdateText(minutesText, minutes);
                    UpdateText(secondsText, remaining);
                    break;
                }
                case TimerDisplayTypes.Minutes:
                {
                    float minutes = _time / 60;
                    float remaining = _time % 60;
                
                    UpdateText(minutesText, minutes);
                    UpdateText(secondsText, remaining);
                    break;
                }
                case TimerDisplayTypes.Seconds:
                default:
                {
                    float seconds = _time;
                    UpdateText(secondsText, seconds);
                    break;
                }
            }
        }

        private void UpdateText(TextMeshProUGUI textElement, float value)
        {
            int newValue = (int)value;
            string format = "00";
            if (!displayLeadingZeroes)
            {
                format = "0";
            }
            textElement.text = $"{newValue.ToString(format)}";
        }
    }
}