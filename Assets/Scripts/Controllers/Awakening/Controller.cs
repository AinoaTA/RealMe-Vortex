using System.Collections;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using System.Collections.Generic;

namespace Awakening
{
    public class Controller : MonoBehaviour
    {
        public static Controller instance;

        [SerializeField] private List<Interactable> _allInteractables = new();
        [SerializeField] private bool _debuggin;


        public bool KeyUnlocked { get => _keyUnlocked; private set => _keyUnlocked = value; }
        [SerializeField] private bool _keyUnlocked = false;

        private void Awake()
        {
            instance = this;

#if !UNITY_EDITOR
           _debuggin = false;
#endif
        }

        private void Start()
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/WakeUp");

            if (!_debuggin)
            {
                _allInteractables.ForEach(n =>
                {
                    n.blocked = true;
                    n.enabled = false;
                });
            }

            DialogueManager.StopConversation();

            StartCoroutine(StartRoutine());
        }

        public void UnlockInteractables()
        {
            _allInteractables.ForEach(n =>
            {
                n.enabled = true;
                n.blocked = false;
            });
        }

        public void IsKeyUnlocked()
        {
            _keyUnlocked = true;
        }

        private IEnumerator StartRoutine()
        {
            //DialogueManager.UseDialogueUI(_oniricDialogue);
            yield return new WaitForSeconds(1);

            GameManager.instance.StartConver("Awakening");

            yield return new WaitForSeconds(0.5f);
            yield return new WaitWhile(() => DialogueManager.IsConversationActive);

            GameManager.instance.StartConver("Awakening 2");

            yield return new WaitForSeconds(0.5f);
            yield return new WaitWhile(() => DialogueManager.IsConversationActive);
        }
    }
}