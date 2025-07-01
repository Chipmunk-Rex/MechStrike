using UnityEngine;

namespace ChipmunkKingdoms.Scripts
{
    [CreateAssetMenu(fileName = "RandomVisualChildSO", menuName = "SO/Visual/RandomVisualChild SO")]
    public class RandomVisualChildSO : BaseVisualChildSO
    {
        [SerializeField] private Mesh[] meshes;
        public override Mesh Mesh => meshes.Length > 0 ? meshes[Random.Range(0, meshes.Length)] : null;
        [SerializeField] private Material[] materials;
        public override Material Material => materials.Length > 0 ? materials[Random.Range(0, materials.Length)] : null;
    }
}