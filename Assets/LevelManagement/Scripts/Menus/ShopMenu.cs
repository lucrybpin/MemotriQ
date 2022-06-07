using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LevelManagement.Data;
using System;
using TMPro;

namespace LevelManagement {
    public class ShopMenu :Menu<ShopMenu>
    {
        [SerializeField]
        TextMeshProUGUI pointsText;

        protected override void Awake () {
            base.Awake();
        }

        public override void BeforeLoad() {
            LoadPoints();
        }

        private void LoadPoints () {
            pointsText.text = GameObject.FindObjectOfType<Data.DataManager>().GetPoints().ToString();
        }

        private void LoadData() {
            DataManager.Instance.Load();
        }

       

        public override void OnBackPressed () {
            AudioManager.Instance.PlayButtonClick();
            base.OnBackPressed();
        }

    }
}