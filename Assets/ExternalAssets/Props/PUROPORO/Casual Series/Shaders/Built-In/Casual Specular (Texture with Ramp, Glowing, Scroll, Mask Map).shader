// Made with Amplify Shader Editor v1.9.1
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "PUROPORO/Built-in/Casual Specular (Texture with Ramp, Glowing, Scroll, Mask Map)"
{
	Properties
	{
		_BaseMap("Base (RGB)", 2D) = "white" {}
		_MaskMap("Mask Map", 2D) = "white" {}
		_DiffuseRampOffsetH("Diffuse Ramp Offset (Horizontal)", Range( 0 , 1)) = 0.75
		_SpecularRampOffsetH("Specular Ramp Offset (Horizontal)", Range( 0 , 1)) = 0.25
		_VFXGlowingColor("VFX Glowing Color", Color) = (1,1,1,1)
		_VFXGlowingPower("VFX Glowing Power", Range( -1 , 1)) = 0
		_VFXScrollRampTexture("VFX Scroll Ramp Texture", 2D) = "white" {}
		_VFXScrollSpeed("VFX Scroll Speed", Range( -1 , 1)) = 0
		[ASEEnd]_VFXScrollRotation("VFX Scroll Rotation", Range( 0 , 6.4)) = 1.6
		[HideInInspector] _texcoord( "", 2D ) = "white" {}

	}
	
	SubShader
	{
		
		
		Tags { "RenderType"="Opaque" }
	LOD 100

		CGINCLUDE
		#pragma target 3.0
		ENDCG
		Blend Off
		AlphaToMask Off
		Cull Back
		ColorMask RGBA
		ZWrite On
		ZTest LEqual
		Offset 0 , 0
		
		
		
		Pass
		{
			Name "Unlit"

			CGPROGRAM

			#define ASE_USING_SAMPLING_MACROS 1


			#ifndef UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX
			//only defining to not throw compilation error over Unity 5.5
			#define UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(input)
			#endif
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_instancing
			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "AutoLight.cginc"
			#include "UnityShaderVariables.cginc"
			#define ASE_NEEDS_FRAG_WORLD_POSITION
			#if defined(SHADER_API_D3D11) || defined(SHADER_API_XBOXONE) || defined(UNITY_COMPILER_HLSLCC) || defined(SHADER_API_PSSL) || (defined(SHADER_TARGET_SURFACE_ANALYSIS) && !defined(SHADER_TARGET_SURFACE_ANALYSIS_MOJOSHADER))//ASE Sampler Macros
			#define SAMPLE_TEXTURE2D(tex,samplerTex,coord) tex.Sample(samplerTex,coord)
			#else//ASE Sampling Macros
			#define SAMPLE_TEXTURE2D(tex,samplerTex,coord) tex2D(tex,coord)
			#endif//ASE Sampling Macros
			


			struct appdata
			{
				float4 vertex : POSITION;
				float4 color : COLOR;
				float4 ase_texcoord : TEXCOORD0;
				float3 ase_normal : NORMAL;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};
			
			struct v2f
			{
				float4 vertex : SV_POSITION;
				#ifdef ASE_NEEDS_FRAG_WORLD_POSITION
				float3 worldPos : TEXCOORD0;
				#endif
				float4 ase_texcoord1 : TEXCOORD1;
				float4 ase_texcoord2 : TEXCOORD2;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			//This is a late directive
			
			UNITY_DECLARE_TEX2D_NOSAMPLER(_BaseMap);
			uniform float4 _BaseMap_ST;
			SamplerState sampler_BaseMap;
			uniform float _DiffuseRampOffsetH;
			uniform float _SpecularRampOffsetH;
			UNITY_DECLARE_TEX2D_NOSAMPLER(_MaskMap);
			uniform float4 _MaskMap_ST;
			SamplerState sampler_MaskMap;
			UNITY_DECLARE_TEX2D_NOSAMPLER(_VFXScrollRampTexture);
			uniform float _VFXScrollSpeed;
			uniform float _VFXScrollRotation;
			SamplerState sampler_VFXScrollRampTexture;
			uniform float _VFXGlowingPower;
			uniform float4 _VFXGlowingColor;

			
			v2f vert ( appdata v )
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
				UNITY_TRANSFER_INSTANCE_ID(v, o);

				float3 ase_worldNormal = UnityObjectToWorldNormal(v.ase_normal);
				o.ase_texcoord2.xyz = ase_worldNormal;
				
				o.ase_texcoord1.xy = v.ase_texcoord.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord1.zw = 0;
				o.ase_texcoord2.w = 0;
				float3 vertexValue = float3(0, 0, 0);
				#if ASE_ABSOLUTE_VERTEX_POS
				vertexValue = v.vertex.xyz;
				#endif
				vertexValue = vertexValue;
				#if ASE_ABSOLUTE_VERTEX_POS
				v.vertex.xyz = vertexValue;
				#else
				v.vertex.xyz += vertexValue;
				#endif
				o.vertex = UnityObjectToClipPos(v.vertex);

				#ifdef ASE_NEEDS_FRAG_WORLD_POSITION
				o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
				#endif
				return o;
			}
			
			fixed4 frag (v2f i ) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID(i);
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i);
				fixed4 finalColor;
				#ifdef ASE_NEEDS_FRAG_WORLD_POSITION
				float3 WorldPosition = i.worldPos;
				#endif
				float2 uv_BaseMap = i.ase_texcoord1.xy * _BaseMap_ST.xy + _BaseMap_ST.zw;
				float3 worldSpaceLightDir = UnityWorldSpaceLightDir(WorldPosition);
				float3 ase_worldNormal = i.ase_texcoord2.xyz;
				float dotResult12 = dot( worldSpaceLightDir , ase_worldNormal );
				float4 appendResult47 = (float4((dotResult12*0.5 + 0.5) , _DiffuseRampOffsetH , 0.0 , 0.0));
				#if defined(LIGHTMAP_ON) && ( UNITY_VERSION < 560 || ( defined(LIGHTMAP_SHADOW_MIXING) && !defined(SHADOWS_SHADOWMASK) && defined(SHADOWS_SCREEN) ) )//aselc
				float4 ase_lightColor = 0;
				#else //aselc
				float4 ase_lightColor = _LightColor0;
				#endif //aselc
				float3 ase_worldViewDir = UnityWorldSpaceViewDir(WorldPosition);
				ase_worldViewDir = normalize(ase_worldViewDir);
				float3 normalizeResult15 = normalize( ( worldSpaceLightDir + ase_worldViewDir ) );
				float dotResult13 = dot( ase_worldNormal , normalizeResult15 );
				float4 appendResult46 = (float4((dotResult13*0.5 + 0.5) , _SpecularRampOffsetH , 0.0 , 0.0));
				float2 uv_MaskMap = i.ase_texcoord1.xy * _MaskMap_ST.xy + _MaskMap_ST.zw;
				float4 tex2DNode58 = SAMPLE_TEXTURE2D( _MaskMap, sampler_MaskMap, uv_MaskMap );
				float mulTime65 = _Time.y * _VFXScrollSpeed;
				float cos67 = cos( _VFXScrollRotation );
				float sin67 = sin( _VFXScrollRotation );
				float2 rotator67 = mul( WorldPosition.xy - float2( 0,0 ) , float2x2( cos67 , -sin67 , sin67 , cos67 )) + float2( 0,0 );
				
				
				finalColor = ( ( ( ( ( SAMPLE_TEXTURE2D( _BaseMap, sampler_BaseMap, uv_BaseMap ) * SAMPLE_TEXTURE2D( _BaseMap, sampler_BaseMap, appendResult47.xy ) ) * ase_lightColor ) + ( SAMPLE_TEXTURE2D( _BaseMap, sampler_BaseMap, appendResult46.xy ) * tex2DNode58.r ) ) + ( SAMPLE_TEXTURE2D( _VFXScrollRampTexture, sampler_VFXScrollRampTexture, ( (0.0*1.0 + mulTime65) + rotator67 ) ) * tex2DNode58.g ) ) + ( _VFXGlowingPower * _VFXGlowingColor ) );
				return finalColor;
			}
			ENDCG
		}
	}
	
	
	Fallback Off
}
/*ASEBEGIN
Version=19100
Node;AmplifyShaderEditor.ViewDirInputsCoordNode;7;-1677.945,322.4286;Inherit;False;World;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.WorldSpaceLightDirHlpNode;9;-1730.6,-117.3199;Inherit;False;False;1;0;FLOAT;0;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.WorldNormalVector;8;-1701.057,117.8141;Inherit;False;False;1;0;FLOAT3;0,0,1;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleAddOpNode;14;-1455.497,304.7621;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.DotProductOpNode;12;-1278.023,-117.6362;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;60;-1289.389,31.56039;Inherit;False;Constant;_Float0;Float 0;6;0;Create;True;0;0;0;False;0;False;0.5;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.NormalizeNode;15;-1288.711,178.2173;Inherit;False;False;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.ScaleAndOffsetNode;51;-955.2708,-128.0467;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;1;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;23;-1081.911,5.422614;Inherit;False;Property;_DiffuseRampOffsetH;Diffuse Ramp Offset (Horizontal);2;0;Create;False;0;0;0;False;0;False;0.75;0.75;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.DotProductOpNode;13;-1035.42,116.9019;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ScaleAndOffsetNode;52;-902.9761,229.7537;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;1;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;22;-1084.791,394.046;Inherit;False;Property;_SpecularRampOffsetH;Specular Ramp Offset (Horizontal);3;0;Create;False;0;0;0;False;0;False;0.25;0.25;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;47;-645.4173,-54.45836;Inherit;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.TexturePropertyNode;1;-544.1091,109.7355;Inherit;True;Property;_BaseMap;Base (RGB);0;0;Create;False;0;0;0;False;0;False;None;None;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.DynamicAppendNode;46;-644.6075,333.3018;Inherit;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.TexturePropertyNode;57;-461.9862,593.408;Inherit;True;Property;_MaskMap;Mask Map;1;0;Create;False;0;0;0;False;0;False;None;None;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.SamplerNode;48;-272.4622,-353.9486;Inherit;True;Property;_TextureSample2;Texture Sample 0;1;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;2;-270.1759,-80.57309;Inherit;True;Property;_TextureSample0;Texture Sample 0;1;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;4;-273.3439,306.0976;Inherit;True;Property;_TextureSample1;Texture Sample 1;1;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;21;58.55594,-257.1048;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.LightColorNode;10;37.8869,-11.5648;Inherit;False;0;3;COLOR;0;FLOAT3;1;FLOAT;2
Node;AmplifyShaderEditor.SamplerNode;58;-233.1416,593.4083;Inherit;True;Property;_TextureSample3;Texture Sample 1;2;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;49;230.178,-257.1468;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;59;102.9459,311.1432;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;6;396.6843,287.2068;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;56;1113.634,290.2908;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;45;1263.675,290.7958;Float;False;True;-1;2;;100;5;PUROPORO/Built-in/Casual Specular (Texture with Ramp, Glowing, Scroll, Mask Map);0770190933193b94aaa3065e307002fa;True;Unlit;0;0;Unlit;2;False;True;0;1;False;;0;False;;0;1;False;;0;False;;True;0;False;;0;False;;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;True;False;255;False;;255;False;;255;False;;7;False;;1;False;;1;False;;1;False;;7;False;;1;False;;1;False;;1;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;1;RenderType=Opaque=RenderType;True;2;False;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;0;;0;0;Standard;1;Vertex Position,InvertActionOnDeselection;1;0;0;1;True;False;;True;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;55;940.0091,428.348;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;53;706.9758,476.3495;Inherit;False;Property;_VFXGlowingColor;VFX Glowing Color;4;0;Create;False;0;0;0;False;0;False;1,1,1,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;54;637.8022,403.851;Inherit;False;Property;_VFXGlowingPower;VFX Glowing Power;5;0;Create;False;0;0;0;False;0;False;0;0;-1;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;61;570.7657,286.0787;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;71;388.1575,623.7791;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;62;53.58667,880.8046;Inherit;True;Property;_TextureSample4;Texture Sample 1;1;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;63;-198.7735,1091.983;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.ScaleAndOffsetNode;64;-434.0216,952.711;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;1;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;65;-624.8928,1000.456;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.WorldPosInputsNode;66;-617.1596,1114.552;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RotatorNode;67;-407.6093,1115.244;Inherit;False;3;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;2;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;68;-906.0623,995.2031;Inherit;False;Property;_VFXScrollSpeed;VFX Scroll Speed;7;0;Create;False;0;0;0;False;0;False;0;0;-1;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;69;-712.4149,1252.666;Inherit;False;Property;_VFXScrollRotation;VFX Scroll Rotation;8;0;Create;False;0;0;0;False;0;False;1.6;0;0;6.4;0;1;FLOAT;0
Node;AmplifyShaderEditor.TexturePropertyNode;70;-223.7235,880.067;Inherit;True;Property;_VFXScrollRampTexture;VFX Scroll Ramp Texture;6;0;Create;False;0;0;0;False;0;False;None;None;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
WireConnection;14;0;9;0
WireConnection;14;1;7;0
WireConnection;12;0;9;0
WireConnection;12;1;8;0
WireConnection;15;0;14;0
WireConnection;51;0;12;0
WireConnection;51;1;60;0
WireConnection;51;2;60;0
WireConnection;13;0;8;0
WireConnection;13;1;15;0
WireConnection;52;0;13;0
WireConnection;52;1;60;0
WireConnection;52;2;60;0
WireConnection;47;0;51;0
WireConnection;47;1;23;0
WireConnection;46;0;52;0
WireConnection;46;1;22;0
WireConnection;48;0;1;0
WireConnection;2;0;1;0
WireConnection;2;1;47;0
WireConnection;4;0;1;0
WireConnection;4;1;46;0
WireConnection;21;0;48;0
WireConnection;21;1;2;0
WireConnection;58;0;57;0
WireConnection;49;0;21;0
WireConnection;49;1;10;0
WireConnection;59;0;4;0
WireConnection;59;1;58;1
WireConnection;6;0;49;0
WireConnection;6;1;59;0
WireConnection;56;0;61;0
WireConnection;56;1;55;0
WireConnection;45;0;56;0
WireConnection;55;0;54;0
WireConnection;55;1;53;0
WireConnection;61;0;6;0
WireConnection;61;1;71;0
WireConnection;71;0;62;0
WireConnection;71;1;58;2
WireConnection;62;0;70;0
WireConnection;62;1;63;0
WireConnection;63;0;64;0
WireConnection;63;1;67;0
WireConnection;64;2;65;0
WireConnection;65;0;68;0
WireConnection;67;0;66;0
WireConnection;67;2;69;0
ASEEND*/
//CHKSM=CBAA0A037FCC393A154EDF62E839B6AC0EB2C377