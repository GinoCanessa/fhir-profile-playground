// <copyright file="Program.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
//     Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace fhir_profile_playground_cli
{
    /// <summary>A program.</summary>
    public static class Program
    {
        /// <summary>Main entry-point for this application.</summary>
        /// <param name="fhirJsonFilename">Full path and filename to a FHIR JSON file to load.</param>
        public static int Main(
            string fhirJsonFilename)
        {
            if (string.IsNullOrEmpty(fhirJsonFilename))
            {
                fhirJsonFilename = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\..\\..\\data\\US-Core-Patient-example.json");
            }

            fhirJsonFilename = Path.GetFullPath(fhirJsonFilename);

            if (!File.Exists(fhirJsonFilename))
            {
                Console.WriteLine($"File: {fhirJsonFilename} not found!");
                return -1;
            }

            FhirJsonParser fhirJsonParser = new FhirJsonParser(new ParserSettings()
            {
                AcceptUnknownMembers = true,
                AllowUnrecognizedEnums = true,
                DisallowXsiAttributesOnRoot = false,
                PermissiveParsing = true
            });

            Console.WriteLine($"Loading: {fhirJsonFilename}...");

            if (!TryParsePatient(fhirJsonParser, fhirJsonFilename))
            {
                return -1;
            }

            // success!

            return 0;
        }

        /// <summary>Attempts to parse patient.</summary>
        /// <param name="fhirJsonParser">  The FHIR JSON parser.</param>
        /// <param name="fhirJsonFilename">Full path and filename to a FHIR JSON file to load.</param>
        /// <returns>True if it succeeds, false if it fails.</returns>
        private static bool TryParsePatient(FhirJsonParser fhirJsonParser, string fhirJsonFilename)
        {
            try
            {
                Patient patient = fhirJsonParser.Parse<Patient>(File.ReadAllText(fhirJsonFilename));

                Console.WriteLine($"Loaded Patient/{patient.Id}");

                if (patient.HasProfile(UsCorePatientWrapper.ProfileUrl))
                {
                    Console.WriteLine($"Profile: {UsCorePatientWrapper.ProfileUrl} found on the patient!");
                }

                UsCorePatientWrapper usCorePatient = patient.AsUsCorePatient();


                // check the profile of this patient
                //if (patient.Meta.Profile.Contains(UsCorePatient.ProfileUrl))
                //{
                //    Console.WriteLine($"Profile: {UsCorePatient.ProfileUrl} found on the patient!");
                //}

                foreach (UsCoreRaceWrapper race in usCorePatient.UsCoreRace)
                {
                    if (race.HasOmbCategory())
                    {
                        foreach (UsCoreRaceWrapper.OmbCategory ombCategory in race.OmbCategories)
                        {
                            Console.WriteLine(
                                $"Found UsCoreRace.ombCategory:" +
                                $" {ombCategory.Value.Display}" +
                                $" ({ombCategory.Value.System}#{ombCategory.Value.Code})");
                        }
                    }

                    //if (race.Extension != null)
                    //{
                    //    foreach (Extension subExt in race.Extension)
                    //    {
                    //        Console.WriteLine($"Found UsCoreRace.{subExt.Url}: {subExt.Value.ToString()}");
                    //    }
                    //}
                }

                //// check for race extension
                //if (patient.Extension != null)
                //{
                //    IEnumerable<Extension> raceExtensions = patient.GetExtensions(UsCoreRaceExtension.ExtensionUrl);

                //    if (raceExtensions.Any())
                //    {
                //        foreach (Extension ext in raceExtensions)
                //        {
                //            if (ext.Extension != null)
                //            {
                //                foreach (Extension subExt in ext.Extension)
                //                {
                //                    Console.WriteLine($"Found UsCoreRace.{subExt.Url}: {subExt.Value.ToString()}");
                //                }
                //            }
                //        }
                //    }
                //}

            }
            catch (Exception ex)
            {
                Console.WriteLine($"TryParsePatient <<< caught exception: {ex.Message}");
                return false;
            }

            return true;
        }
    }
}
