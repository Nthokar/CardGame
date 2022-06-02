using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Assets.code
{
    public class Indicator :  MonoBehaviour
    {
        Image scaleBar;
        [SerializeField]
        Color DecreaseColor;
        [SerializeField]
        Color IncreaseColor;
        public float maxPoints = 10f;
        
        [SerializeField]
        private float pastPoints = 5;
        private float _currentPoints = 5;
        public float currentPoints
        { 
            get
            {
                return _currentPoints;
            }

            set
            {
                _currentPoints = value;
                if (value == pastPoints)
                {
                    scaleBar.fillAmount = currentPoints/maxPoints;
                }
                if (value > pastPoints)
                {
                    StopAllCoroutines();
                    StartCoroutine(IncreaseAnimation());
                }
                else
                { 
                    if (value < pastPoints)
                    {
                        StopAllCoroutines();
                        StartCoroutine(DecreaseAnimation());
                    }
                 }
            }
        }

        public void Awake()
        {
            scaleBar = GetComponentInChildren<Image>();
            //scaleBar.fillAmount = currentPoints / maxPoints;
        }

        IEnumerator DecreaseAnimation()
        {
            var halfDelta = (pastPoints - currentPoints) / 4;
            while (pastPoints > currentPoints)
            {
                var speed = Time.deltaTime * 3;
                pastPoints -= speed;
                scaleBar.fillAmount = pastPoints / maxPoints;
                if (pastPoints > currentPoints + halfDelta)
                    scaleBar.color = Color.Lerp(scaleBar.color, DecreaseColor, speed);
                else
                    scaleBar.color = Color.Lerp(scaleBar.color, Color.white, speed * 5);
                yield return null;
            }
                scaleBar.color = Color.white;
        }

        IEnumerator IncreaseAnimation()
        {
            var halfDelta = (currentPoints - pastPoints) / 4;
            while (pastPoints < currentPoints)
            {
                var speed = Time.deltaTime * 3;
                pastPoints += speed;
                scaleBar.fillAmount = pastPoints / maxPoints;
                if (pastPoints < currentPoints - halfDelta)
                    scaleBar.color = Color.Lerp(scaleBar.color, IncreaseColor, speed);
                else
                    scaleBar.color = Color.Lerp(scaleBar.color, Color.white, speed * 5);
                yield return null;
            }
            scaleBar.color = Color.white;
        }

        public void PlayDecreaseAnimation()
        {
            StartCoroutine(DecreaseAnimation());
        }

        public void PlayIncreaseAnimation()
        {
            StartCoroutine(IncreaseAnimation());
        }
    }
}
