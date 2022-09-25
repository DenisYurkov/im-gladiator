using UnityEngine;

namespace _Project.Core
{
    public class DiceRay : MonoBehaviour
    {
        public int Multiplier = 1;
        
        [SerializeField] private Vector3 _rayDirection;

        private const int CheckLayer = 6;
        private DiceSide _diceSide;
    
        public int GetNumber()
        {
            Ray ray = new Ray(transform.position, _rayDirection);
            bool raycast = Physics.Raycast(ray, out var hit, 25f, 1 << CheckLayer);

            if (raycast && hit.collider.TryGetComponent(out DiceSide diceSide)) 
                _diceSide = diceSide;
            return _diceSide.Value * Multiplier;
        }

        public void ResetMultiplier() => 
            Multiplier = 1;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(transform.position, _rayDirection);
        }
    }
}
