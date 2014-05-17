/*
 * Created by SharpDevelop.
 * User: Daan
 * Date: 5-5-2014
 * Time: 07:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Forms;

namespace Boeiend
{
    static class HelpProvider
    {
        static HelpProvider()
        {
            CommandManager.RegisterClassCommandBinding(
                typeof(FrameworkElement),
                new CommandBinding(
                    ApplicationCommands.Help,
                    new ExecutedRoutedEventHandler(Executed),
                    new CanExecuteRoutedEventHandler(CanExecute)));
        }

        static private void CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

            var senderElement = sender as FrameworkElement;

            if (HelpProvider.GetHelpString(senderElement) != null)
                e.CanExecute = true;
        }

        static private void Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Help.ShowHelp(null, "PlanEditor.chm", HelpNavigator.KeywordIndex, HelpProvider.GetHelpString(sender as FrameworkElement));
        }

        public static string GetHelpString(DependencyObject obj)
        {
            return (string)obj.GetValue(HelpStringProperty);
        }

        public static void SetHelpString(DependencyObject obj, string value)
        {
            obj.SetValue(HelpStringProperty, value);
        }

        public static readonly DependencyProperty HelpStringProperty =
            DependencyProperty.RegisterAttached("HelpString", typeof(string), typeof(HelpProvider));
	}
}
