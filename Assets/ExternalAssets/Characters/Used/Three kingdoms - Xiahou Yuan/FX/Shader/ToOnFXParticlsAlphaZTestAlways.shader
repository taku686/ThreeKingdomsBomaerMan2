﻿// Simplified Alpha Blended Particle shader. Differences from regular Alpha Blended Particle one:
// - no Tint color
// - no Smooth particle support
// - no AlphaTest
// - no ColorMask

Shader "ToOn/FX/ParticleAlphaZTestAlways" {
Properties {
	_MainTex ("Particle Texture", 2D) = "white" {}
}

Category 
{
	Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
	Blend SrcAlpha OneMinusSrcAlpha
	Cull Off Lighting Off ZWrite Off Fog { Color (0,0,0,0) }
	ZTest Always
	Fog { Mode Off } 

	BindChannels 
	{
		Bind "Color", color
		Bind "Vertex", vertex
		Bind "TexCoord", texcoord
	}
	
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
