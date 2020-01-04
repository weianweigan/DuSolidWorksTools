namespace DuSolidWorksTools
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for SolidWorksToolBoxControl.
    /// </summary>
    public partial class SolidWorksToolBoxControl : UserControl
    {
        public SolidWorksToolBoxViewModel viewmodel;
        /// <summary>
        /// Initializes a new instance of the <see cref="SolidWorksToolBoxControl"/> class.
        /// </summary>
        public SolidWorksToolBoxControl()
        {
            this.InitializeComponent();
            viewmodel = new SolidWorksToolBoxViewModel(this);
            DataContext = viewmodel;
        }

        /// <summary>
        /// Handles click on the button by displaying a message box.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                string.Format(System.Globalization.CultureInfo.CurrentUICulture, "Invoked '{0}'", this.ToString()),
                "SolidWorksToolBox");
        }

        private void MyToolWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //ApiBrowser.Source = new Uri(Du.Core.SolidWorksURLContructor.NowApiWelcomeUrl);

            
        }
        /// <summary>
        /// 打开关于页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //DuSolidWorksTools.View.AboutPage.GetInstance().ShowModal();
        }
        //Background="{DynamicResource {x:Static vsshell:VsBrushes.WindowKey}}"
        //Foreground="{DynamicResource {x:Static vsshell:VsBrushes.WindowTextKey}}"
    }
}