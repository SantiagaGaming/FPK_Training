Shader "AOS/FadeShader"
{
    Properties
    {
        _Color ("Main Color", COLOR) = (1,1,1,1)
    }

    SubShader
    {
        Tags
        {
            "Queue"="Overlay+1" "IgnoreProjector"="True" "RenderType"="Transparent"
        }

        ZTest Always
        ZWrite Off
        Lighting Off
        Fog
        {
            Mode Off
        }

        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            Color [_Color]
        }
    }
}