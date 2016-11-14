﻿using SmartHouseApp.Common.KnowledgeDataStructures;
using SmartHouseApp.Share.Models;
using SmartHouseApp.Share.ViewModel;
using SmartHouseAppServer.Domain;
using SmartHouseAppServer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SmartHouseAppServer.Controllers
{
    public class ClientController : ApiController
    {
        [HttpPost]
        public virtual LogInViewModel LogIn(LogInModel model)
        {
            if (SystemDataKnowledge.LoggedUsers.Where(p => p.Login.Equals(model.Login)).Count() == 0)
                SystemDataKnowledge.LoggedUsers.Add(new LoggedUser(model.Login, HttpContext.Current.Request.UserHostAddress + ":52078"));
            else
            {
                foreach (var loggerUser in SystemDataKnowledge.LoggedUsers)
                {
                    if (loggerUser.Login.Equals(model.Login))
                        loggerUser.IsOnline = true;
                }
            }
            return new LogInViewModel { Result = true, MapSizeX = SystemDataKnowledge.MapSize.Item1, MapSizeY = SystemDataKnowledge.MapSize.Item2 };
        }

        [HttpPost]
        public virtual bool LogOut(LogInModel model)
        {
            foreach (var loggerUser in SystemDataKnowledge.LoggedUsers)
            {
                if (loggerUser.Login.Equals(model.Login))
                    loggerUser.IsOnline = false;
            }

            return true;
        }

        [HttpPost]
        public virtual bool StartRealTime()
        {
            foreach(var loggerUser in SystemDataKnowledge.LoggedUsers)
            {
                if(loggerUser.Ip.Equals(HttpContext.Current.Request.UserHostAddress + ":52078"))
                {
                    loggerUser.NotifyRequested = true;
                }
            }
            return false;
        }

        [HttpPost]
        public virtual bool StopRealTime()
        {
            foreach (var loggerUser in SystemDataKnowledge.LoggedUsers)
            {
                if (loggerUser.Ip.Equals(HttpContext.Current.Request.UserHostAddress + ":52078"))
                {
                    loggerUser.NotifyRequested = false;
                }
            }
            return true;
        }

        [HttpGet]
        public virtual List<UserPositionModel> GetUsersPositions(DateSpawnModel model)
        {
            using (var repo = new Repository<UserPositionHistory>())
            {
                var result = repo.Where(p => p.Date > model.StartDate && p.Date < model.EndDate);
                return result.Select(p => new UserPositionModel
                {
                    Mac = p.Mac,
                    X = p.X,
                    Y = p.Y,
                    Z = p.Z
                }).ToList();
            }
        }
    }
}