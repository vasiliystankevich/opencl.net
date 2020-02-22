﻿using System.Linq;
using OpenCL.Core.Net.Types.Enums;
using OpenCL.Core.Net.Types.Enums.Device;
using Xunit;

namespace OpenCL.Core.Net.Tests
{
    public class Tests
    {
        [Fact]
        public void VerifyOpenClDevices()
        {
            var platforms = Kernel.GetPlatforms();
            var infoOfPlatforms = platforms.Select(platform =>
            {
                var platformName = Kernel.GetPlatformInfo(platform, PlatformInfo.Name);
                var platformVendor = Kernel.GetPlatformInfo(platform, PlatformInfo.Vendor);
                var platformVersion = Kernel.GetPlatformInfo(platform, PlatformInfo.Version);
                var platformProfile = Kernel.GetPlatformInfo(platform, PlatformInfo.Profile);
                var platformExtensions = Kernel.GetPlatformInfo(platform, PlatformInfo.Extensions);
                var devicesInfo = Kernel.GetDevices(platform).Select(device =>
                {
                    var deviceType = Kernel.GetDeviceInfo(device, DeviceInfo.Type);
                    var deviceVendorId = Kernel.GetDeviceInfo(device, DeviceInfo.VendorId);
                    var deviceName = Kernel.GetDeviceInfo(device, DeviceInfo.Name);
                    var deviceVendor = Kernel.GetDeviceInfo(device, DeviceInfo.Vendor);
                    var deviceDriverVersion = Kernel.GetDeviceInfo(device, DeviceInfo.DriverVersion);
                    var deviceVersion = Kernel.GetDeviceInfo(device, DeviceInfo.Version);
                    var deviceProfile = Kernel.GetDeviceInfo(device, DeviceInfo.Profile);
                    var deviceExtensions = Kernel.GetDeviceInfo(device, DeviceInfo.Extensions);
                    var deviceOpenClCVersion = Kernel.GetDeviceInfo(device, DeviceInfo.OpenClCVersion);
                    return new
                    {
                        Type = deviceType,
                        VendorId = deviceVendorId,
                        Vendor = deviceVendor,
                        Name = deviceName,
                        DriverVersion = deviceDriverVersion,
                        Version = deviceVersion,
                        Profile = deviceProfile,
                        Extensions = deviceExtensions,
                        OpenClCVersion = deviceOpenClCVersion
                    };
                }).ToList();
                return new
                {
                    Name = platformName,
                    Vendor = platformVendor,
                    Version = platformVersion,
                    Profile = platformProfile,
                    Extensions = platformExtensions,
                    Devices = devicesInfo
                };
            }).ToList();
            int i = 0;
        }
    }
}