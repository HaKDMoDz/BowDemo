Shader "BucketOfPixels/RampedTexture" {
	Properties {
		_EmissiveColor ("Emmissive Color", Color) = (1,1,1,1)
		_AmbientColor ("Ambient Color", Color) = (1,1,1,1)
		_MySliderValue ("This is a Slider", Range(0,10)) = 2.5
		_RampTex ("Ramp Texture", 2D) = "white"
	}
	SubShader 
	{
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		

		CGPROGRAM
		#pragma surface surf RampedTexture


		float4 _EmissiveColor;
		float4 _AmbientColor;
		float _MySliderValue;
		sampler _RampTex;

		struct Input {
			float2 uv_MainTex;
		};

		inline float4 LightingRampedTexture (SurfaceOutput s, fixed3 lightDir, fixed atten)
		{
			
			float difLight = dot (s.Normal, lightDir);
			float hLambert = difLight * 0.5 + 0.5;
			float3 ramp = tex2D(_RampTex, float2(hLambert)).rgb;

			float4 col;
			col.rgb = s.Albedo * _LightColor0.rgb * ramp;
			col.a = s.Alpha;
			return col;
		}

		void surf (Input IN, inout SurfaceOutput o) 
		{

			float4 c; 

			c = pow((_EmissiveColor + _AmbientColor), _MySliderValue);
			
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
