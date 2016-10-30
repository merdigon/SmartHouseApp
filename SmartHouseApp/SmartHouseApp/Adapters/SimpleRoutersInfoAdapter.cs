using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SmartHouseApp.Activities.A01SearchRouters;

namespace SmartHouseApp.Adapters
{
    public class SimpleRoutersInfoAdapter : BaseAdapter
    {
        IList<RouterInfo> Items { get; set; }
        Context Context { get; set; }

        public SimpleRoutersInfoAdapter(Context mContext, IList<RouterInfo> listItem)
        {
            this.Context = mContext;
            this.Items = listItem;
        }

        public override int Count
        {
            get
            {
                return Items.Count;
            }
        }

        public override Java.Lang.Object GetItem(int arg0)
        {
            return null;
        }

        public void ClearItems()
        {
            Items.Clear();
        }

        public void AddRange(IList<RouterInfo> source)
        {
            foreach (RouterInfo obj in source)
            {
                Items.Add(obj);
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View arg1, ViewGroup viewGroup)
        {
            LayoutInflater inflater = (LayoutInflater)Context.GetSystemService(Context.LayoutInflaterService);
            View row = inflater.Inflate(Resource.Layout.customListView_routers, viewGroup, false);

            TextView routerName = (TextView)row.FindViewById(Resource.Id.RouterName);
            TextView levelPower = (TextView)row.FindViewById(Resource.Id.LevelText);
            TextView distance = (TextView)row.FindViewById(Resource.Id.DistanceText);

            routerName.Text = Items[position].Name;
            levelPower.Text = Items[position].Strenght.ToString();
            distance.Text = Items[position].Distance.ToString();
            
            return row;
        }
    }
}