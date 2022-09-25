using System;

namespace _Project.Core
{
    [Serializable]
    public abstract class Boost : Product
    {
        protected abstract void Apply();

        public void TryApply()
        {
            if (IsEnoughMoney())
                Apply();
        }
    }
}