using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.code
{
    public class Theory : MonoBehaviour
    {
        public string Title;
        public string Description;

        public Text lineTitle;
        public Text mainTitle;
        public Text mainDescription;

        public void Awake()
        {
            lineTitle.text = Title;
        }

        public void UpdateTheoryWindow()
        {
            mainTitle.text = Title;
            mainDescription.text = Description;
        }
    }
}
