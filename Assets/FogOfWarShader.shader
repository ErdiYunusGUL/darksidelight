Shader "Unlit/FogOfWarShader"
{
    Properties
    {
        _MainTex("Main Texture", 2D) = "gray" {}
        _FogColor("Fog Color", Color) = (0, 0, 0, 0.8)
        _PlayerPosition("Player Position", Vector) = (0, 0, 0, 1)
        _RevealRadius("Reveal Radius", Float) = 5.0
    }

    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 200

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 worldPos : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _PlayerPosition;
            float _RevealRadius;
            float4 _FogColor;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                // Karakterin bulunduðu pozisyonla mesafeyi hesapla
                float dist = distance(i.worldPos, _PlayerPosition.xyz);
                
                // Mesafeye baðlý olarak saydamlýk ayarla
                float alpha = smoothstep(_RevealRadius, _RevealRadius - 1.0, dist);
                return lerp(tex2D(_MainTex, i.uv), _FogColor, alpha);
            }
            ENDCG
        }
    }
}
