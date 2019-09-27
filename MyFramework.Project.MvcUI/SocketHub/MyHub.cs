using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using MyFramework.Project.Business.Abstract;
using MyFramework.Project.Business.DependencyResolvers.Ninject;

namespace MyFramework.Project.MvcUI.SocketHub
{
    public class MyHub : Hub
    {
        IHaberManager _haberManager = InstanceFactory.GetInstance<IHaberManager>();
       public void disabled(int id,bool aktifMi)
        {
            var haber = _haberManager.Get(id);
            haber.Aktiflik = aktifMi;
            _haberManager.Update(haber);
            Clients.All.updateDate(haber.IslemZamani.ToString(),id);
        }

        public void enabled(int id, bool aktifMi)
        {
            var haber = _haberManager.Get(id);
            haber.Aktiflik = aktifMi;
            _haberManager.Update(haber);
            Clients.All.updateDate(haber.IslemZamani.ToString(),id);
        }

        public void updateSiraNo(int id,int sira)
        {
            var haber = _haberManager.Get(id);
            haber.SiraNo = sira;
            _haberManager.Update(haber);
            Clients.All.updateDate(haber.IslemZamani.ToString(), id);
        }
    }
}