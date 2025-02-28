using System;

namespace TCG.Debug
{
    [Flags, Serializable]
    public enum LogChannels
    {
        Default = 1,
        AssetManagement,
    }
}