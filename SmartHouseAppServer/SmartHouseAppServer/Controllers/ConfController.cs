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
using SmartHouseAppServer.KnowledgeDataStructures;

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
                    LocationX = router.LocationX,
                    LocationY = router.LocationY,
                    LocationZ = router.LocationZ,
                    SSID = router.SSID,
                    TrasmitterPower = router.TrasmitterPower,
                    Weight = router.Weight,
                    RouterCategoryId = router.RouterType.Id
                });
            }

            return result;
        }

        [HttpPost]
        public virtual bool SaveMapSize([FromBody]SaveMapSizeModel model)
        {
            SmartHouseAppServer.Tools.Configuration.Conf.MapSizeX = model.MapSizeX;
            SmartHouseAppServer.Tools.Configuration.Conf.MapSizeY = model.MapSizeY;
            SystemDataKnowledge.MapSize = new Tuple<int, int>(model.MapSizeX, model.MapSizeY);
            return SmartHouseAppServer.Tools.Configuration.Save();
        }

        [HttpPost]
        public virtual bool SaveRouterData([FromBody]SaveStaticRouterInfoModel model)
        {
            StaticRouterInfo dataModel = null;

            using (var repo = new Repository<StaticRouterInfo>())
            {
                repo.BeginTransaction();
                dataModel = repo.Where(p => p.Id == model.Id).SingleOrDefault();

                if (dataModel == null)
                    dataModel = new StaticRouterInfo();

                dataModel.AntennaGain = model.AntennaGain;
                dataModel.FadeMargin = model.FadeMargin;
                dataModel.LocationX = model.LocationX;
                dataModel.LocationY = model.LocationY;
                dataModel.LocationZ = model.LocationZ;
                dataModel.SSID = model.SSID;
                dataModel.TrasmitterPower = model.TrasmitterPower;
                dataModel.Weight = model.Weight;

                using (var repo2 = new Repository<RouterType>())
                {
                    dataModel.RouterType = repo2.Where(p => p.Id == model.RouterCategoryId).SingleOrDefault();
                }

                repo.Save(dataModel);
                repo.CommitTransaction();

                SystemDataKnowledge.RoutersInfo = SystemDataKnowledge.LoadRouterInfo();
                return true;
            }
        }

        [HttpPost]
        public virtual bool DeleteRouterData([FromBody]int routerId)
        {
            using (var repo = new Repository<StaticRouterInfo>())
            {
                if (repo.Where(p => p.Id == routerId).SingleOrDefault() != null)
                {
                    repo.BeginTransaction();
                    repo.Delete(routerId);
                    repo.CommitTransaction();

                    SystemDataKnowledge.RoutersInfo = SystemDataKnowledge.LoadRouterInfo();
                }
                return true;
            }
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

        [HttpGet]
        public virtual List<RouterTypeViewModel> GetRouterTypes()
        {
            using (var repo = new Repository<RouterType>())
            {
                return repo.All().Select(p => new RouterTypeViewModel
                {
                    Id = p.Id,
                    VisibleName = p.VisibleName
                }).ToList();
            }
        }

        [HttpGet]
        public virtual List<SystemUserViewModel> GetAllUsers()
        {
            using (var repo = new Repository<SystemUser>())
            {
                return repo.All().Select(p => new SystemUserViewModel
                {
                    Id = p.Id,
                    Mac = p.Mac,
                    VisibleName = p.VisibleName,
                    Weight = p.UserWeight.ToString()
                }).ToList();
            }
        }

        [HttpPost]
        public virtual bool SaveUsers(List<SystemUserViewModel> model)
        {
            using (var repo = new Repository<SystemUser>())
            {
                repo.BeginTransaction();
                foreach(var user in model)
                {
                    var dataModel = new SystemUser
                    {
                        Id = user.Id,
                        Mac = user.Mac,
                        UserWeight = int.Parse(user.Weight),
                        VisibleName = user.VisibleName
                    };
                    repo.Save(dataModel);
                }
                repo.CommitTransaction();
                return true;
            }
        }
    }
}