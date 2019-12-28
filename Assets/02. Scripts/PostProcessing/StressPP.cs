using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(StressPPRenderer), PostProcessEvent.AfterStack, "Custom/Stress")]
public sealed class StressPP : PostProcessEffectSettings
{
    [Range(0f, 1f), Tooltip("Stress effect intensity.")]
    public FloatParameter blend = new FloatParameter { value = 0.0f };
    public ColorParameter color = new ColorParameter { value = Color.red };
}

public sealed class StressPPRenderer : PostProcessEffectRenderer<StressPP>
{
    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(Shader.Find("Hidden/Custom/Stress"));
        sheet.properties.SetFloat("_Blend", settings.blend);
        sheet.properties.SetColor("_Color", settings.color);
        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}