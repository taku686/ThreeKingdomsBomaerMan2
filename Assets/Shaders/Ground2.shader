Shader "Custom/Ground2"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _SubColor ("SubColor", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _Division ("Division", Int) = 5
    }
    SubShader
    {
        Tags
        {
            "RenderType"="Opaque"
        }
        LOD 200

        Cull Off

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
            float3 worldPos;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
        fixed4 _SubColor;
        int _Division;
        fixed4 c;


        void surf(Input IN, inout SurfaceOutputStandard o)
        {
            if (int(fmod(floor(IN.worldPos.x + 0.5) + floor(IN.worldPos.z + 0.5), 2)) == 0)
            {
                c = tex2D(_MainTex, IN.uv_MainTex) * _SubColor;
            }
            else
            {
                c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
            }
            // Albedo comes from a texture tinted by color

            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}