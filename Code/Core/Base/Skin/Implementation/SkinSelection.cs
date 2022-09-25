using System;
using _Project.Extensions;

namespace _Project.Core
{
    [Serializable]
    public class SkinSelection : Skin
    {
        protected override void Buy()
        {
            Money.OnDecrease.Invoke(Cost);
            LockObject.SetActive(false);
            SkinObject.SetActive(true);
            
            PlayerPref.Set((Constants.IsSkinBuying + ID, 1));
            Select();
        }
    }
}