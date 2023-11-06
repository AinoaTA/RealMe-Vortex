using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private float _areaDetection = 5f;
        [SerializeField] private LayerMask _interactableLayer;

        private void OnEnable()
        {
            InputManager.OnInteraction += OnInteract; 
        }

        private void OnDisable()
        {
            InputManager.OnInteraction -= OnInteract;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, _areaDetection);
        }

        public void OnInteract()
        {
            if (GameManager.instance.GameStatus.Status != EnumsData.GameFlow.GAMEPLAY) return;

            List<Collider2D> detections = Physics2D.OverlapCircleAll(transform.position, _areaDetection, _interactableLayer).ToList();
            

            if (detections.Count == 0) return;

            Debug.Log("before: "+detections.Count);
            for (int i = 0; i < detections.Count; i++)
            {
                if (detections[i].GetComponent<Interactable>().blocked)
                    detections.Remove(detections[i]);
            }
            Debug.Log("after: "+detections.Count);

            if (detections.Count == 0) return;

            Collider2D detected = detections[0];
            float dist = Vector2.Distance(detected.transform.position, transform.position);
            detections.ForEach(n =>
            {
                float newDist = Vector2.Distance(n.transform.position, transform.position);
                if (newDist < dist)
                {
                    dist = newDist;
                    detected = n;
                }
            });

            detected.TryGetComponent(out Interactable obj);

            GameController.Instance.CurrentInUse = obj;
            GameController.Instance.CurrentInUse.Interact();
        }
    }
}