Shader "Custom/Flutter" {

	Properties {
		_Color ("color", Color) = (0.5,0.5,0.5,0.5)
		_MainTex ("Particle Texture", 2D) = "white" {}
		_N3D ("noise 3d", 3D) = "gray"{}
		_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
	}
 
	CGINCLUDE

	#include "UnityCG.cginc"

	sampler2D _MainTex,_GroundTex;
    sampler3D _N3D;
    fixed4 _Color;
    uniform float _Cutoff;


    struct v2f {
        float4 pos : SV_POSITION;
        float2 sUV : TEXCOORD1;
        fixed4 color : COLOR;
        float2 texcoord : TEXCOORD0;
    };


    v2f vert (appdata_full v) {
        half4 wPos = mul(_Object2World, v.vertex);
        wPos.z /= 5;
        half kazeX = tex3Dlod(_N3D,  wPos / 15 + half4( _Time.x * 0.8,  _Time.x * 0.8, 0, 0)).w - 0.5;
        half kazeY = tex3Dlod(_N3D, -wPos / 20 + half4(-_Time.x * 0.6, -_Time.x * 0.7, 0, 0)).w - 0.5;
        v.vertex.xz += half2(kazeX, kazeY) * v.texcoord.y;
        v2f o;
        o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
        o.sUV = o.pos.xy/o.pos.w/2+0.5;
        o.color = v.color * _Color;
        o.texcoord = v.texcoord;
        return o;
    }
  

	fixed4 frag (v2f i) : COLOR {
		i.sUV.y = 1-i.sUV.y;
		fixed4 c = tex2D(_MainTex, i.texcoord);
		if(c.a < _Cutoff)discard;
		return c;
    }

	ENDCG
	
	SubShader {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" "IgnoreProjector"="true" "PreviewType"="plane" "CanUseSpriteAtlas"="True"}

		LOD 200

		cull off
		Lighting Off
		Blend One OneMinusSrcAlpha

		Pass {
            CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma fragmentoption ARB_precision_hint_fastest
			#pragma target 3.0
			#pragma glsl

			ENDCG 
		}
	}

}