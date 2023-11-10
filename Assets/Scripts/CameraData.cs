using Cam;

//lets acces all componentes of scene camera. :)
public class CameraData
{
    public CameraFollow Follow { get; private set; }
    public CameraShake Shake { get; private set; }
    public CameraEffects Effects { get; private set; }

    public CameraData(CameraFollow _cam, CameraShake _shake, CameraEffects _effects)
    {
        Follow = _cam;
        Shake = _shake;
        Effects = _effects;
    }


    public void ObscureVignetteRad(bool enable) 
    {
        if (enable)
            Effects.WorseVignette();
        else
            Effects.BetterVignette();
    }

}