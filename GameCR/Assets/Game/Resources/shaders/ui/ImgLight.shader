Shader "CC/UI/ImgLight"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Tex("Texture", 2D) = "white" {}
		_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
		_Alpha ("Alpha", Range(0.01,1)) = 0.5
		_TexAlpha ("TexAlpha", Range(0.01,1)) = 0.5
	}
	SubShader
	{
		// No culling or depth
		Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
		Blend SrcAlpha OneMinusSrcAlpha
		//ColorMask RGB
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				fixed4 color : COLOR;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				fixed4 color : COLOR;
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;
				o.color = v.color;
				return o;
			}
			
			sampler2D _MainTex;
			sampler2D _Tex;
			float _Alpha;
			float _TexAlpha;
			half4 _TintColor;

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				fixed4 tex = tex2D(_Tex, i.uv);
				// just invert the colors
				fixed3 col3 = 2*_TintColor.xyz*_Alpha + col.xyz + tex.xyz*_TexAlpha;
				return fixed4(col3, col.w);
			}
			ENDCG
		}
	}
}
