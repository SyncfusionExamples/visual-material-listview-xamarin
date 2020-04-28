using Syncfusion.DataSource.Extensions;
using Syncfusion.GridCommon.ScrollAxis;
using Syncfusion.ListView.XForms;
using Syncfusion.ListView.XForms.Control.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewXamarin
{
    #region Behavior
    public class Behavior : Behavior<ContentPage>
    {
        #region Fields
        SfListView ListView;
        #endregion

        #region Overrides
        protected override void OnAttachedTo(ContentPage bindable)
        {
            ListView = bindable.FindByName<SfListView>("listView");
            ListView.ItemGenerator = new ItemGeneratorExt(this.ListView);
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            ListView = null;
            base.OnDetachingFrom(bindable);
        }
        #endregion
    }
    #endregion

    #region ItemGeneratorExt
    public class ItemGeneratorExt : ItemGenerator
    {
        public ItemGeneratorExt(SfListView listview) : base(listview)
        {

        }
        protected override ListViewItem OnCreateListViewItem(int itemIndex, ItemType type, object data = null)
        {
            if (type == ItemType.Record)
                return new ListViewItemExt(type);
            return base.OnCreateListViewItem(itemIndex, type, data);
        }
    }
    #endregion

    #region ListViewItemExt
    public class ListViewItemExt : ListViewItem
    {
        public ListViewItemExt()
        {
        }
        public ListViewItemExt(ItemType type) : base(type)
        {

        }
        protected override void OnItemAppearing()
        {
            this.Opacity = 0;
            this.FadeTo(1, 400, Easing.SinInOut);
            base.OnItemAppearing();
        }
    }
    #endregion
}