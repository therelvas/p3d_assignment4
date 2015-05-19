Shader "Multiple Lights Per-Pixel Shading" {
   Properties {
      _Color ("Diffuse Material Color", Color) = (1,1,1,1) 
      _SpecColor ("Specular Material Color", Color) = (1,1,1,1) 
      _Shininess ("Shininess", Float) = 10
   }
   
   SubShader {
      Pass {	
        Tags { "LightMode" = "ForwardBase" } 
        // pass for ambient light and first light source
 
        GLSLPROGRAM
 
        // User-specified properties
        uniform vec4 _Color; 
        uniform vec4 _SpecColor; 
        uniform float _Shininess;
 
 		uniform mat4 _Object2World; // model matrix
        uniform mat4 _World2Object; // inverse model matrix
 
 		uniform vec3 _WorldSpaceCameraPos;
        uniform vec4 _WorldSpaceLightPos0; // direction to or position of light source
        uniform vec4 _LightColor0; // color of light source (from "Lighting.cginc")
 	
 		//Data out/in
        varying vec4 dataPosition; 
        varying vec3 dataNormal;
        
        #ifdef VERTEX
 
        void main()
        {				
        	//dataPosition = gl_ModelViewMatrix * gl_Vertex;
        	dataPosition = _Object2World * gl_Vertex;
        	//dataNormal = normalize(vec3(vec4(gl_Normal, 0.0) * _World2Object));
          	dataNormal = normalize(gl_NormalMatrix * gl_Normal);
 
        	gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;
        }
 
        #endif
 
        #ifdef FRAGMENT
 
        void main()
        {
    		mat4 viewMatrix = gl_ModelViewMatrix * _World2Object;
         	vec4 EyeSpaceLightPos = viewMatrix * _WorldSpaceLightPos0;
         
            vec3 n = normalize(dataNormal);
            //vec3 e = normalize(_WorldSpaceCameraPos - vec3(dataPosition));
            vec3 e = normalize(-vec3(dataPosition));
            
            vec3 l = vec3(0.0, 0.0, 0.0); // Light direction
            vec3 h = vec3(0.0, 0.0, 0.0); // Half vector
            
            float intensity;
            float attenuation;
 
            if (EyeSpaceLightPos.w == 0.0) // Directional light?
            {
               attenuation = 1.0; // No attenuation
               //l = normalize(vec3(_WorldSpaceLightPos0));
               l = normalize(vec3(EyeSpaceLightPos));
            } 
            else // Point or Spotlight
            {
            	vec3 vertexToLightSource = vec3(EyeSpaceLightPos - dataPosition);
            	//vec3 vertexToLightSource = vec3(_WorldSpaceLightPos0 - dataPosition);
               	float distance = length(vertexToLightSource);
               	attenuation = 1.0 / distance; // Linear attenuation 
               	l = normalize(vertexToLightSource);
            }
 
 			intensity = max(dot(n, l), 0.0);
            vec3 ambientLighting = vec3(gl_LightModel.ambient) * vec3(_Color);
 
            vec3 diffuseReflection = attenuation * vec3(_LightColor0) * vec3(_Color) * intensity;
            vec3 specularReflection = vec3(0.0, 0.0, 0.0); 
            
            h = normalize(l + e); // Half vector
            
           	if (intensity > 0.0) 
           	{
           		specularReflection = attenuation * vec3(_LightColor0) * vec3(_SpecColor) * pow(max(0.0, dot(reflect(-l, n), e)), _Shininess);
                //specularReflection = attenuation * vec3(_LightColor0) * vec3(_SpecColor) * pow(max(0.0, dot(reflect(-l, n), h)), _Shininess);//pow(max(dot(h, n), 0.0), _Shininess);
            }
 
            gl_FragColor = vec4(ambientLighting + diffuseReflection + specularReflection, 1.0);
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
         uniform vec4 _Color; 
         uniform vec4 _SpecColor; 
         uniform float _Shininess;
         
         uniform mat4 _Object2World; // model matrix
         uniform mat4 _World2Object; // inverse model matrix
 
 		 uniform vec3 _WorldSpaceCameraPos;
         uniform vec4 _WorldSpaceLightPos0; // direction to or position of light source
         uniform vec4 _LightColor0; // color of light source (from "Lighting.cginc")
 	
 		 //Data out/in
         varying vec4 dataPosition; 
         varying vec3 dataNormal;
         
         #ifdef VERTEX
 
         void main()
         {			
         	//dataPosition = gl_ModelViewMatrix * gl_Vertex;
        	dataPosition = _Object2World * gl_Vertex;
          	//dataNormal = normalize(vec3(vec4(gl_Normal, 0.0) * _World2Object));
            dataNormal = normalize(gl_NormalMatrix * gl_Normal);
 
            gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;
         }
 
         #endif
 
         #ifdef FRAGMENT
 
         void main()
         {
         	mat4 viewMatrix = gl_ModelViewMatrix * _World2Object;
         	vec4 EyeSpaceLightPos = viewMatrix * _WorldSpaceLightPos0;
         
            vec3 n = normalize(dataNormal);
            //vec3 e = normalize(_WorldSpaceCameraPos - vec3(dataPosition));
            vec3 e = normalize(-vec3(dataPosition));
            
            vec3 l; // Light direction
            vec3 h; // Half vector
            
            float intensity;
            float attenuation;
 
            if (0.0 == EyeSpaceLightPos.w) // Directional light?
            {
            	attenuation = 1.0; // No attenuation
               	//l = normalize(vec3(_WorldSpaceLightPos0));
              	l = normalize(vec3(EyeSpaceLightPos));
            } 
            else // Point or Spotlight
            {
            	vec3 vertexToLightSource = vec3(EyeSpaceLightPos - dataPosition);
            	//vec3 vertexToLightSource = vec3(_WorldSpaceLightPos0 - dataPosition);
               	float distance = length(vertexToLightSource);
               	attenuation = 1.0 / distance; // Linear attenuation 
               	l = normalize(vertexToLightSource);
            }
 
 			intensity = max(dot(n, l), 0.0);
          
            vec3 diffuseReflection = attenuation * vec3(_LightColor0) * vec3(_Color) * intensity;
            vec3 specularReflection = vec3(0.0);
            
            h = normalize(l + e);
            
            if (intensity > 0.0) 
            {
            	specularReflection = attenuation * vec3(_LightColor0) * vec3(_SpecColor) * pow(max(0.0, dot(reflect(-l, n), e)), _Shininess);
                //specularReflection = attenuation * vec3(_LightColor0) * vec3(_SpecColor) * pow(max(0.0, dot(reflect(-l, n), h)), _Shininess);//pow(max(dot(h, n), 0.0), _Shininess);
            }
            gl_FragColor = vec4(diffuseReflection + specularReflection, 1.0);
         }
 
         #endif
 
         ENDGLSL
      }
   } 
   Fallback "Specular"
}
