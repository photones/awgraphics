﻿
namespace amulware.Graphics
{
    /// <summary>
    /// This interface must be implemented by any custom vertex data.
    /// </summary>
    public interface IVertexData
    {
        /// <summary>
        /// Returns the vertex' <see cref="VertexAttributes"/>
        /// </summary>
        /// <returns>Array of <see cref="VertexAttribute"/></returns>
        VertexAttribute[] VertexAttributes();

        /// <summary>
        /// This method returns the size of the vertex data struct in bytes
        /// </summary>
        /// <returns>Struct's size in bytes</returns>
        int Size();
    }
}
