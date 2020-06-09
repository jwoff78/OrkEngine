//
// VorbisFormat.cs
//
// Copyright (C) 2019 OpenTK
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//

using AdvancedDLSupport;
using OrkCore.Core.Extensions;
using OrkCore.Core.Loader;

namespace OrkCore.OpenAL.Extensions.EXT.VorbisFormat
{
    /// <summary>
    /// Exposes the multi-channel buffers extension by Creative Labs.
    /// </summary>
    [Extension("AL_EXT_vorbis")]
    public abstract class VorbisFormat : FormatExtensionBase<VorbisBufferFormat>, IVorbisFormat
    {
        /// <inheritdoc cref="ExtensionBase"/>
        protected VorbisFormat(string path, ImplementationOptions options)
            : base(path, options)
        {
        }
    }
}
