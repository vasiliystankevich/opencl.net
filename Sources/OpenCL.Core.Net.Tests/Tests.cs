using System;
using OpenCL.Core.Net.Containers;
using OpenCL.Core.Net.Interfaces.Kernel;
using OpenCL.Core.Net.Interfaces.Kernel.Functors;
using OpenCL.Core.Net.OldCode;
using OpenCL.Core.Net.OldCode.Driver;
using OpenCL.Core.Net.Types.Primitives;
//using OpenCL.Core.Net.OldCode;
//using OpenCL.Core.Net.OldCode.Driver;
using Project.Kernel;
using Unity;
using Xunit;

namespace OpenCL.Core.Net.Tests
{
    public class Tests
    {
        [Fact]
        public void VerifyOpenClDevices()
        {
            var container = UnityConfig.GetConfiguredContainer();
            BaseTypeFabric.RegisterTypes<TypeFabric>(container);
            var kernel = container.Resolve<IPlatformKernel>();
            var platforms1 = GetPlatforms(kernel);


            var platforms2 = OldCode.Kernel.GetPlatforms();
            //var infoOfPlatforms = platforms.Select(platform =>
            //{
            //    var platformName = Kernel.GetPlatformInfo(platform, PlatformInfo.Name);
            //    var platformVendor = Kernel.GetPlatformInfo(platform, PlatformInfo.Vendor);
            //    var platformVersion = Kernel.GetPlatformInfo(platform, PlatformInfo.Version);
            //    var platformProfile = Kernel.GetPlatformInfo(platform, PlatformInfo.Profile);
            //    var platformExtensions = Kernel.GetPlatformInfo(platform, PlatformInfo.Extensions);
            //    var devicesInfo = Kernel.GetDevices(platform).Select(device =>
            //    {
            //        var deviceType = Kernel.GetDeviceInfo(device, DeviceInfo.Type);
            //        var deviceVendorId = Kernel.GetDeviceInfo(device, DeviceInfo.VendorId);
            //        var deviceName = Kernel.GetDeviceInfo(device, DeviceInfo.Name);
            //        var deviceVendor = Kernel.GetDeviceInfo(device, DeviceInfo.Vendor);
            //        var deviceDriverVersion = Kernel.GetDeviceInfo(device, DeviceInfo.DriverVersion);
            //        var deviceVersion = Kernel.GetDeviceInfo(device, DeviceInfo.Version);
            //        var deviceProfile = Kernel.GetDeviceInfo(device, DeviceInfo.Profile);
            //        var deviceExtensions = Kernel.GetDeviceInfo(device, DeviceInfo.Extensions);
            //        var deviceOpenClCVersion = Kernel.GetDeviceInfo(device, DeviceInfo.OpenClCVersion);
            //        return new
            //        {
            //            Type = deviceType,
            //            VendorId = deviceVendorId,
            //            Vendor = deviceVendor,
            //            Name = deviceName,
            //            DriverVersion = deviceDriverVersion,
            //            Version = deviceVersion,
            //            Profile = deviceProfile,
            //            Extensions = deviceExtensions,
            //            OpenClCVersion = deviceOpenClCVersion
            //        };
            //    }).ToList();
            //    return new
            //    {
            //        Name = platformName,
            //        Vendor = platformVendor,
            //        Version = platformVersion,
            //        Profile = platformProfile,
            //        Extensions = platformExtensions,
            //        Devices = devicesInfo
            //    };
            //}).ToList();
            //int i = 0;
        }


        public PlatformId[] GetPlatforms(IPlatformKernel platform)
        {
            // Check how many platforms are available.
            var numPlatforms = platform.GetPlatformIDs(0, IntPtr.Zero);

            if (numPlatforms < 1)
            {
                return new PlatformId[0];
            }

            // Get the actual platforms once we know their amount.
            //CLPlatformID[] platforms = new CLPlatformID[num_platforms];
            //err = OpenCLDriver.clGetPlatformIDs(num_platforms, platforms, ref num_platforms);

            //return platforms;
            var platforms = platform.GetPlatformIDs(numPlatforms);
            return platforms.Arg2;
        }
    }
}