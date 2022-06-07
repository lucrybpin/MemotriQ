using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement
{
    public class CreditsMenu : Menu<CreditsMenu>
    {

        public override void OnBackPressed () {
            AudioManager.Instance.PlayButtonClick();
            base.OnBackPressed();
        }

        public void OnDonatePressed() {
            AudioManager.Instance.PlayButtonClick();
            //TODO
        }

        public void OnWatchAdPressed(string placement) {
            AudioManager.Instance.PlayButtonClick();
            AdManager.Instance.ShowRewardedAd(placement);
        }
    }
}
