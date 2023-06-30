﻿using Microsoft.Extensions.Primitives;
using Smidge.Models;
using System.Collections.Generic;

namespace Smidge
{
    /// <summary>
    /// Utility class for working with current requests and path info
    /// </summary>
    public interface IRequestHelper
    {
        /// <summary>
        /// Converts a virtual (relative) path to an application absolute path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        string Content(string path);

        /// <summary>
        /// Converts a virtual (relative) path to an application absolute path.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        string Content(IWebFile file);

        /// <summary>
        /// Returns the compression type for the current request
        /// </summary>
        /// <returns></returns>
        CompressionType GetClientCompression(IDictionary<string, StringValues> headers);

        bool IsExternalRequestPath(string path);
    }
}