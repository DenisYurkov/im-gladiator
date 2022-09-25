using System;
using UnityEngine;

namespace _Project.Extensions
{
    public static class PlayerPref
    {
        public static void Init<T>(string name, T value)
        {
            if (!PlayerPrefs.HasKey(name)) 
                Set((name, value));
        }

        public static void Set<T>(params (string name, T value)[]array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (typeof(T) == typeof(int))
                {
                    var convertValue = Convert.ToInt32(array[i].value);
                    PlayerPrefs.SetInt(array[i].name, convertValue);
                }
                
                if (typeof(T) == typeof(string))
                {
                    var convertValue = Convert.ToString(array[i].value);
                    PlayerPrefs.SetString(array[i].name, convertValue);
                }
                
                if (typeof(T) == typeof(float))
                {
                    var convertValue = Convert.ToDouble(array[i].value);
                    PlayerPrefs.SetFloat(array[i].name, (float)convertValue);
                }
            }
        }

        public static T Get<T>(string name)
        {
            if (typeof(T) == typeof(int))
               return (T) Convert.ChangeType(PlayerPrefs.GetInt(name), typeof(T));

            if (typeof(T) == typeof(string))
                return (T) Convert.ChangeType(PlayerPrefs.GetString(name), typeof(T));

            if (typeof(T) == typeof(float))
                return (T) Convert.ChangeType(PlayerPrefs.GetFloat(name), typeof(T));
            
            return default;
        }

        public static void Increase<T>(string name, T value)
        {
            if (typeof(T) == typeof(int)) 
                PlayerPrefs.SetInt(name, PlayerPrefs.GetInt(name) + Convert.ToInt32(value));

            if (typeof(T) == typeof(float))
            {
                var convertValue = Convert.ToDouble(value);
                PlayerPrefs.SetFloat(name, PlayerPrefs.GetFloat(name) + (float)convertValue);
            }
        }

        public static void Decrease<T>(string name, T value)
        {
            if (typeof(T) == typeof(int)) 
                PlayerPrefs.SetInt(name, PlayerPrefs.GetInt(name) - Convert.ToInt32(value));

            if (typeof(T) == typeof(float))
            {
                var convertValue = Convert.ToDouble(value);
                PlayerPrefs.SetFloat(name, PlayerPrefs.GetFloat(name) - (float)convertValue);
            }
        }

        public static void ResetPlayerHp() => 
            Set((Constants.PlayerHp, Get<int>(Constants.PlayerMaxHp)), (Constants.LevelID, 0));
    }
}