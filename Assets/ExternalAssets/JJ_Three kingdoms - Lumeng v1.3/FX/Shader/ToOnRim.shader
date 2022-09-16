Shader "ToOn/Rim" 
{
	Properties 
	{
		_MainTex ("Texture", 2D) = "white" {}
		_RimColor ("Rim Color", Color) = (0.26,0.19,0.16,0.0)
		_RimPower ("Rim Power", Range(0.5,8.0)) = 3.0
	}

	SubShader 
	{
		Tags 
		{ 
			"RenderType" = "Opaque" 
		}


		CGPROGRAM

		inline fixed4 LightingOnlyTexture (SurfaceOutput s, half3 lightDir, half atten)
		{
			fixed4 c;
			c.rgb = s.Albedo;
			c.a = s.Alpha;
			return c;
		}


		#pragma surface surf OnlyTexture noambient 

		struct Input 
		{
			fixed2 uv_MainTex;
			half3 viewDir;
		};
		
		sampler2D _MainTex;
		fixed4 _RimColor;
		fixed _RimPower;

		void surf (Input IN, inout SurfaceOutput o) 
		{
			o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
			half rim = 1.0 - saturate(dot (normalize(IN.viewDir), o.Normal));
			o.Emission = _RimColor.rgb * pow (rim, _RimPower);
		}
		ENDCG
	} 

	Fallback "Diffuse"
}