using UnityEngine;

[CreateAssetMenu(fileName = "Scene Settings", menuName = "Settings", order = 1)]
public class SceneSettings : ScriptableObject
{
    public Vector2 CameraClampingX { get => _clampCameraX; }
    [Tooltip("Horizontal Limits for camera desplacement in the scene")]
    [SerializeField] private Vector2 _clampCameraX;

    public Vector2 CameraClampingY { get => _clampCameraY; }
    [Tooltip("Vertical Limits for camera desplacement in the scene")]
    [SerializeField] private Vector2 _clampCameraY;

    //public Vector2 PlayerClamping { get => _clampPlayerX; }
    //[Tooltip("Limits for player desplacement in the scene")]
    //[SerializeField] private Vector2 _clampPlayerX;
}