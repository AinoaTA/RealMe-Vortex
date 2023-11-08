using UnityEngine;

/// <summary>
/// Level: player needs to go far away from that person to
/// complete the level.
/// </summary>
namespace Conflicto_1
{
    public class Controller : MonoBehaviour
    {
        private void Awake()
        {
            GameManager.instance.MustFollowPlayer = false;
        } 
    }
}