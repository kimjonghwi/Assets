Shader "UnlitAlpha"
{
    Properties
    {
        _Color ("Main Color", Color) = (1,1,1,1)
       // _MainTex ("Base (RGB) Alpha (A)", 2D) = "white"
        _MainTex ("Base (RGB) Transparency (A)", 2D) = "" {}
		_Cutoff ("Alpha cutoff", Range (0,1)) = 0.5
         
    }

    Category
    {
        ZWrite On
        AlphaTest Greater [_Cutoff]
        Cull Off
        Blend SrcAlpha OneMinusSrcAlpha
        SubShader
        {
            Pass
            {
                Lighting Off
                SetTexture [_MainTex]
                {
                    constantColor [_Color]
                    Combine texture * constant, texture * constant 
                } 
            }
        } 
    }
    
    
}