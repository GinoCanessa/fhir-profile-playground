// <copyright file="UsCoreRaceWrapper.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
//     Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;

namespace fhir_profile_playground_cli
{
    /// <summary>A core race wrapper.</summary>
    public class UsCoreRaceWrapper
    {
        /// <summary>Canonical URL of the extension.</summary>
        public const string ExtensionUrl = "http://hl7.org/fhir/us/core/StructureDefinition/us-core-race";

        /// <summary>Name of the extension.</summary>
        public const string ExtensionName = "USCoreRaceExtension";

        /// <summary>The extension.</summary>
        private Extension _extension;

        /// <summary>
        /// Initializes a new instance of the fhir_profile_playground_cli.UsCoreRaceWrapper class.
        /// </summary>
        /// <param name="extension">The extension.</param>
        public UsCoreRaceWrapper(Extension extension)
        {
            if (extension.Url != ExtensionUrl)
            {
                throw new InvalidCastException($"Cannot convert {extension.Url} to {ExtensionUrl}");
            }

            _extension = extension;
        }
    }
}
