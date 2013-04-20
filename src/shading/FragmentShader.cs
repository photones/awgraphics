﻿using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace AWGraphics
{
    /// <summary>
    /// This class represents a GLSL fragment shader
    /// </summary>
    public class FragmentShader : Shader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FragmentShader"/> class.
        /// </summary>
        /// <param name="filename">The file to load the shader from.</param>
        public FragmentShader(string filename) : base(ShaderType.FragmentShader, filename) { }
    }
}
