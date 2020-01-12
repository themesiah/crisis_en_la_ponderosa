using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(ShotEffectRenderer), PostProcessEvent.AfterStack, "Custom/ShotEffect")]
public sealed class ShotEffect : PostProcessEffectSettings
{
    [Range(0f, 1f), Tooltip("Shot effect intensity.")]
    public FloatParameter blend = new FloatParameter { value = 0.0f };
    public TextureParameter texture = new TextureParameter();
}

public sealed class ShotEffectRenderer : PostProcessEffectRenderer<ShotEffect>
{
    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(Shader.Find("Hidden/Custom/ShotEffect"));
        sheet.properties.SetFloat("_Blend", settings.blend);
        sheet.properties.SetTexture("_EffectTexture", settings.texture);
        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}