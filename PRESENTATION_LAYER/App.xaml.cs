using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PRESENTATION_LAYER
{
    /// <summary>
    /// App.xaml.cs - Application Entry Point
    /// 
    /// This is the code-behind for the WPF Application class.
    /// It manages the overall lifecycle of the application including:
    /// - Application startup (InitializeComponent)
    /// - Global event handling
    /// - Application-wide resources and settings
    /// - Startup window configuration (defined in App.xaml as LoginWindow)
    /// 
    /// The actual startup URI is defined in App.xaml and points to Users/LoginWindow.xaml
    /// This ensures users must login before accessing the main application
    /// </summary>
    public partial class App : Application
    {
        // No custom logic needed here - WPF handles initialization automatically
        // All configuration is managed through XAML bindings and event handlers
    }
}