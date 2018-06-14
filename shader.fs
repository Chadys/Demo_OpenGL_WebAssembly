#version 300 es
precision mediump float;

out vec4 FragColor;

in vec3 ourColor;

uniform float timeVar;

void main()
{
    FragColor = vec4(ourColor * vec3(timeVar), 1.0);
}

