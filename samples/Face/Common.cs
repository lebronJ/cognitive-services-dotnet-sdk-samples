﻿namespace Microsoft.Azure.CognitiveServices.Samples.Face
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Azure.CognitiveServices.Vision.Face;
    using Microsoft.Azure.CognitiveServices.Vision.Face.Models;

    internal static class Common
    {
        // Detect faces from image url for recognition purpose.
        // Parameter `returnFaceId` of `DetectWithStreamAsync` must be set to `true` (by default) for recognition purpose.
        // The field `faceId` in returned `DetectedFace`s will be used in Face - Identify, Face - Verify, and Face - Find Similar.
        // It will expire 24 hours after the detection call.
        internal static async Task<List<DetectedFace>> DetectedFace(IFaceClient faceClient, string imageUrl)
        {
            // Detect faces from image stream.
            IList<DetectedFace> detectedFaces = await faceClient.Face.DetectWithUrlAsync(imageUrl);
            if (detectedFaces == null || detectedFaces.Count == 0)
            {
                throw new Exception($"No face detected from image `{imageUrl}`.");
            }

            Console.WriteLine($"{detectedFaces.Count} faces detected from image `{imageUrl}`.");
            if (detectedFaces[0].FaceId == null)
            {
                throw new Exception("Parameter `returnFaceId` of `DetectWithStreamAsync` must be set to `true` (by default) for recognition purpose.");
            }

            return detectedFaces.ToList();
        }
    }
}
