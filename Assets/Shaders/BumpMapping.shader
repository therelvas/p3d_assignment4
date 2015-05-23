Shader "Bump Mapping Assigment 4" {
	Properties {
	  _BaseMap ("Base Map", 2D) = "base" {}
	  _BumpMap ("Normal Map", 2D) = "bump" {}
      _Color ("Diffuse Material Color", Color) = (1,1,1,1) 
      _SpecColor ("Specular Material Color", Color) = (1,1,1,1) 
      _Shininess ("Shininess", Float) = 16
   }
   
   SubShader {
      Pass {	
        Tags { "LightMode" = "ForwardBase" } 
        // pass for ambient light and first light source
 
        GLSLPROGRAM
 
        // User-specified properties
        uniform sampler2D _BaseMap;
        uniform sampler2D _BumpMap;
        uniform vec4 _BumpMap_ST;
        
        uniform vec4 _Color; 
        uniform vec4 _SpecColor; 
        uniform float _Shininess;
 
 		uniform mat4 _Object2World; // model matrix
        uniform mat4 _World2Object; // inverse model matrix
 
 		uniform vec3 _WorldSpaceCameraPos;
        uniform vec4 _WorldSpaceLightPos0; // direction to or position of light source
        uniform vec4 _LightColor0; // color of light source (from "Lighting.cginc")
 	
 		//Data out/in
       	varying vec3 dataHalfVec;
       	varying vec3 dataLightVec;
        varying vec4 dataTexCoord;
        varying vec3 eye;
        
        #ifdef VERTEX
        
        attribute vec4 Tangent;
 
        void main()
        {	
        	mat4 viewMatrix = gl_ModelViewMatrix * _World2Object;
         	vec4 eyeSpaceLightPos = viewMatrix * _WorldSpaceLightPos0;
         
        	dataTexCoord = gl_MultiTexCoord0;
        	
        	// Building the TBN matrix
        	vec3 n = normalize(gl_NormalMatrix * gl_Normal);
        	vec3 t = normalize(gl_NormalMatrix * Tangent.xyz);
        	vec3 b = Tangent.w * cross(n, t);
        	
        	eye = vec3(gl_ModelViewMatrix * gl_Vertex);
        	vec3 lightDir = normalize(eyeSpaceLightPos.xyz - eye);
        					
        	// Transform light vectors
        	vec3 v;
        	v.x = dot(lightDir, t);
        	v.y = dot(lightDir, b);
        	v.z = dot(lightDir, n);
        	dataLightVec = normalize(v);
        					
        	vec3 halfVector = normalize(lightDir - eye);      	
        	v.x = dot(halfVector, t);
        	v.y = dot(halfVector, b);
        	v.z = dot(halfVector, n);
        	dataHalfVec = normalize(v);				
        												
        	gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;
        }
 
        #endif
 
        #ifdef FRAGMENT
 
        void main()
        {
        	vec4 encodedNormal = texture2D(_BumpMap, _BumpMap_ST.xy * dataTexCoord.xy + _BumpMap_ST.zw);
            vec3 n = vec3(2.0 * encodedNormal.ab - vec2(1.0), 0.0);
            n.z = sqrt(1.0 - dot(n, n));
            n = normalize(n);
            
            vec3 e = normalize(-vec3(eye));
        	
        	float attenuation;
        	float intensity = max(dot(dataLightVec, n), 0.0);
        	
        	vec4 specularReflection = vec4(0.0, 0.0, 0.0, 0.0);
        	vec4 ambientLighting = gl_LightModel.ambient * _Color;
            vec4 diffuseMaterial = texture2D(_BaseMap, dataTexCoord.st) * _LightColor0 * _Color * intensity;
            
           	if(intensity > 0.0) {
              	specularReflection = _LightColor0 * _SpecColor * pow(max(dot(dataHalfVec, n), 0.0) , _Shininess);  
        	}
        	
    		gl_FragColor = ambientLighting + diffuseMaterial + specularReflection;		
        }
        #endif
 
        ENDGLSL
      }
 
 	  Pass {	
      	Tags { "LightMode" = "ForwardAdd" } 
            // pass for additional light sources
        Blend One One // additive blending 
 
        GLSLPROGRAM
 
        // User-specified properties
        uniform sampler2D _BaseMap;
        uniform sampler2D _BumpMap;
        uniform vec4 _BumpMap_ST;
        
        uniform vec4 _Color; 
        uniform vec4 _SpecColor; 
        uniform float _Shininess;
 
 		uniform mat4 _Object2World; // model matrix
        uniform mat4 _World2Object; // inverse model matrix
 
 		uniform vec3 _WorldSpaceCameraPos;
        uniform vec4 _WorldSpaceLightPos0; // direction to or position of light source
        uniform vec4 _LightColor0; // color of light source (from "Lighting.cginc")
 	
 		//Data out/in
       	varying vec3 dataHalfVec;
       	varying vec3 dataLightVec;
        varying vec4 dataTexCoord;
        varying vec3 eye;
        
        #ifdef VERTEX
        
        attribute vec4 Tangent;
 
        void main()
        {	
        	mat4 viewMatrix = gl_ModelViewMatrix * _World2Object;
         	vec4 eyeSpaceLightPos = viewMatrix * _WorldSpaceLightPos0;
         
        	dataTexCoord = gl_MultiTexCoord0;
        	
        	// Building the TBN matrix
        	vec3 n = normalize(gl_NormalMatrix * gl_Normal.xyz);
        	vec3 t = normalize(gl_NormalMatrix * Tangent.xyz);
        	vec3 b = Tangent.w * cross(n, t);
        	
        	eye = vec3(gl_ModelViewMatrix * gl_Vertex);
        	vec3 lightDir = normalize(eyeSpaceLightPos.xyz - eye);
        					
        	// Transform light vectors
        	vec3 v;
        	v.x = dot(lightDir, t);
        	v.y = dot(lightDir, b);
        	v.z = dot(lightDir, n);
        	dataLightVec = normalize(v);
        					
        	vec3 halfVector = normalize(lightDir - eye);      	
        	v.x = dot(halfVector, t);
        	v.y = dot(halfVector, b);
        	v.z = dot(halfVector, n);
        	dataHalfVec = normalize(v);				
        													
        	gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;
        }
 
        #endif
 
        #ifdef FRAGMENT
 
        void main()
        {
        	vec4 encodedNormal = texture2D(_BumpMap, _BumpMap_ST.xy * dataTexCoord.xy + _BumpMap_ST.zw);
            vec3 n = vec3(2.0 * encodedNormal.ab - vec2(1.0), 0.0);
            n.z = sqrt(1.0 - dot(n, n));
            n = normalize(n);
            
            vec3 e = normalize(-vec3(eye));
        	
        	float attenuation;
        	float intensity = max(dot(dataLightVec, n), 0.0);
        	
        	vec4 specularReflection = vec4(0.0, 0.0, 0.0, 0.0);
        	vec4 ambientLighting = gl_LightModel.ambient * _Color;
            vec4 diffuseMaterial = texture2D(_BaseMap, dataTexCoord.st) * _LightColor0 * _Color * intensity;
            
           	if(intensity > 0.0) {
              	specularReflection = _LightColor0 * _SpecColor * pow(max(dot(dataHalfVec, n), 0.0) , _Shininess);  
        	}
        	
    		gl_FragColor = diffuseMaterial + specularReflection;		
         }
 
         #endif
 
         ENDGLSL
      }
   } 
   Fallback "Bumped Specular"
}
