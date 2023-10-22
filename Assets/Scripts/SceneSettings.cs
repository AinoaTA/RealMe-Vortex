using UnityEngine;

[CreateAssetMenu(fileName = "Scene Settings", menuName = "Scene / Settings", order = 1)]
public class SceneSettings : ScriptableObject
{
    public Vector2 CameraClamping { get => _clampCameraX; }
    [Tooltip("Limits for camera desplacement in the scene")]
    [SerializeField] private Vector2 _clampCameraX;

    public Vector2 PlayerClamping { get => _clampPlayerX; }
    [Tooltip("Limits for player desplacement in the scene")]
    [SerializeField] private Vector2 _clampPlayerX;
}