using UnityEngine;

namespace Menu
{ 
    public enum MenuType { DEFAULT, OPTIONS, PAUSE }

    public class Menu : MonoBehaviour
    {
        public MenuType Type { get => _type; }
        [SerializeField] private MenuType _type;

        private CanvasGroup _groups;

        private void Awake()
        {
            TryGetComponent(out _groups);
        }
    }
}