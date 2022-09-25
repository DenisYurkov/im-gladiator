using System.Collections;
using EasyButtons;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Core
{
    public class Loading : MonoBehaviour
    {
        [SerializeField] private GameObject _screen;

        private IEnumerator LoadSingleAsync(int sceneName)
        {
            _screen.SetActive(true);

            var first = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            yield return first.isDone;
        }
        
        private IEnumerator LoadAdditiveAsync(int sceneName)
        {
            _screen.SetActive(true);
            SceneManager.UnloadSceneAsync(sceneName, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
            
            var first = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            yield return first.isDone;
        }
        
        private IEnumerator LoadMultipleAsync(int firstScene, int secondScene)
        {
            _screen.SetActive(true);
            
            var first = SceneManager.LoadSceneAsync(firstScene, LoadSceneMode.Single);
            var second = SceneManager.LoadSceneAsync(secondScene, LoadSceneMode.Additive);
            yield return new WaitUntil(() => second.isDone);
        }
        
        [Button]
        public void LoadSingle(int sceneName) => 
            StartCoroutine(LoadSingleAsync(sceneName));
            
        [Button]
        public void LoadAdditive(int sceneName) => 
            StartCoroutine(LoadAdditiveAsync(sceneName));
        
        [Button]
        public void LoadMultiple(int firstScene, int secondScene) => 
           StartCoroutine(LoadMultipleAsync(firstScene, secondScene));
    }
}