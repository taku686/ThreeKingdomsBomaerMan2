// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "ToOn/FX/RenderedGlass" 
{
	Properties 
	{
		_BumpAmt  ("Distortion", range (0,128)) = 10
		_BumpMap ("Normalmap", 2D) = "bump" {}
		_RenderTex ("Render", 2D) = "white" {}
	}

	Category 
	{
		Tags { "Queue"="Transparent+100"}

		SubShader 
		{
			Lighting off
			Blend SrcAlpha OneMinusSrcAlpha
			// ZTest Always

			Pass 
			{
				Name "BASE"
				
				Cull Off
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma fragmentoption ARB_precision_hint_fastest
				#include "UnityCG.cginc"

				struct appdata_t 
				{
					float4 vertex : POSITION;
					float2 texcoord: TEXCOORD0;
				};

				struct v2f 
				{
					float4 vertex : POSITION;
					half4 uvrt : TEXCOORD0;
					float2 uvbump : TEXCOORD1;
				};

				float _BumpAmt;
				float4 _BumpMap_ST;
  
				v2f vert (appdata_t v)
				{ 
					v2f o;
					o.vertex	= UnityObjectToClipPos(v.vertex);
					o.uvrt		= ComputeScreenPos(o.vertex);
					o.uvbump	= TRANSFORM_TEX( v.texcoord, _BumpMap);
					return o;
				}

				sampler2D _RenderTex;
				float4 _RenderTex_TexelSize;
				sampler2D _BumpMap;

				half4 frag( v2f i ) : COLOR
				{
					half4	normal  = tex2D(_BumpMap, i.uvbump );
					half3	bump	= UnpackNormal(normal); 
					float2	offset	= bump.rg * _BumpAmt * _RenderTex_TexelSize.xy;
					i.uvrt.xy = offset * i.uvrt.z + i.uvrt.xy;
					half4 col = tex2Dproj( _RenderTex, UNITY_PROJ_COORD(i.uvrt));
					col.a = normal.b;
					return col;
				}
				ENDCG
			}
		}
	}
}
