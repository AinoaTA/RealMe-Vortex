using UnityEngine;

public class FadesController : MonoBehaviour
{
    public static FadesController Instance;

    [SerializeField] private SpriteRenderer _sp;

    private Coroutine _fadeIn;
    private Coroutine _fadeOut;
     
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    } 

    public void FadeIn(float dur = 1, float a = 1, float delay=0)
    {  
        if (_fadeIn != null) CodeAnimation.Stop(_fadeIn);
        if (_fadeOut != null) CodeAnimation.Stop(_fadeOut);

        _fadeIn = CodeAnimation.BlendColor(_sp, dur, CodeAnimation.CurveType.LINEAR, a: a,delay:(float)delay);
    }

    public void FadeOut(float dur = 1, float a = 0)
    { 
        if (_fadeIn != null) CodeAnimation.Stop(_fadeIn);
        if (_fadeOut != null) CodeAnimation.Stop(_fadeOut);
        _fadeOut = CodeAnimation.BlendColor(_sp, dur, CodeAnimation.CurveType.LINEAR, a: a);
    }

    public void BlinkFadeOut(float dur = 3, float a = 0)
    {
        if (_fadeIn != null) CodeAnimation.Stop(_fadeIn);
        if (_fadeOut != null) CodeAnimation.Stop(_fadeOut);
        _fadeOut = CodeAnimation.BlendColor(_sp, dur, CodeAnimation.CurveType.IN_OUT_BOUNCE, a: a);
    }
}