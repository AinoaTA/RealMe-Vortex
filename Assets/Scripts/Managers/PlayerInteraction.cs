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

        public void OnInteract()
        {  
            if (Main.instance.GameStatus.Status != EnumsData.GameFlow.GAMEPLAY) return;

            Debug.Log("Interacting");

            List<Collider2D> detections = Physics2D.OverlapCircleAll(transform.position, _areaDetection, _interactableLayer).ToList();

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

            GameManager.Instance.CurrentInUse = obj;
            GameManager.Instance.CurrentInUse.Interact();

            Debug.Log(detected==null);
        }
    }
}