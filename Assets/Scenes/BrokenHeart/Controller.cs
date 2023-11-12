using System.Collections;
using System.Linq;
using UnityEngine;

namespace BrokenHeart
{
    public enum StateScene
    {
        NONE = 0,
        CIGARRILLOS_INTRO, CIGARRILLOS_NOENCONTRADOS, CIGARRILLOS_ENCONTRADO,
        END_STATE
    }

    public class Controller : MonoBehaviour
    {
        public static Controller instance;
        [SerializeField] private Interactable[] _allInteractables;
        [SerializeField] private bool _debuggin;

        private StateScene _chuckState;

        private void Awake()
        {
            instance = this;
        }

        private IEnumerator Start()
        {
            GameManager.instance.MustFollowPlayer = false;

            if (!_debuggin)
            {
                _allInteractables.ToList().ForEach(n =>
                {
                    n.blocked = true;
                    n.enabled = false;
                });
            }

            yield return new WaitForSeconds(0.3f);
            //GameManager.instance.StartConver("BrokenHeart/Intro_BrokenHeart", true);
            GameManager.instance.StartConver("BrokenHeart/Vacio", true);
        }

        public bool CheckState(StateScene chuckState)
        {
            return _chuckState == chuckState;
        }

        public void NextState()
        {
            _chuckState++;
        }

        public StateScene CurrentState() => _chuckState;
    }
}