using System;
using _Project.Extensions;
using UnityEngine;

namespace _Project.Core
{
    [Serializable]
    public abstract class Skin : Product
    {
        [Header("Default Skin Settings")]
        public int ID;
        public SkinChanger SkinChanger;
        
        [Header("Lock Settings")]
        [Space(10)]
        public GameObject LockObject;
        public GameObject SkinObject;

        public void Select()
        {
            if (PlayerPref.Get<int>(Constants.IsSkinBuying + ID) == 1) 
                SkinChanger.SelectSkin(ID);
        }
        
        protected abstract void Buy();
        
        public void TryBuying()
        {
            if (IsEnoughMoney() && PlayerPref.Get<int>(Constants.IsSkinBuying + ID) != 1) 
                Buy();
        }
    }
}