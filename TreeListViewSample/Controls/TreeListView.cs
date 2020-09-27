using System.Windows;
using System.Windows.Controls;

namespace TreeListViewSample.Controls
{
   public class TreeListView : TreeView
   {
      protected override DependencyObject GetContainerForItemOverride() => new TreeListViewItem();
      protected override bool IsItemItsOwnContainerOverride(object item) => item is TreeListViewItem;

   }

   public class TreeListViewItem : TreeViewItem
   {
      private int _level = -1;
      public int Level
      {
         get
         {
            if (_level == -1)
            {
               _level = (ItemsControl.ItemsControlFromItemContainer(this) is TreeListViewItem parent) ? parent.Level + 1 : 0;
            }
            return _level;
         }
      }

      protected override DependencyObject GetContainerForItemOverride() => new TreeListViewItem();

      protected override bool IsItemItsOwnContainerOverride(object item) => item is TreeListViewItem;
   }
}
