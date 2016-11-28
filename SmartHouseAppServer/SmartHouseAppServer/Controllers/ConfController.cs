using SmartHouseApp.Common.KnowledgeDataStructures;
using SmartHouseApp.Common.Tools;
using SmartHouseApp.Share.Models;
using SmartHouseApp.Share.ViewModel;
using SmartHouseApp.Share.ViewModel.DeviceViewModels;
using SmartHouseAppServer.Domain;
using SmartHouseApp.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SmartHouseAppServer.Controllers
{
    public class ConfController : ApiController
    {
        [HttpGet]
        public virtual SizeViewModel GetMapSize()
        {
            return new SizeViewModel
            {
                X = SystemDataKnowledge.MapSize.Item1,
                Y = SystemDataKnowledge.MapSize.Item2
            };
        }

        [HttpGet]
        public virtual List<StaticRouterDataViewModel> GetRoutersInfo()
        {
            List<StaticRouterDataViewModel> result = new List<StaticRouterDataViewModel>();

            foreach (var router in SystemDataKnowledge.RoutersInfo)
            {
                result.Add(new StaticRouterDataViewModel
                {
                    Id = router.Id,
                    AntennaGain = router.AntennaGain,
                    FadeMargin = router.FadeMargin,
                    LocationX = router.Location.X,
                    LocationY = router.Location.Y,
                    LocationZ = router.Location.Z,
                    SSID = router.SSID,
                    TrasmitterPower = router.TrasmitterPower
                });
            }

            return result;
        }

        [HttpPost]
        public virtual bool SaveMapSize([FromBody]SaveMapSizeModel model)
        {
            SmartHouseApp.Common.Tools.Configuration.Conf.MapSizeX = model.MapSizeX;
            SmartHouseApp.Common.Tools.Configuration.Conf.MapSizeY = model.MapSizeY;
            SystemDataKnowledge.MapSize = new Tuple<int, int>(model.MapSizeX, model.MapSizeY);
            return SmartHouseApp.Common.Tools.Configuration.Save();
        }

        [HttpPost]
        public virtual bool SaveRouterData([FromBody]SaveStaticRouterInfoModel model)
        {
            if (model.Id == 0)
            {
                var data = new StaticRouterInfo
                {
                    Id = SystemDataKnowledge.RoutersInfo.Select(p => p.Id).Max() + 1,
                    AntennaGain = model.AntennaGain,
                    FadeMargin = model.FadeMargin,
                    Location = new SmartHouseApp.Common.DataStractures.Point { X = model.LocationX, Y = model.LocationY, Z = model.LocationZ },
                    SSID = model.SSID,
                    TrasmitterPower = model.TrasmitterPower
                };
                SmartHouseApp.Common.Tools.Configuration.Conf.RoutersInfo.Add(data);
            }
            else
            {
                foreach (var data in SystemDataKnowledge.RoutersInfo)
                {
                    if (data.Id == model.Id)
                    {
                        data.SSID = model.SSID;
                        data.Location.X = model.LocationX;
                        data.Location.Y = model.LocationY;
                        data.Location.Z = model.LocationZ;
                        data.AntennaGain = model.AntennaGain;
                        data.FadeMargin = model.FadeMargin;
                        data.TrasmitterPower = model.TrasmitterPower;
                    }
                }
            }
            return SmartHouseApp.Common.Tools.Configuration.Save();
        }

        [HttpPost]
        public virtual bool DeleteRouterData([FromBody]int routerId)
        {
            SmartHouseApp.Common.Tools.Configuration.Conf.RoutersInfo = SmartHouseApp.Common.Tools.Configuration.Conf.RoutersInfo.Where(p => p.Id != routerId).ToList();
            SystemDataKnowledge.RoutersInfo = SmartHouseApp.Common.Tools.Configuration.Conf.RoutersInfo;
            return SmartHouseApp.Common.Tools.Configuration.Save();
        }

        [HttpPost]
        public List<LightDeviceViewModel> GetLightDevices()
        {
            using (var repo = new Repository<LightDeviceDomain>())
            {
                return repo.All().Select(p =>
                    new LightDeviceViewModel
                    {
                        DeviceId = p.DeviceId,
                        Ip = p.Ip,
                        Port = p.Port,
                        MaxPercentagePower = p.MaxPercentagePower,
                        MinPercentagePower = p.MinPercentagePower,
                        VisibleName = p.VisibleName,
                        X = p.X,
                        Y = p.Y,
                        Z = p.Z,
                        Active = p.Active,
                        Interface = new LightDeviceInterfaceViewModel
                        {
                            Id = p.Interface.Id,
                            VisibleName = p.Interface.VisibleName
                        }
                    }
                ).ToList();
            }
        }

        [HttpPost]
        public bool DeleteLightDevice(LightDeviceViewModel model)
        {
            using (var repo = new Repository<LightDeviceDomain>())
            {
                try
                {
                    repo.BeginTransaction();
                    repo.Delete(model.DeviceId);
                    repo.CommitTransaction();
                }
                catch (Exception ex)
                {
                    if (repo != null)
                    {
                        repo.RollbackTransaction();
                        return false;
                    }
                }
            }
            return true;
        }

        [HttpPost]
        public bool SaveLightDevice(LightDeviceViewModel model)
        {
            using (var repo = new Repository<LightDeviceDomain>())
            {
                try
                {
                    repo.BeginTransaction();

                    LightDeviceDomain obj = null;
                    if (model.DeviceId > 0)
                        obj = repo.GetById(model.DeviceId);
                    else
                        obj = new LightDeviceDomain();

                    if (obj != null)
                    {
                        obj.Ip = model.Ip;
                        obj.MaxPercentagePower = model.MaxPercentagePower;
                        obj.MinPercentagePower = model.MinPercentagePower;
                        obj.Port = model.Port;
                        obj.VisibleName = model.VisibleName;
                        obj.X = model.X;
                        obj.Y = model.Y;
                        obj.Z = model.Z;
                        obj.Active = model.Active;

                        if (model.Interface != null)
                        {
                            using (var repo2 = new Repository<LightDeviceInterface>())
                            {
                                obj.Interface = repo2.Where(p => p.Id == model.Interface.Id).Single();
                            }
                        }

                        repo.Save(obj);
                    }
                    repo.CommitTransaction();
                }
                catch (Exception ex)
                {
                    if (repo != null)
                    {
                        repo.RollbackTransaction();
                        return false;
                    }
                }
            }
            return true;
        }

        [HttpGet]
        public virtual List<DeviceCategoryViewModel> GetDeviceCategories()
        {
            using (var repo = new Repository<DeviceCategoryDomain>())
            {
                var data = repo.All().ToList();
                return data.Select(p => new DeviceCategoryViewModel
                {
                    VisibleName = p.Name,
                    CategoryId = p.Id
                }).ToList();
            }
        }

        [HttpGet]
        public virtual List<LightDeviceInterfaceViewModel> LightDeviceInterfaces()
        {
            using (var repo = new Repository<LightDeviceInterface>())
            {
                var data = repo.All().ToList();
                return data.Select(p => new LightDeviceInterfaceViewModel
                {
                    Id = p.Id,
                    VisibleName = p.VisibleName
                }).ToList();
            }
        }
    }
}