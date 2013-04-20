﻿using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace AWGraphics
{
    /// <summary>
    /// Light vertex data used for drawing primitives
    /// </summary>
    public struct PrimitiveVertexData : IVertexData
    {
        readonly Vector3 position; // 12 bytes
        readonly Color color; // 4 bytes

        /// <summary>
        /// Initializes a new instance of the <see cref="PrimitiveVertexData"/> struct.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="z">The z coordinate.</param>
        /// <param name="color">The color.</param>
        public PrimitiveVertexData(float x, float y, float z, Color color)
        {
            this.position.X = x;
            this.position.Y = y;
            this.position.Z = z;
            this.color = color;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PrimitiveVertexData"/> struct.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="color">The color.</param>
        public PrimitiveVertexData(Vector3 position, Color color)
        {
            this.position = position;
            this.color = color;
        }

        static private VertexAttribute[] vertexAttributes;

        static private void setVertexAttributes()
        {
            PrimitiveVertexData.vertexAttributes = new VertexAttribute[]{
                new VertexAttribute("v_position", 3, VertexAttribPointerType.Float, 16, 0),
                new VertexAttribute("v_color", 4, VertexAttribPointerType.UnsignedByte, 16, 12, true)
            };
        }

        /// <summary>
        /// Returns the vertex' <see cref="VertexAttributes" />
        /// </summary>
        /// <returns>
        /// Array of <see cref="VertexAttribute" />
        /// </returns>
        public VertexAttribute[] VertexAttributes()
        {
            if (PrimitiveVertexData.vertexAttributes == null)
                PrimitiveVertexData.setVertexAttributes();
            return PrimitiveVertexData.vertexAttributes;
        }

        /// <summary>
        /// This method returns the size of the vertex data struct in bytes
        /// </summary>
        /// <returns>
        /// Struct's size in bytes
        /// </returns>
        public int Size()
        {
            return 16;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this vertex.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this vertex.
        /// </returns>
        public override string ToString()
        {
            return this.position.ToString() + ",\t" + this.color.ToString();
        }
    }
}
