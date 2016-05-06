Shader "ihaiu/Terrain_3Texture_1Shade" {
	Properties {
		_MainTint ("Diffuse Tint", Color) = (1, 1, 1, 1)
		_ColorLight ("Light Color (Blend B)", Color) = (1, 1, 1, 1)
		_ColorShade ("Shade Color (Blend A)", Color) = (0, 0, 0, 0)
		_BaseTexture ("Base Map Texture", 2D) = "white"{}
		_RTexture ("Red Channel Texture (Blend R)", 2D) = "white"{}
		_GTexture ("Green Channel Texture  (Blend G)", 2D) = "white"{}
		_BlendTexture ("Blend Texture", 2D) = "white"{}
	}
	
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		float4 _MainTint;
		float4 _ColorLight;
		float4 _ColorShade;
		sampler2D _BaseTexture;
		sampler2D _RTexture;
		sampler2D _GTexture;
		sampler2D _BlendTexture;

		struct Input {
			float2 uv_BaseTexture;
			float2 uv_RTexture;
			float2 uv_GTexture;
			float2 uv_BlendTexture;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			float4 blendData = tex2D(_BlendTexture, IN.uv_BlendTexture);
			
			float4 baseTexData = tex2D(_BaseTexture, IN.uv_BaseTexture);
			float4 rTexData = tex2D(_RTexture, IN.uv_RTexture);
			float4 gTexData = tex2D(_GTexture, IN.uv_GTexture);
			
			float4 finalColor;
			finalColor = lerp(baseTexData, rTexData, blendData.r);
			finalColor = lerp(finalColor, gTexData, blendData.g);
			finalColor = lerp(finalColor, _ColorShade, blendData.a);
			finalColor = lerp(finalColor, _ColorLight, blendData.b);
			finalColor.a = 1.0;
			
			
			o.Albedo = finalColor.rgb * _MainTint.rgb;
			o.Alpha = finalColor.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
