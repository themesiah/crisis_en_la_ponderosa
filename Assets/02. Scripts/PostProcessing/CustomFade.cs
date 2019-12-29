using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(CustomFadeRenderer), PostProcessEvent.AfterStack, "Custom/Fade")]
public sealed class CustomFade : PostProcessEffectSettings
{
    [Range(0f, 1f), Tooltip("Fade effect intensity.")]
    public FloatParameter blend = new FloatParameter { value = 0.0f };
    public ColorParameter color = new ColorParameter { value = Color.black };
}

public sealed class CustomFadeRenderer : PostProcessEffectRenderer<CustomFade>
{
    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(Shader.Find("Hidden/Custom/Fade"));
        sheet.properties.SetFloat("_Blend", settings.blend);
        sheet.properties.SetColor("_Color", settings.color);
        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}