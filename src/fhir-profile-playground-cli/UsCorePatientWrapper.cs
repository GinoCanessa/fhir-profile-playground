// <copyright file="UsCorePatientWrapper.cs" company="Microsoft Corporation">
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
    /// <summary>A core patient wrapper.</summary>
    public class UsCorePatientWrapper
    {
        /// <summary>Canonical URL of the profile.</summary>
        public const string ProfileUrl = "http://hl7.org/fhir/us/core/StructureDefinition/us-core-patient";

        /// <summary>Name of the profile.</summary>
        public const string ProfileName = "UsCorePatientProfile";

        /// <summary>The profile title.</summary>
        public const string ProfileTitle = "US Core Patient Profile";

        /// <summary>The profile version.</summary>
        public const string ProfileVersion = "3.2.0";

        /// <summary>The patient.</summary>
        private Patient _patient;

        /// <summary>
        /// Initializes a new instance of the fhir_profile_playground_cli.UsCorePatientWrapper class.
        /// </summary>
        /// <param name="patient">The patient.</param>
        public UsCorePatientWrapper(Patient patient)
        {
            _patient = patient;
        }

        /// <summary>Gets or sets the core race.</summary>
        public IEnumerable<UsCoreRaceWrapper> UsCoreRace
        {
            get
            {
                return _patient.GetExtensions(UsCoreRaceWrapper.ExtensionUrl).Select((ext) => new UsCoreRaceWrapper(ext));
            }
            //set
            //{

            //}
        }

    }
}
