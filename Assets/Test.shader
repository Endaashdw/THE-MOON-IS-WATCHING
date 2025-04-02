Shader "Custom/Test"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {} // Base texture
        _ScanlineIntensity ("Scanline Intensity", Float) = 1.0 // Scan line strength
        _NoiseIntensity ("Noise Intensity", Float) = 0.5 // Noise level
        _Alpha ("Alpha Transparency", Range(0, 1)) = 0.5 // Transparency control
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" "IgnoreProjector"="True" "Canvas"="UI" }

        // Enable alpha blending
        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float _ScanlineIntensity;
            float _NoiseIntensity;
            float _Alpha;

            struct appdata_t
            {
                float4 vertex : POSITION; // Vertex position
                float2 texcoord : TEXCOORD0; // Texture coordinates
            };

            struct v2f
            {
                float4 vertex : SV_POSITION; // Clip space position
                float2 texcoord : TEXCOORD0; // Texture coordinates
            };

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex); // Convert vertex to clip space
                o.texcoord = v.texcoord; // Pass texture coordinates to fragment shader
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Sample the texture
                float4 color = tex2D(_MainTex, i.texcoord);

                // Add scan lines
                float scanLines = sin(i.texcoord.y * _ScanlineIntensity * 500.0) * 0.1;

                // Add noise
                float noise = frac(sin(dot(i.texcoord, float2(12.9898, 78.233))) * 43758.5453) * _NoiseIntensity;

                // Combine effects with transparency
                return float4(color.rgb + scanLines + noise, _Alpha);
            }
            ENDCG
        }
    }
}
