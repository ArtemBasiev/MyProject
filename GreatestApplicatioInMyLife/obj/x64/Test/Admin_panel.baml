   M S B A M L   `   `   `  ����   GreatestApplicatioInMyLife,    &GreatestApplicatioInMyLife.Admin_panel   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     a ]DevExpress.Xpf.Core.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a<dxc2http://schemas.devexpress.com/winfx/2008/xaml/core  Adxdb6http://schemas.devexpress.com/winfx/2008/xaml/demobase  a ]DevExpress.Xpf.Grid.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v15.2.Core, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   d `DevExpress.Xpf.Docking.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxdo5http://schemas.devexpress.com/winfx/2008/xaml/docking  <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  ]	 YDevExpress.Mvvm.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aAdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm  	 @dxn4http://schemas.devexpress.com/winfx/2008/xaml/navbar  	 ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  j
 fDevExpress.Xpf.LayoutControl.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol 
 -     �Name$  admin_panel�� � Title$1 +Окно администрирования��$��699.757��$��1445.328��&   DevExpress.Xpf.Core.ThemeManager   	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$ 
Office2013  � Icon$< 6Images/Перемещать на тележке-32.png�� � WindowState$ 	Maximized=�.���  J� RenderTransformOrigin$ 	0.5,0.504&�.+�]� ��. .+�-  'DevExpress.Xpf.Bars.BarContainerControl  $	��Top=�   Bars. )  #DevExpress.Xpf.Bars.MainMenuControl  -     Name$ mainMenu��,  &DevExpress.Xpf.Bars.ToolBarControlBase   Caption$ MainMenu��$��0q�	   Items.	 $  DevExpress.Xpf.Bars.BarSubItem  !  DevExpress.Xpf.Bars.BarItem
   Content)  #DevExpress.Xpf.Core.ObjectConverter$
 ПОМОЩЬ    Items. '	  !DevExpress.Xpf.Bars.BarButtonItem	  $
 Справка    Glyph$ Images/Question_16x16.png��	  $
 О прогрмамме $( "Images/Информация-16.png��  $
 
ВЫХОД . 	  -    	 Name$ 	btExitApp��$
 Из приложения $ Images/Close_16x16.png��	  $&
  Из учетной записи $ Images/Выход-16.png��*
  $DevExpress.Xpf.Bars.StatusBarControl
  -    
 Name$ 	statusBar��$��Bottom=�$ 	StatusBar��.	 '  !DevExpress.Xpf.Bars.BarStaticItem  $
 Строка:    
ShowBorder .    $
 1   $
 Столбец:  .    $
 1 � $
��0,10q�.+�.  (DevExpress.Xpf.Docking.DockLayoutManager  -     Name$ DemoDockContainer��$��1��   FloatingMode$ Desktop=�   
LayoutRoot. (  "DevExpress.Xpf.Docking.LayoutGroup  -     Name$ lgMain��   Items. *  $DevExpress.Xpf.Docking.DocumentGroup  -     Name$ DocumentHost��   DestroyOnClosingChildren .  . *  $DevExpress.Xpf.Docking.DocumentPanel  +  %DevExpress.Xpf.Docking.BaseLayoutItem   Caption$/ )Панель администратора��   
AllowClose .  (  "DevExpress.Xpf.Docking.ContentItem   Content.   -   $ doc_container��$��1��$ Desktop=�.   . (  "DevExpress.Xpf.Docking.TabbedGroup  . (  "DevExpress.Xpf.Docking.LayoutPanel  -	     Name$ arrive_documents��$9 3Склады и ответственные лица��$   HeaderBarContainerControlName$ SolutionBar�� .     	AllowHide .  . �  � ColumnDefinitions �� -
    �Name$ 
space_tree��$	��19* ��� $	��81* �.+��� -   $��Tree_SP��$��1��$
��12,0q�.+�(  "DevExpress.Xpf.Bars.ToolBarControl  $��Stretch=�$��5, 5, 10, 10q�$��64��.	 	  -   $ but_refresh_tree��$
 Обновить    BarItemDisplayMode$ ContentAndGlyph=�    GlyphAlignment$	  Top=�!   	GlyphSize$! Large=�$ Images/Refresh2_32x32.png��%  DevExpress.Xpf.Grid.GridControl  -   "  Name$" grid_war��$
��1000��)  #DevExpress.Xpf.Grid.DataControlBase#   AutoGenerateColumns$# AddNew=�#$   EnableSmartColumnsGeneration$ . %   View% #  DevExpress.Xpf.Grid.TableView  -   &  Name$& view_grid_tree_war��'   AllowPerPixelScrolling' . &   DevExpress.Xpf.Grid.DataViewBase(   ShowTotalSummary( . �� $��Stretch=�$��1��$��1��.+�  $��Stretch=�$��5, 5, 10, 10q�$��64��.	 	  -   $ but_nom��$
 Добавить $@ :/GreatestApplicatioInMyLife;component/Images/Add_32x32.png��$	  Top=�$ ContentAndGlyph=�$! Large=�	  -   $ but_del��$
 Удалить $C =/GreatestApplicatioInMyLife;component/Images/Cancel_32x32.png��$! Large=�)   	MergeType$) Default=�$ ContentAndGlyph=�$	  Top=�	  -   $ but_refresh��$
 Обновить $ ContentAndGlyph=�$	  Top=�$! Large=�$ Images/Refresh2_32x32.png��	  -   $ but_help��$
 Справка $	  Top=�$! Large=�$ ContentAndGlyph=�$, &UserControls/Images/Question_32x32.png��  -   $" grid_res��$
��1000��$# AddNew=�$ . %   -   $& view_grid_res��' . ( .   -   $ roles_and_users��$* $Роли и пользователи��$ SolutionBar�� .   .  . �  �� $	��19* ��� $	��81* �.+��� $��1��$
��12,0q�.+�  $��Stretch=�$��5, 5, 10, 10q�$��64��.	 	  -   $ but_refresh_tree_roles��$
 Обновить $ ContentAndGlyph=�$	  Top=�$! Large=�$ Images/Refresh2_32x32.png��  -   $" 
grid_roles��$
��1000��$# AddNew=�$ . %   -   $& view_grid_tree_roles��' . ( . �� $��Stretch=�$��1��$��1��.+�  $��Stretch=�$��5, 5, 10, 10q�$��64��.	 	  -   $ but_add_user��$
 Добавить $@ :/GreatestApplicatioInMyLife;component/Images/Add_32x32.png��$	  Top=�$ ContentAndGlyph=�$! Large=�	  -   $ but_del_user��$
 Удалить $C =/GreatestApplicatioInMyLife;component/Images/Cancel_32x32.png��$! Large=�$) Default=�$ ContentAndGlyph=�$	  Top=�	  -   $ but_refresh_user��$
 Обновить $ ContentAndGlyph=�$	  Top=�$! Large=�$ Images/Refresh2_32x32.png��	  -   $ but_help_users��$
 Справка $	  Top=�$! Large=�$ ContentAndGlyph=�$, &UserControls/Images/Question_32x32.png��  -   $" 
grid_users��$
��1000��$# AddNew=�$ . %   -   $& view_grid_users��' . ( . 