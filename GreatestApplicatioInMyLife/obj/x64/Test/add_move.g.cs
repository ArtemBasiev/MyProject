﻿#pragma checksum "..\..\..\add_move.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "06985E7FE3060F5AC1DDD985CE73AA16"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using DevExpress.Core;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Core.ConditionalFormatting;
using DevExpress.Xpf.Core.DataSources;
using DevExpress.Xpf.Core.Serialization;
using DevExpress.Xpf.Core.ServerMode;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Editors.DataPager;
using DevExpress.Xpf.Editors.DateNavigator;
using DevExpress.Xpf.Editors.ExpressionEditor;
using DevExpress.Xpf.Editors.Filtering;
using DevExpress.Xpf.Editors.Flyout;
using DevExpress.Xpf.Editors.Popups;
using DevExpress.Xpf.Editors.Popups.Calendar;
using DevExpress.Xpf.Editors.RangeControl;
using DevExpress.Xpf.Editors.Settings;
using DevExpress.Xpf.Editors.Settings.Extension;
using DevExpress.Xpf.Editors.Validation;
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


namespace GreatestApplicatioInMyLife {
    
    
    /// <summary>
    /// add_move
    /// </summary>
    public partial class add_move : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 5 "..\..\..\add_move.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal GreatestApplicatioInMyLife.add_move window_add_arr;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\add_move.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.ComboBoxEdit cb_wh;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\add_move.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.MemoEdit comment_arr;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\add_move.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToolBarPanel tbp_main_window_di;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\add_move.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_create_arr;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\add_move.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_can_cr_arr;
        
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
            System.Uri resourceLocater = new System.Uri("/GreatestApplicatioInMyLife;component/add_move.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\add_move.xaml"
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
            this.window_add_arr = ((GreatestApplicatioInMyLife.add_move)(target));
            
            #line 7 "..\..\..\add_move.xaml"
            this.window_add_arr.Activated += new System.EventHandler(this.window_add_arr_Activated);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cb_wh = ((DevExpress.Xpf.Editors.ComboBoxEdit)(target));
            return;
            case 3:
            this.comment_arr = ((DevExpress.Xpf.Editors.MemoEdit)(target));
            return;
            case 4:
            this.tbp_main_window_di = ((System.Windows.Controls.Primitives.ToolBarPanel)(target));
            return;
            case 5:
            this.bt_create_arr = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\add_move.xaml"
            this.bt_create_arr.Click += new System.Windows.RoutedEventHandler(this.bt_create_leave_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.bt_can_cr_arr = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\add_move.xaml"
            this.bt_can_cr_arr.Click += new System.Windows.RoutedEventHandler(this.bt_can_cr_leave_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
