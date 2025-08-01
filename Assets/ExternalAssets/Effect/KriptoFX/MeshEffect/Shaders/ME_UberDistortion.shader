Shader "KriptoFX/ME/Distortion"
{
	Properties
	{	
		[Header(Main Settings)]
	[Toggle(USE_MAINTEX)] _UseMainTex("Use Main Texture", Int) = 0
		[HDR]_TintColor("Tint Color", Color) = (1,1,1,1)
		_MainTex ("Main Texture", 2D) = "black" {}
			[Header(Main Settings)]
		[Normal]_NormalTex ("Normal(RG) Alpha(A)", 2D) = "bump" {}
		[HDR]_MainColor("Main Color", Color) = (1,1,1,1)
		_Distortion ("Distortion", Float) = 100
	[Toggle(USE_REFRACTIVE)] _UseRefractive("Use Refractive Distort", Int) = 0
		_RefractiveStrength("Refractive Strength", Range (-1, 1)) = 0
	
	[Toggle(USE_SOFT_PARTICLES)] _UseSoft("Use Soft Particles", Int) = 0
		_InvFade("Soft Particles Factor", Float) = 3
		[Space]
		[Header(Height Settings)]
	[Toggle(USE_HEIGHT)] _UseHeight("Use Height Map", Int) = 0
		_HeightTex ("Height Tex", 2D) = "white" {}
		_Height("_Height", Float) = 0.1
		_HeightUVScrollDistort("Height UV Scroll(XY)", Vector) = (8, 12, 0, 0)
		
		[Space]
		[Header(Fresnel)]
	[Toggle(USE_FRESNEL)] _UseFresnel("Use Fresnel", Int) = 0
		[HDR]_FresnelColor("Fresnel Color", Color) = (0.5,0.5,0.5,1)
		_FresnelPow ("Fresnel Pow", Float) = 5
		_FresnelR0 ("Fresnel R0", Float) = 0.04
		_FresnelDistort("Fresnel Distort", Float) = 1500
		
		[Space]
		[Header(Cutout)]
	[Toggle(USE_CUTOUT)] _UseCutout("Use Cutout", Int) = 0
		_CutoutTex ("Cutout Tex", 2D) = "white" {}
		_Cutout("Cutout", Range(0, 1.2)) = 1
		[HDR]_CutoutColor("Cutout Color", Color) = (1,1,1,1)
		_CutoutThreshold("Cutout Threshold", Range(0, 1)) = 0.015
		
		[Space]
		[Header(Rendering)]
		[Toggle] _ZWriteMode("ZWrite On?", Int) = 0
		[Enum(Off,0,Front,1,Back,2)] _CullMode ("Culling", Float) = 2 //0 = off, 2=back
		[Toggle(USE_ALPHA_CLIPING)] _UseAlphaCliping("Use Alpha Cliping", Int) = 0
		_AlphaClip ("Alpha Clip Threshold", Float) = 10
		[Toggle(USE_BLENDING)] _UseBlending("Use Blending", Int) = 0
	}
	SubShader
	{
		

		Tags { "Queue"="Transparent-10" "IgnoreProjector"="True" "RenderType"="Transparent" }
		ZWrite [_ZWriteMode]
		Cull [_CullMode]
			Offset -1, -1
		Blend SrcAlpha OneMinusSrcAlpha
		
		Pass
		{
			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fog
			#pragma multi_compile_particles
			#pragma multi_compile_instancing

			#pragma shader_feature USE_REFRACTIVE
			#pragma shader_feature USE_SOFT_PARTICLES
			#pragma shader_feature USE_FRESNEL
			#pragma shader_feature USE_CUTOUT
			#pragma shader_feature USE_HEIGHT
			#pragma shader_feature USE_ALPHA_CLIPING
			#pragma shader_feature USE_BLENDING
			#pragma shader_feature USE_MAINTEX
			
			#include "UnityCG.cginc"

			float4 CustomGrabScreenPos(float4 vertex)
			{
				return ComputeGrabScreenPos(vertex);
			}

			#include "ME_DistortionPasses.cginc"

			ENDCG
		}
	}

	CustomEditor "ME_CustomShaderGUI"
}
