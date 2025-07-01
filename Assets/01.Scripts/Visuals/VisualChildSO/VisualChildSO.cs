using UnityEngine;
using UnityEngine.Serialization;

namespace ChipmunkKingdoms.Scripts
{
    [CreateAssetMenu(fileName = "VisualChildSO", menuName = "SO/Visual/VisualChild SO")]
    public class VisualChildSO : BaseVisualChildSO
    {
        [SerializeField] private Mesh mesh;
        public override Mesh Mesh => mesh;
        [SerializeField] private Material material;
        public override Material Material => material;
    }
}