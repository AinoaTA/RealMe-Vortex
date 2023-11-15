using UnityEngine;

public class FMODSpecial : MonoBehaviour
{
    public static FMODSpecial instance;
    [SerializeField] private FMODUnity.StudioEventEmitter[] _emitters;

    private int _prevIndex;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ChangeMusic(EnumsData.MusicScene index)
    {
        if (_emitters[_prevIndex].IsPlaying())
            _emitters[_prevIndex].Stop();

        _emitters[(int)index].Play();

        _prevIndex = (int)index;
    }
}