﻿//----------------------------------------------------------------------------
//  Copyright (C) 2004-2018 by EMGU Corporation. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Emgu.CV;
using Emgu.Util;

namespace Emgu.CV.Features2D
{
    /// <summary>
    /// The match distance type
    /// </summary>
    public enum DistanceType
    {
        /// <summary>
        /// 
        /// </summary>
        Inf = 1,

        /// <summary>
        /// Manhattan distance (city block distance)
        /// </summary>
        L1 = 2,

        /// <summary>
        /// Squared Euclidean distance
        /// </summary>
        L2 = 4,

        /// <summary>
        /// Euclidean distance
        /// </summary>
        L2Sqr = 5,

        /// <summary>
        /// Hamming distance functor - counts the bit differences between two strings - useful for the Brief descriptor, 
        /// bit count of A exclusive XOR'ed with B. 
        /// </summary>
        Hamming = 6,

        /// <summary>
        /// Hamming distance functor - counts the bit differences between two strings - useful for the Brief descriptor, 
        /// bit count of A exclusive XOR'ed with B. 
        /// </summary>
        Hamming2 = 7, //TODO: update the documentation
                      /*
                      TypeMask = 7, 
                      Relative = 8, 
                      MinMax = 32 */
    }

    /// <summary>
    /// Wrapped BFMatcher
    /// </summary>
    public class BFMatcher : DescriptorMatcher
    {
        /// <summary>
        /// Create a BFMatcher of the specific distance type
        /// </summary>
        /// <param name="distanceType">The distance type</param>
        /// <param name="crossCheck">Specify whether or not cross check is needed. Use false for default.</param>
        public BFMatcher(DistanceType distanceType, bool crossCheck = false)
        {
            _ptr = CvInvoke.cveBFMatcherCreate(distanceType, crossCheck, ref _descriptorMatcherPtr);
        }

        /// <summary>
        /// Release the unmanaged resource associated with the BFMatcher
        /// </summary>
        protected override void DisposeObject()
        {
            if (IntPtr.Zero != _ptr)
                CvInvoke.cveBFMatcherRelease(ref _ptr);
            base.DisposeObject();
        }
    }
}

namespace Emgu.CV
{

    public static partial class CvInvoke
    {
        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
        internal extern static IntPtr cveBFMatcherCreate(
           Features2D.DistanceType distanceType,
           [MarshalAs(CvInvoke.BoolMarshalType)]
         bool crossCheck,
           ref IntPtr dmPtr);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
        internal extern static void cveBFMatcherRelease(ref IntPtr matcher);
    }
}
