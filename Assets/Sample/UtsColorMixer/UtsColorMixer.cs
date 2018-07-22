using UnityEngine;

namespace UnityChan {
public class UtsColorMixer : MonoBehaviour
{
    public enum UtsRenderMode {
        Default,
        ShadeColorsBlack,
        Manual
    }

    public UtsRenderMode utsRenderMode = UtsRenderMode.Default;

    [SerializeField] Vector4 _BaseColor_Mixer      = new Vector4(1,0,0,0);
    [SerializeField] Vector4 _1st_ShadeColor_Mixer = new Vector4(0,1,0,0);
    [SerializeField] Vector4 _2nd_ShadeColor_Mixer = new Vector4(0,0,1,0);
    [SerializeField] Color   _BaseColor_Mixer_Color      = new Color(0,0,0,1);
    [SerializeField] Color   _1st_ShadeColor_Mixer_Color = new Color(0,0,0,1);
    [SerializeField] Color   _2nd_ShadeColor_Mixer_Color = new Color(0,0,0,1);

    const string ColorMixerKeyword = "_UTS_IS_COLOR_MIXER";

    void OnPreRender() {
        Shader.EnableKeyword(ColorMixerKeyword);
        switch(utsRenderMode) {
        default:
        case UtsRenderMode.Default:
            Shader.SetGlobalVector("_BaseColor_Mixer"     , new Vector4(1,0,0,0));
            Shader.SetGlobalVector("_1st_ShadeColor_Mixer", new Vector4(0,1,0,0));
            Shader.SetGlobalVector("_2nd_ShadeColor_Mixer", new Vector4(0,0,1,0));
            Shader.SetGlobalVector("_BaseColor_Mixer_Color"     , Color.black);
            Shader.SetGlobalVector("_1st_ShadeColor_Mixer_Color", Color.black);
            Shader.SetGlobalVector("_2nd_ShadeColor_Mixer_Color", Color.black);
            break;
        case UtsRenderMode.ShadeColorsBlack:
            Shader.SetGlobalVector("_BaseColor_Mixer"     , new Vector4(1,0,0,0));
            Shader.SetGlobalVector("_1st_ShadeColor_Mixer", new Vector4(0,0,0,1));
            Shader.SetGlobalVector("_2nd_ShadeColor_Mixer", new Vector4(0,0,0,1));
            Shader.SetGlobalVector("_BaseColor_Mixer_Color"     , Color.black);
            Shader.SetGlobalVector("_1st_ShadeColor_Mixer_Color", Color.black);
            Shader.SetGlobalVector("_2nd_ShadeColor_Mixer_Color", Color.black);
            break;
        case UtsRenderMode.Manual:
            Shader.SetGlobalVector("_BaseColor_Mixer"     , _BaseColor_Mixer);
            Shader.SetGlobalVector("_1st_ShadeColor_Mixer", _1st_ShadeColor_Mixer);
            Shader.SetGlobalVector("_2nd_ShadeColor_Mixer", _2nd_ShadeColor_Mixer);
            Shader.SetGlobalVector("_BaseColor_Mixer_Color"     , _BaseColor_Mixer_Color);
            Shader.SetGlobalVector("_1st_ShadeColor_Mixer_Color", _1st_ShadeColor_Mixer_Color);
            Shader.SetGlobalVector("_2nd_ShadeColor_Mixer_Color", _2nd_ShadeColor_Mixer_Color);
            break;
        }
    }

    void OnPostRender() {
        Shader.DisableKeyword(ColorMixerKeyword);
    }
}
} // namespace
