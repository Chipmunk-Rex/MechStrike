using System;
using System.Collections.Generic;
using System.Linq;
using ChipmunkKingdoms.Scripts.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace ChipmunkKingdoms.Scripts
{
    public class Visual : MonoBehaviour, IContainerComponent
    {
        private Dictionary<VisualChildTypeSO, VisualChildBehavior> visualChildren = new();
        [field: SerializeField] public List<MeshRenderer> MeshRenderers { get; private set; }
        [field: SerializeField] public List<SkinnedMeshRenderer> SkinnedMeshRenderers { get; private set; }
        [field: SerializeField] public List<MeshFilter> MeshFilters { get; private set; }
        public GameObject selectedVisual;

        private void Awake()
        {
            Initalize();
        }

        private void Initalize()
        {
            if (MeshRenderers == null || MeshRenderers.Count == 0)
                MeshRenderers = new List<MeshRenderer>(GetComponentsInChildren<MeshRenderer>(true));

            if (MeshFilters == null || MeshFilters.Count == 0)
                MeshFilters = new List<MeshFilter>(GetComponentsInChildren<MeshFilter>(true));
            if (SkinnedMeshRenderers == null || SkinnedMeshRenderers.Count == 0)
                SkinnedMeshRenderers =
                    new List<SkinnedMeshRenderer>(GetComponentsInChildren<SkinnedMeshRenderer>(true));

            AddChildToDictionary();
        }

        public void SetVisualSO(VisualSO visualSo)
        {
            if (visualSo == null)
            {
                Debug.LogWarning("VisualSO is null, skipping initialization.");
                return;
            }

            foreach (KeyValuePair<VisualChildTypeSO, VisualChildBehavior> keyValuePair in visualChildren)
            {
                BaseVisualChildSO visualChildSO = visualSo.GetVisualChild(keyValuePair.Key);
                keyValuePair.Value.SetVisual(visualChildSO);
            }
        }

        private void AddChildToDictionary(VisualChildBehavior child)
        {
            visualChildren.Add(child.VisualChildType, child);
        }

        private void AddChildToDictionary()
        {
            GetComponentsInChildren<VisualChildBehavior>(true).ToList()
                .ForEach(AddChildToDictionary);
        }

        public void ReplaceMeshFilter(List<MeshFilter> newMeshFilter)
        {
            if (newMeshFilter == null || newMeshFilter.Count == 0)
            {
                Debug.LogWarning("New mesh filter list is empty or null.");
                return;
            }

            for (int i = 0; i < MeshRenderers.Count && i < MeshFilters.Count; i++)
            {
                MeshFilters[i].sharedMesh = newMeshFilter[i].sharedMesh;
            }
        }

        public void ReplaceMeshRenderer(List<MeshRenderer> newMeshRenderers)
        {
            if (newMeshRenderers == null || newMeshRenderers.Count == 0)
            {
                Debug.LogWarning("New mesh renderer list is empty or null.");
                return;
            }

            for (int i = 0; i < MeshRenderers.Count && i < newMeshRenderers.Count; i++)
            {
                MeshRenderers[i].sharedMaterial = newMeshRenderers[i].sharedMaterial;
            }
        }

        public void ReplaceSkinnedMeshRenderer(List<SkinnedMeshRenderer> newSkinnedMeshRenderers)
        {
            if (newSkinnedMeshRenderers == null || newSkinnedMeshRenderers.Count == 0)
            {
                Debug.LogWarning("New skinned mesh renderer list is empty or null.");
                return;
            }

            for (int i = 0; i < SkinnedMeshRenderers.Count && i < newSkinnedMeshRenderers.Count; i++)
            {
                SkinnedMeshRenderers[i].sharedMaterial = newSkinnedMeshRenderers[i].sharedMaterial;
                SkinnedMeshRenderers[i].sharedMesh = newSkinnedMeshRenderers[i].sharedMesh;
            }
        }

        public void SetColor(Color color)
        {
            foreach (var meshRenderer in MeshRenderers)
            {
                meshRenderer.material.color = color;
            }
        }

        private void Reset()
        {
            Initalize();
        }

        public ComponentContainer ComponentContainer { get; set; }

        public void OnInitialize(ComponentContainer componentContainer)
        {
        }
    }
}