Shader "Custom/TerrainTopLayerShader"
{
    Properties
    {
        _Color ("Main Color", Color) = (.5,.5,.5,1)
        _MainTex ("Base (RGB)", 2D) = "white" { }
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        CGPROGRAM
        #pragma surface surf Lambert

        struct Input
        {
            float2 uv_MainTex;
        };

        fixed4 _Color;
        sampler2D _MainTex;

        void surf(Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }

    FallBack "Diffuse"
}
