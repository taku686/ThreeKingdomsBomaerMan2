// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "CGwell FX/Mask Alpha Blend" 
{
	Properties 
	{
		_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
		_MainTex("Particle Texture (A = Transparency)", 2D) = "white"{}
		_MaskTex ("Masked Texture", 2D) = "gray" {}
		_InvFade ("Soft Particles Factor", Range(0.01,3.0)) = 1.0
	}

	Category 
	{
		Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }

		Blend SrcAlpha OneMinusSrcAlpha
		AlphaTest Greater .01
		ColorMask RGB
		Cull Off Lighting Off ZWrite Off
		BindChannels 
		{
			Bind "Color", color
			Bind "Vertex", vertex
			Bind "TexCoord", texcoord
		}
	
		// ---- Fragment program cards
		SubShader 
		{
			Pass 
			{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma fragmentoption ARB_precision_hint_fastest
				#pragma multi_compile_particles
			
				#include "UnityCG.cginc"

				sampler2D _MainTex;
				sampler2D _MaskTex;
				fixed4 _TintColor;
			
				struct appdata_t 
				{
					float4 vertex : POSITION;
					fixed4 color : COLOR;
					float2 texcoord : TEXCOORD0;
					float2 texcoord1 : TEXCOORD1;
				};

				struct v2f 
				{
					float4 vertex : POSITION;
					fixed4 color : COLOR;
					float2 texcoord : TEXCOORD0;			
					float2 texcoord1 : TEXCOORD1;	
					#ifdef SOFTPARTICLES_ON
					float4 projPos : TEXCOORD2;				
					#endif
				};
			
				float4 _MainTex_ST;
				float4 _MaskTex_ST;
			
				v2f vert (appdata_t v)
				{
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);
					#ifdef SOFTPARTICLES_ON
					o.projPos = ComputeScreenPos (o.vertex);
					COMPUTE_EYEDEPTH(o.projPos.z);
					#endif
					o.color = v.color;
					o.texcoord = TRANSFORM_TEX(v.texcoord,_MainTex);
					o.texcoord1 = TRANSFORM_TEX(v.texcoord1,_MaskTex);
					return o;
				}

				sampler2D _CameraDepthTexture;
				float _InvFade;
			
				fixed4 frag (v2f i) : COLOR
				{
					#ifdef SOFTPARTICLES_ON
					float sceneZ = LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos))));
					float partZ = i.projPos.z;
					float fade = saturate (_InvFade * (sceneZ-partZ));
					i.color.a *= fade;
					#endif
				
					//return 2.0f * i.color * _TintColor * tex2D(_MainTex, i.texcoord);
					float4 col = 2.0f * i.color * _TintColor * tex2D(_MainTex, i.texcoord);
					col.a *= tex2D(_MaskTex, i.texcoord1).r;
					return col;
				}
				ENDCG 
			}
		} 	
	
		// ---- Dual texture cards
		SubShader 
		{
			Pass 
			{
				SetTexture [_MainTex] 
				{
					constantColor [_TintColor]
					combine constant * primary
				}

				SetTexture [_MainTex] 
				{
					combine texture * previous DOUBLE
				}
			}
		}
	
		// ---- Single texture cards (does not do color tint)
		SubShader 
		{
			Pass 
			{
				SetTexture [_MainTex] 
				{
					combine texture * primary
				}
			}
		}
	}
}
