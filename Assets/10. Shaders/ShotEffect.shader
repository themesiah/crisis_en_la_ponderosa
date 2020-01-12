Shader "Hidden/Custom/ShotEffect"
{
	HLSLINCLUDE

#include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

	TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
	TEXTURE2D_SAMPLER2D(_EffectTexture, sampler_EffectTexture);
	float _Blend;

	float4 Frag(VaryingsDefault i) : SV_Target
	{
		float4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);
		//float4 color2 = SAMPLE_TEXTURE2D(_EffectTexture, sampler_EffectTexture, UnityStereoScreenSpaceUVAdjust(i.texcoord, sampler_EffectTexture));
		//float4 color2 = SAMPLE_TEXTURE2D(_EffectTexture, sampler_EffectTexture, i.texcoord);
		float2 screenUV = (i.vertex.xy / _ScreenParams.xy);
#if UNITY_UV_STARTS_AT_TOP
		screenUV.y *= -_ProjectionParams.x;
#endif
		float4 color2 = SAMPLE_TEXTURE2D(_EffectTexture, sampler_EffectTexture, screenUV);
		if (color2.a <= 0) {
			clip(-1);
		}
		return color2;
	}

		ENDHLSL

		SubShader
	{
		Cull Off ZWrite Off ZTest Always

			Pass
		{
			HLSLPROGRAM

#pragma vertex VertDefault
#pragma fragment Frag

			ENDHLSL
		}
	}
}