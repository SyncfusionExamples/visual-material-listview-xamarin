# How to work with Material Visual for custom ListView in Xamarin.Forms (SfListView)

You can use [Material](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/visual/material-visual) effects for [SfListView](https://help.syncfusion.com/xamarin/listview/overview?) by Extending [ItemGenerator](https://help.syncfusion.com/xamarin/listview/viewappearance?_ga=2.249566415.819296502.1587960572-1204678185.1570168583#extension-of-itemgenerator) and [ListViewItem](https://help.syncfusion.com/xamarin/listview/viewappearance?_ga=2.236894280.819296502.1587960572-1204678185.1570168583#extension-of-listviewitem) class in Xamarin.Forms. By default, the **SfListView** supports ripple effects for [Selection](https://help.syncfusion.com/xamarin/listview/selection?) and Slide [swiping](https://help.syncfusion.com/xamarin/listview/swiping?) effect for Swiping with [Material design](https://material.io/).

You can also refer the following article.

https://www.syncfusion.com/kb/11468/how-to-work-with-material-visual-for-custom-listview-in-xamarin-forms-sflistview

**XAML**

Enable [Visual](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.visualelement.visual#Xamarin_Forms_VisualElement_Visual) as [Material](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.visualmarker.materialvisual?view=xamarin-forms) for Content page to enable the material effects for SfListView.
``` xml
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:ListViewXamarin"
             xmlns:sync="clr-namespace:Syncfusion.ListView.XForms;assembly=Syncfusion.SfListView.XForms"
             x:Class="ListViewXamarin.MainPage"
             Visual="Material">
    <ContentPage.BindingContext>
        <local:ViewModel />
    </ContentPage.BindingContext>
 
    <ContentPage.Behaviors>
        <local:Behavior/>
    </ContentPage.Behaviors>
    
    <Grid RowSpacing="0" ColumnSpacing="0" Padding="0" Margin="0">
        <sync:SfListView x:Name="listView" AutoFitMode="Height" ItemsSource="{Binding BookInfo}" SelectionBackgroundColor="#d3d3d3">
            <sync:SfListView.ItemTemplate>
                <DataTemplate>
                    <Grid Padding="0,12,8,0">
                        <Grid.RowDefinitions>
                            <RowDefinition Height="Auto" />
                            <RowDefinition Height="1" />
                        </Grid.RowDefinitions>
                        <StackLayout Orientation="Vertical" Padding="8,0,8,10" VerticalOptions="Start" Grid.Row="0">
                            <Label Text="{Binding BookName}" FontAttributes="Bold" FontSize="16" TextColor="#000000" />
                            <Label Text="{Binding BookAuthor}" Grid.Row="1" FontSize="14"  Opacity=" 0.67" TextColor="#000000" />
                            <Label Text="{Binding BookDescription}" Opacity=" 0.54" TextColor="#000000" FontSize="13"/>
                        </StackLayout>
                        <BoxView Grid.Row="1" HeightRequest="1" Opacity="0.75" BackgroundColor="#CECECE" />
                    </Grid>
                </DataTemplate>
            </sync:SfListView.ItemTemplate>
        </sync:SfListView>
    </Grid>
</ContentPage>
```
**C#**

Extend the ItemGenerator and return the customized ListViewItem based on [ItemType](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.ItemType.html?).
``` c#
namespace ListViewXamarin
{
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
}
```
**C#**

Extend the **ListViewItem** and initialize the ListViewItemExt constructor with **ItemType** as parameter to enable ListViewItem Effects.
``` c#
namespace ListViewXamarin
{
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
}
```
**C#**

Set the instance of the **ItemGeneratorExt** class to the ListView.ItemGenerator property.
``` c#
namespace ListViewXamarin
{
    public class Behavior : Behavior<ContentPage>
    {
        SfListView ListView;
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
    }
}
```
**Output**

![CustomListView](https://github.com/SyncfusionExamples/visual-material-listview-xamarin/blob/master/ScreenShots/CustomListView.gif)

> **_Note:_** When [EffectsView](https://help.syncfusion.com/xamarin/effects-view/getting-started?) is applied to ListView by adding Visual as **Material**, it is necessary to initialize the **EffectsViewRenderer** in iOS.

You can also refer to the following document link to use **EffectsView** in the application.

https://help.syncfusion.com/xamarin/effects-view/getting-started#launching-an-application-on-each-platform-with-sfeffectsview
