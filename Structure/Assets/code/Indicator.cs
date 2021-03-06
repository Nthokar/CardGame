using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Assets.code
{
    public class Indicator :  MonoBehaviour
    {
        public Image scaleBar;
        public Image changeIndicator;
        public Color DecreaseColor;
        public Color IncreaseColor;

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

        public IEnumerator ChangeIndicatorAnimation()
        {
            for(float i = 0; i < 0.4; i +=Time.deltaTime)
            {
                changeIndicator.color = Color.Lerp(changeIndicator.color, Color.white, Time.deltaTime);
                yield return null;
            }
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
