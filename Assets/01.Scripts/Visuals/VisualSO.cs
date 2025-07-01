using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace ChipmunkKingdoms.Scripts
{
    [CreateAssetMenu(fileName = "new Visual SO", menuName = "SO/Visual/Visual SO", order = 0)]
    public class VisualSO : ScriptableObject
    {
        [SerializeField] private SerializedDictionary<VisualChildTypeSO, BaseVisualChildSO> visualChildren = new();

        public BaseVisualChildSO GetVisualChild(VisualChildTypeSO type)
        {
            if (visualChildren.TryGetValue(type, out var visualChild))
            {
                return visualChild;
            }

            Debug.LogWarning($"Visual child of type {type.name} not found in {name}");
            return null;
        }
    }
}