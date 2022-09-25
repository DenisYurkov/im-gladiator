using EasyButtons;
using UnityEngine;

namespace _Project.Extensions
{
    public class TextureToPng : MonoBehaviour
    {
        [SerializeField] private RenderTexture _renderTexture;
        [SerializeField] private string _path;
        [SerializeField] private string _fileName;

        private Camera _camera;
        
        private void Awake() => 
            _camera = GetComponent<Camera>();

        [Button]
        private void SaveTexture () {
            byte[] bytes = ToTexture2D(_renderTexture).EncodeToPNG();
            System.IO.File.WriteAllBytes(_path + _fileName , bytes);
        }

        [Button]
        private void SetRenderTexture() => 
            _camera.targetTexture = _renderTexture;

        private Texture2D ToTexture2D(RenderTexture rTex)
        {
            Texture2D tex = new Texture2D(rTex.width, rTex.height, TextureFormat.RGB24, false);
            RenderTexture.active = rTex;
            tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
            tex.Apply();
            return tex;
        }
    }
}
