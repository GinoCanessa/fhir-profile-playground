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

        /// <summary>Query if this object has omb category.</summary>
        /// <returns>True if omb category, false if not.</returns>
        public bool HasOmbCategory()
        {
            return _extension.Extension.Any(ext => ext.Url == OmbCategory.ExtensionUrl);
        }

        /// <summary>Gets the categories the omb belongs to.</summary>
        public IEnumerable<OmbCategory> OmbCategories
        {
            get
            {
                if (_extension.Extension == null)
                {
                    return new List<OmbCategory>();
                }

                return _extension.Extension
                    .Where(ext => ext.Url == OmbCategory.ExtensionUrl)
                    .Select((ext) => new OmbCategory(ext));
            }
        }

        /// <summary>An omb category.</summary>
        public class OmbCategory
        {
            /// <summary>Canonical URL of the extension.</summary>
            public const string ExtensionUrl = "ombCategory";

            /// <summary>Name of the extension.</summary>
            public const string ExtensionName = "ombCategory";

            /// <summary>The extension.</summary>
            private Extension _extension;

            /// <summary>
            /// Initializes a new instance of the fhir_profile_playground_cli.UsCoreRace.OmbCategory
            /// class.
            /// </summary>
            /// <exception cref="InvalidCastException">Thrown when an object cannot be cast to a required
            ///  type.</exception>
            /// <param name="extension">The extension.</param>
            public OmbCategory(Extension extension)
            {
                if (extension.Url != ExtensionUrl)
                {
                    throw new InvalidCastException($"Cannot convert {extension.Url} to {ExtensionUrl}");
                }

                _extension = extension;
            }

            /// <summary>Gets the value.</summary>
            public Coding Value
            {
                get
                {
                    return _extension.Value as Coding;
                }
            }
        }
    }
}
