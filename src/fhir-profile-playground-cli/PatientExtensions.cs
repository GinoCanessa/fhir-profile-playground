// <copyright file="PatientExtensions.cs" company="Microsoft Corporation">
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
    /// <summary>A patient extensions.</summary>
    public static class PatientExtensions
    {
        /// <summary>
        /// A Patient extension method that converts a patient to the us core patient.
        /// </summary>
        /// <param name="patient">The patient to act on.</param>
        /// <returns>An UsCorePatientWrapper.</returns>
        public static UsCorePatientWrapper AsUsCorePatient(this Patient patient)
        {
            return new UsCorePatientWrapper(patient);
        }

        /// <summary>
        /// The PatientExtensions extension method that query if 'patient' has profile.
        /// </summary>
        /// <param name="patient">   The patient to act on.</param>
        /// <param name="profileUrl">URL of the profile.</param>
        /// <returns>True if profile, false if not.</returns>
        public static bool HasProfile(this Patient patient, string profileUrl)
        {
            if (patient == null)
            {
                return false;
            }

            try
            {
                if (patient.Meta.Profile.Contains(profileUrl))
                {
                    return true;
                }
            }
            finally
            {

            }

            return false;
        }

        /// <summary>A Patient extension method that adds a profile to 'profileUrl'.</summary>
        /// <exception cref="NullReferenceException">Thrown when a value was unexpectedly null.</exception>
        /// <param name="patient">   The patient to act on.</param>
        /// <param name="profileUrl">URL of the profile.</param>
        public static void AddProfile(this Patient patient, string profileUrl)
        {
            if (patient == null)
            {
                throw new NullReferenceException();
            }

            try
            {
                if (patient.Meta == null)
                {
                    patient.Meta = new Meta()
                    {
                        Profile = new List<string>() { profileUrl },
                    };

                    return;
                }

                if (patient.Meta.Profile == null)
                {
                    patient.Meta.Profile = new List<string>() { profileUrl };
                    return;
                }

                if (!patient.Meta.Profile.Contains(profileUrl))
                {
                    patient.Meta.Profile.Append(profileUrl);
                }
            }
            finally
            {

            }
        }

    }
}
