namespace MasterMike
{
    using System;
    using NAudio.CoreAudioApi;

    /// <summary>
    /// Utilities for working with Audio.
    /// </summary>
    public static class AudioUtilities
    {
        /// <summary>
        /// Sets the mic level for all devices.
        /// </summary>
        /// <param name="level">The new mic level.</param>
        /// <param name="mute">Sets the mute state of the device.</param>
        public static void LockAudio(float? level, bool? mute)
        {
            using MMDeviceEnumerator deviceEnumerator = new MMDeviceEnumerator();
            MMDeviceCollection deviceCollection = deviceEnumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);

            // Loop through all devices
            for (int index = 0; index < deviceCollection.Count; index++)
            {
                using var captureDevice = deviceCollection[index];

                // Set The properties.
                if (level.HasValue && captureDevice.AudioEndpointVolume.MasterVolumeLevelScalar != level.Value)
                {
                    captureDevice.AudioEndpointVolume.MasterVolumeLevelScalar = level.Value;
                }

                if (level.HasValue && captureDevice.AudioEndpointVolume.Mute != mute.Value)
                {
                    captureDevice.AudioEndpointVolume.Mute = mute.Value;
                }
            }
        }
    }
}
