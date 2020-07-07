using System;
using OpenToolkit.Graphics.OpenGL;

namespace amulware.Graphics
{
    public interface IRenderable
    {
        void ConfigureBoundVertexArray(ShaderProgram program);
        void Render();
    }

    public static class Renderable
    {
        public static IRenderable ForVertices<T>(Buffer<T> vertexBuffer, PrimitiveType primitiveType)
            where T : struct, IVertexData
        {
            return new WithVertices<T>(vertexBuffer, primitiveType);
        }

        public static IRenderable ForVerticesAndIndices<T>(Buffer<T> vertexBuffer, Buffer<byte> indexBuffer, PrimitiveType primitiveType)
            where T : struct, IVertexData
        {
            return withVerticesAndIndices(vertexBuffer, indexBuffer, primitiveType);
        }

        public static IRenderable ForVerticesAndIndices<T>(Buffer<T> vertexBuffer, Buffer<uint> indexBuffer, PrimitiveType primitiveType)
            where T : struct, IVertexData
        {
            return withVerticesAndIndices(vertexBuffer, indexBuffer, primitiveType);
        }

        public static IRenderable ForVerticesAndIndices<T>(Buffer<T> vertexBuffer, Buffer<ushort> indexBuffer, PrimitiveType primitiveType)
            where T : struct, IVertexData
        {
            return withVerticesAndIndices(vertexBuffer, indexBuffer, primitiveType);
        }

        private static WithVerticesAndIndices<TVertex, TIndex> withVerticesAndIndices<TVertex, TIndex>(
            Buffer<TVertex> vertexBuffer, Buffer<TIndex> indexBuffer, PrimitiveType primitiveType)
            where TVertex : struct, IVertexData
            where TIndex : struct
        {
            return new WithVerticesAndIndices<TVertex, TIndex>(vertexBuffer, indexBuffer, primitiveType);
        }

        private class WithVertices<TVertex> : IRenderable
            where TVertex : struct, IVertexData
        {
            private readonly Buffer<TVertex> vertexBuffer;
            private readonly PrimitiveType primitiveType;

            public WithVertices(Buffer<TVertex> vertexBuffer, PrimitiveType primitiveType)
            {
                this.vertexBuffer = vertexBuffer;
                this.primitiveType = primitiveType;
            }

            public void ConfigureBoundVertexArray(ShaderProgram program)
            {
                vertexBuffer.Bind(BufferTarget.ArrayBuffer);
                VertexData.SetAttributes<TVertex>(program);
            }

            public void Render()
            {
                GL.DrawArrays(primitiveType, 0, vertexBuffer.Count);
            }
        }

        private class WithVerticesAndIndices<TVertex, TIndex> : IRenderable
            where TVertex : struct, IVertexData
            where TIndex : struct
        {
            private static readonly DrawElementsType drawElementsType =
                default(TIndex) switch
                {
                    byte _ => DrawElementsType.UnsignedByte,
                    ushort _ => DrawElementsType.UnsignedShort,
                    uint _ => DrawElementsType.UnsignedInt,
                    _ => throw new NotSupportedException()
                };

            private readonly Buffer<TVertex> vertexBuffer;
            private readonly Buffer<TIndex> indexBuffer;
            private readonly PrimitiveType primitiveType;

            public WithVerticesAndIndices(Buffer<TVertex> vertexBuffer, Buffer<TIndex> indexBuffer,
                PrimitiveType primitiveType)
            {
                this.vertexBuffer = vertexBuffer;
                this.indexBuffer = indexBuffer;
                this.primitiveType = primitiveType;
            }

            public void ConfigureBoundVertexArray(ShaderProgram program)
            {
                vertexBuffer.Bind(BufferTarget.ArrayBuffer);
                VertexData.SetAttributes<TVertex>(program);
                // todo: bind index buffer
            }

            public void Render()
            {
                GL.DrawElements(primitiveType, indexBuffer.Count, drawElementsType, 0);
            }
        }
    }
}
