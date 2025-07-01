using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace ChipmunkKingdoms.Scripts
{
    public class VisualChildBehavior : MonoBehaviour
    {
        [SerializeField] private VisualChildTypeSO visualChildType;

        [SerializeField] private BaseVisualChildSO currentVisualSO;

        public VisualChildTypeSO VisualChildType => visualChildType;

        [SerializeField] MeshRenderer meshRenderer;
        [SerializeField] MeshFilter meshFilter;
        [SerializeField] SkinnedMeshRenderer skinnedMeshRenderer;

        private void Awake()
        {
            if (currentVisualSO != null)
                SetVisual(currentVisualSO);
        }

        private void Reset()
        {
            meshRenderer = GetComponent<MeshRenderer>();
            meshFilter = GetComponent<MeshFilter>();
            skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        }

        public void SetVisual(BaseVisualChildSO visualChildSo)
        {
            if (visualChildSo == null)
            {
                Debug.LogWarning("VisualChildSO is null, cannot set visual type.");
                return;
            }

            currentVisualSO = visualChildSo;

            if (meshRenderer != null)
            {
                meshRenderer.material = visualChildSo.Material ?? meshRenderer.material;
            }

            if (meshFilter != null)
            {
                meshFilter.mesh = visualChildSo.Mesh ?? meshFilter.mesh;
            }

            if (skinnedMeshRenderer != null)
            {
                skinnedMeshRenderer.sharedMesh = visualChildSo.Mesh ?? skinnedMeshRenderer.sharedMesh;
                skinnedMeshRenderer.sharedMaterial = visualChildSo.Material ?? skinnedMeshRenderer.sharedMaterial;
            }
        }
    }
}