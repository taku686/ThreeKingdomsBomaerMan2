// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: commented out 'float4 unity_LightmapST', a built-in variable
// Upgrade NOTE: commented out 'sampler2D unity_Lightmap', a built-in variable
// Upgrade NOTE: replaced tex2D unity_Lightmap with UNITY_SAMPLE_TEX2D

Shader "Custom/SplatMap4" {

Properties {
	_Splat0 ("Layer0(Base)", 2D) = "white" {}
	_Layer0 ("Layer0 Tiling", Float) = 0.5
	_Splat1 ("Layer1(Red)", 2D) = "white" {}
	_Layer1 ("Layer1 Tiling", Float) = 0.5
	_Splat2 ("Layer2(Green)", 2D) = "white" {}
	_Layer2 ("Layer2 Tiling", Float) = 0.5
	_Splat3 ("Layer3(Blue)", 2D) = "white" {}
	_Layer3 ("Layer3 Tiling", Float) = 0.5
	_AlphaTex ("RGB Texture", 2D) = "white" {}
}

SubShader {

Pass {
		Tags { "Queue"="Transparent" "IgnoreProjector"="False" "RenderType"="Transparent"}
		//Lighting Off

		CGPROGRAM

		#pragma vertex vert
		#pragma fragment frag
		#include "UnityCG.cginc"

		sampler2D _Splat0;
		sampler2D _Splat1;
		sampler2D _Splat2;
		sampler2D _Splat3;
			
		sampler2D _AlphaTex;
		fixed4 _TintColor;
		float _Layer0;
		float _Layer1;
		float _Layer2;
		float _Layer3;
			
		struct appdata_t {
			float4 vertex : POSITION;
			float2 texcoord : TEXCOORD0;
			float2 texcoord1 : TEXCOORD1;
		};

		struct v2f {
			float4 vertex : POSITION;
			float2 uv1 : TEXCOORD0;
			float2 uv2 : TEXCOORD1;
			float2 uv3 : TEXCOORD2;
			float2 uv4 : TEXCOORD3;
			float2 uvLM  : TEXCOORD4;
			float2 splat  : TEXCOORD5;
		};
			
		float4 _AlphaTex_ST;
			
 		// float4 unity_LightmapST;	 
 		// sampler2D unity_Lightmap;

		v2f vert (appdata_t v)
		{
			v2f o;
			o.vertex = UnityObjectToClipPos(v.vertex);
			o.splat = TRANSFORM_TEX(v.texcoord,_AlphaTex);
			o.uv1 = o.splat * _Layer0;
			o.uv2 = o.splat * _Layer1;
			o.uv3 = o.splat * _Layer2;
			o.uv4 = o.splat * _Layer3;
 			o.uvLM = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw; 

			return o;
		}
			
		fixed4 frag (v2f i) : COLOR
		{
			fixed4 splat_control = tex2D (_AlphaTex, i.splat);		
			fixed3 lay1 = tex2D (_Splat0, i.uv1);
			fixed3 lay2 = tex2D (_Splat1, i.uv2);
			fixed3 lay3 = tex2D (_Splat2, i.uv3);
			fixed3 lay4 = tex2D (_Splat3, i.uv4);

	        fixed4 col;

			float a = 1.0 - (splat_control.r + splat_control.g + splat_control.b);

		    col.a = 1.0;
            col.rgb = (lay1 * a) + (lay2 * splat_control.r) + (lay3 * splat_control.g) + (lay4 * splat_control.b);
	 		fixed3 lm = ( DecodeLightmap (UNITY_SAMPLE_TEX2D(unity_Lightmap, i.uvLM))); 
 			col.rgb *= lm;
						
			return col;
		}
		ENDCG 
	}//PASSEND

	 Pass {
            Tags {"RenderType"="Opaque" "Queue"="Geometry"  "LightMode" = "ForwardAdd" }

			Blend Zero SrcColor                 
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fwdadd_fullshadows
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"

            struct v2f
			{
                float4 pos : SV_POSITION;
                LIGHTING_COORDS(0,1)
            };
            v2f vert (appdata_full v)
			{

                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o);
                return o;
            }

            float4 frag (v2f i) : COLOR 
			{
                return  LIGHT_ATTENUATION(i);
            }


            ENDCG



        } //Pass
}

  FallBack "Mobile/Diffuse"
}