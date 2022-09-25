using System;

namespace _Project.Extensions
{
    public static class Random 
    {
        public static int GetNumber(int minValue, int maxValue)
        {
            UnityEngine.Random.InitState(DateTime.Now.Millisecond);
            return UnityEngine.Random.Range(minValue, maxValue);
        }
    }
}