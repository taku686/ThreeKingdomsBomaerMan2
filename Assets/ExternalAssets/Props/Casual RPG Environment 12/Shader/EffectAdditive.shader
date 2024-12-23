// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/EffectAdditive"
{
	Properties
	{
		_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
		_MainTex ("Particle Texture", 2D) = "white" {}
	}
 
	SubShader
	{   
		Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
		Pass
		{
			ZWrite Off
			Cull Off
			Fog { Color (0,0,0,0) }
			Blend SrcAlpha One 
	  
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
 
			float4 _TintColor;
			sampler2D _MainTex;
 
			struct v2f
			{    
				float4  pos :   SV_POSITION;    
				float4	color : COLOR;
				float2  uv : TEXCOORD0;
			};
 
			float4 _MainTex_ST;
 
			v2f vert (appdata_full v)
			{    
				v2f o;    
				o.pos = UnityObjectToClipPos (v.vertex);    
				o.color = v.color;
				o.uv = TRANSFORM_TEX (v.texcoord, _MainTex);    
				return o;
			}
 
			half4 frag (v2f i) : COLOR
			{    
				half4 texcol = tex2D (_MainTex, i.uv);
				return texcol * ((2.0 * i.color) * _TintColor);
			}
 
			ENDCG
		}

	}Fallback "VertexLit" 
}



/*
Shader "Custom/EffectAdditive" {

Properties {
 _TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
 _MainTex ("Particle Texture", 2D) = "white" {}
}
SubShader { 
 Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
 Pass {
  Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
  BindChannels {
   Bind "vertex", Vertex
   Bind "color", Color
   Bind "texcoord", TexCoord
  }
  ZWrite Off
  Cull Off
  Fog {
   Color (0,0,0,0)
  }
  Blend SrcAlpha One
  
  SetTexture [_MainTex] 
  {   
	constantColor [_TintColor]
	combine primary * constant double
  }

  SetTexture [_MainTex] 
  {   
	combine previous  * texture
  }
 }
}
}
*/