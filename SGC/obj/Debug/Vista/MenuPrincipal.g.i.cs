﻿#pragma checksum "..\..\..\Vista\MenuPrincipal.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2C61DF2E6920EE5E6AADD66DB4C742E6F1AA85F4CB98D8BFB9B5467A350C270D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace SGC.Vista {
    
    
    /// <summary>
    /// MenuPrincipal
    /// </summary>
    public partial class MenuPrincipal : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\Vista\MenuPrincipal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BuscarConstanciaButton;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Vista\MenuPrincipal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RegistrarDocenteButton;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Vista\MenuPrincipal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RegistrarConstanciaButton;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Vista\MenuPrincipal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RegistrarAdministrativoButton;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Vista\MenuPrincipal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CerrarSesionButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SGC;component/vista/menuprincipal.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Vista\MenuPrincipal.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.BuscarConstanciaButton = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\..\Vista\MenuPrincipal.xaml"
            this.BuscarConstanciaButton.Click += new System.Windows.RoutedEventHandler(this.BuscarConstanciaButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.RegistrarDocenteButton = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\Vista\MenuPrincipal.xaml"
            this.RegistrarDocenteButton.Click += new System.Windows.RoutedEventHandler(this.RegistrarDocenteButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.RegistrarConstanciaButton = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\Vista\MenuPrincipal.xaml"
            this.RegistrarConstanciaButton.Click += new System.Windows.RoutedEventHandler(this.RegistrarConstanciaButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.RegistrarAdministrativoButton = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\Vista\MenuPrincipal.xaml"
            this.RegistrarAdministrativoButton.Click += new System.Windows.RoutedEventHandler(this.RegistrarAdministrativoButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CerrarSesionButton = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\Vista\MenuPrincipal.xaml"
            this.CerrarSesionButton.Click += new System.Windows.RoutedEventHandler(this.CerrarSesionButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

