using UnityEngine;
using UnityEngine.Events;

namespace BrokenHeart
{
    public class StateChuckCondition : Conditioner
    {
        [SerializeField] private BrokenHeart.StateScene _requiredChuckState;
        [SerializeField] private string _dialogueName;
        [SerializeField] private UnityEvent onComplete;

        private bool _enabled = false;

        public override bool CheckCondition()
        {
            _enabled = Controller.instance.CheckState(_requiredChuckState);
            return _enabled;
        }

        public override void DoEvent()
        {
            if (_enabled)
            {
                onComplete?.Invoke();
            }
        }

        public void LoadDialogue()
        { 
            GameManager.instance.StartConver(_dialogueName, false);
        }
    }
}