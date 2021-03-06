﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
//using Vannatech.CoreAudio.Interfaces;
//using Vannatech.CoreAudio.Enumerations;

namespace Wale.CoreAudio
{/*
    public class MasterDevice
    {
        public float MasterPeak { get => GetMasterPeak(); }
        public float MasterVolume { get => GetMasterVolume(); set => SetMasterVolume(value); }

        public void GetMasterDevice()
        {
            MasterPeakObject = GetMasterPeakObject();
            MasterVolumeObject = GetMasterVolumeObject();
        }

        public MasterDevice() { GetMasterDevice(); }
        //Dispose
        private bool disposed = false;
        ~MasterDevice() { Dispose(false); }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                }
                if (MasterPeakObject != null) Marshal.ReleaseComObject(MasterPeakObject);
                if (MasterVolumeObject != null) Marshal.ReleaseComObject(MasterVolumeObject);
                disposed = true;
            }
        }

        private float GetMasterPeak()
        {
            try
            {
                if (MasterPeakObject == null) return -1;

                uint peakCount;
                MasterPeakObject.GetMeteringChannelCount(out peakCount);
                if (peakCount <= 0) return -2;

                float peakLevel;
                MasterPeakObject.GetPeakValue(out peakLevel);
                return peakLevel;
            }
            finally { }
        }
        private float GetMasterVolume()
        {
            try
            {
                if (MasterVolumeObject == null) return -1;

                float volumeLevel;
                MasterVolumeObject.GetMasterVolumeLevelScalar(out volumeLevel);
                return volumeLevel;
            }
            finally { }
        }
        private void SetMasterVolume(float newLevel)
        {
            try
            {
                if (MasterVolumeObject == null) return;

                MasterVolumeObject.SetMasterVolumeLevelScalar(newLevel, Guid.Empty);
            }
            finally { }
        }

        private IAudioMeterInformation MasterPeakObject = null;
        private IAudioEndpointVolume MasterVolumeObject = null;

        private IAudioMeterInformation GetMasterPeakObject()
        {
            IMMDeviceEnumerator deviceEnumerator = null;
            IMMDevice speakers = null;
            //lock (Locker.MMDeviceEnumerator)
            //{
                try
                {
                    // get the speakers (1st render + multimedia) device
                    deviceEnumerator = (IMMDeviceEnumerator)(new MMDeviceEnumerator());
                    deviceEnumerator.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia, out speakers);
                }
                finally
                {
                    if (deviceEnumerator != null) Marshal.ReleaseComObject(deviceEnumerator);
                }
            //}
            try
            {
                Guid IID_IAudioEndpointPeak = typeof(IAudioMeterInformation).GUID;
                object o;
                speakers.Activate(IID_IAudioEndpointPeak, 0, IntPtr.Zero, out o);
                IAudioMeterInformation masterPeak = (IAudioMeterInformation)o;

                return masterPeak;
            }
            finally
            {
                if (speakers != null) Marshal.ReleaseComObject(speakers);
            }
        }
        private IAudioEndpointVolume GetMasterVolumeObject()
        {
            IMMDeviceEnumerator deviceEnumerator = null;
            IMMDevice speakers = null;
            //lock (Locker.MMDeviceEnumerator)
            //{
                try
                {
                    // get the speakers (1st render + multimedia) device
                    deviceEnumerator = (IMMDeviceEnumerator)(new MMDeviceEnumerator());
                    deviceEnumerator.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia, out speakers);
                }
                finally
                {
                    if (deviceEnumerator != null) Marshal.ReleaseComObject(deviceEnumerator);
                }
            //}
            try
            {
                Guid IID_IAudioEndpointVolume = typeof(IAudioEndpointVolume).GUID;
                object o;
                speakers.Activate(IID_IAudioEndpointVolume, 0, IntPtr.Zero, out o);
                IAudioEndpointVolume masterVol = (IAudioEndpointVolume)o;

                return masterVol;
            }
            finally
            {
                if (speakers != null) Marshal.ReleaseComObject(speakers);
            }
        }
    }



    #region Abstracted COM interfaces from Windows CoreAudio API
    [ComImport, Guid("BCDE0395-E52F-467C-8E3D-C4579291692E")]
    internal class MMDeviceEnumerator
    {
    }

    
    internal static class Locker
    {
        public static object MMDeviceEnumerator = new object();
    }
    #endregion
    */
}
