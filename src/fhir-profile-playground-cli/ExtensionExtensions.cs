// <copyright file="ExtensionExtensions.cs" company="Microsoft Corporation">
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
    /// <summary>An extension extensions.</summary>
    public static class ExtensionExtensions
    {
        /// <summary>
        /// An Extension extension method that converts an extension to the us core race.
        /// </summary>
        /// <param name="extension">The extension to act on.</param>
        /// <returns>An UsCoreRaceWrapper.</returns>
        public static UsCoreRaceWrapper AsUsCoreRace(this Extension extension)
        {
            return new UsCoreRaceWrapper(extension);
        }

        /// <summary>
        /// An Extension extension method that converts an extension to the us core race omb category.
        /// </summary>
        /// <param name="extension">The extension to act on.</param>
        /// <returns>An UsCoreRace.OmbCategory.</returns>
        public static UsCoreRaceWrapper.OmbCategory AsUsCoreRaceOmbCategory(this Extension extension)
        {
            return new UsCoreRaceWrapper.OmbCategory(extension);
        }

    }
}
