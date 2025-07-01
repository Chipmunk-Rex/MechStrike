using UnityEngine;

namespace ChipmunkKingdoms.Scripts
{
    public abstract class BaseVisualChildSO : ScriptableObject
    {
        public abstract Mesh Mesh { get; }
        public abstract Material Material { get; }
    }
}