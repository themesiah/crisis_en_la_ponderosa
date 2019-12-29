using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[CreateAssetMenu(fileName = "PostProcessingMnaager", menuName = "Managers/PostProcessingManager", order = 0)]
public class PostProcessingManager : ScriptableObject
{
    [SerializeField]
    private PostProcessProfile postProcessProfile;

    private StressPP stressSettings;
    private CustomFade fadeSettings;

    public void SetStress(float stress)
    {
        if (stressSettings == null)
        {
            postProcessProfile.TryGetSettings(out stressSettings);
        }
        if (stressSettings != null)
        {
            stressSettings.blend.value = stress;
        }
    }

    public void SetFade(float level)
    {
        if (fadeSettings == null)
        {
            postProcessProfile.TryGetSettings(out fadeSettings);
        }
        if (fadeSettings != null)
        {
            fadeSettings.blend.value = Mathf.Clamp01(level);
            if (stressSettings)
            {
                stressSettings.blend.value = Mathf.Min(stressSettings.blend.value, 1 - level);
            }
        }
    }
}
