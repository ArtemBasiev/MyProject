   M S B A M L   `   `   `  ����   GreatestApplicatioInMyLife+    %GreatestApplicatioInMyLife.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     a ]DevExpress.Xpf.Core.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a<dxc2http://schemas.devexpress.com/winfx/2008/xaml/core  Adxdb6http://schemas.devexpress.com/winfx/2008/xaml/demobase  a ]DevExpress.Xpf.Grid.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v15.2.Core, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   d `DevExpress.Xpf.Docking.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxdo5http://schemas.devexpress.com/winfx/2008/xaml/docking  <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  ]	 YDevExpress.Mvvm.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aAdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm  	 @dxn4http://schemas.devexpress.com/winfx/2008/xaml/navbar  	 ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  j
 fDevExpress.Xpf.LayoutControl.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol 
 -     �Name$  
mainwindow�� � Title$ Главное окно��$��699.757��$��1445.328��&   DevExpress.Xpf.Core.ThemeManager   	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$ 
Office2013  � Icon$< 6Images/Перемещать на тележке-32.png�� � WindowState$ 	Maximized=�.���  J� RenderTransformOrigin$ 	0.5,0.504&�.+�]� ��. .+�-  'DevExpress.Xpf.Bars.BarContainerControl  $	��Top=�   Bars. )  #DevExpress.Xpf.Bars.MainMenuControl  -     Name$ mainMenu��,  &DevExpress.Xpf.Bars.ToolBarControlBase   Caption$ MainMenu��$��0q�	   Items.	 $  DevExpress.Xpf.Bars.BarSubItem  !  DevExpress.Xpf.Bars.BarItem
   Content)  #DevExpress.Xpf.Core.ObjectConverter$
 СПРАВОЧНИКИ    Items. '	  !DevExpress.Xpf.Bars.BarButtonItem	  -    	 Name$	 Nom��$
 Номенклатура    Glyph$  Images/Список-16.png��	  -   $ 	brbt_char��$;
 5Характеристики номенклатуры $5 /Images/Свойства сценария-16.png��	  -   $ brbt_provider��$
 Поставщики $ Images/Customer_16x16.png��	  -   $ brbt_employee��$
 Сотрудники $ Images/Employee_16x16.png��	  -   $ brbt_customer��$
 Объекты $" Images/Магазин-16.png��	  -   $ brbtMeasure��$'
 !Единицы измерения $ Images/Длина-16.png��	  -	   $ brbt_warehouse��$
 Склады $ Images/Склад-16.png��  $
 ОТЧЕТЫ . 	  $
 Приход 	  $
 Расход 	  $
 Перемещение 	  -
    �Name$ 	bi_repost��$
 Остатки   $#
 РАБОЧИЕ ПЕРИОДЫ    BarItemDisplayMode$ Content=�. 	  -   $>
 8Управление рабочими периодами   $
 ПОМОЩЬ . 	  $
 Справка $ Images/Question_16x16.png��	  $
 О прогрмамме $( "Images/Информация-16.png��  $
 
ВЫХОД . 	  -   $ 	btExitApp��$
 Из приложения $ Images/Close_16x16.png��	  $&
  Из учетной записи $ Images/Выход-16.png��*
  $DevExpress.Xpf.Bars.StatusBarControl
  -    
 Name$ 	statusBar��$��Bottom=�$ 	StatusBar��.	 '  !DevExpress.Xpf.Bars.BarStaticItem  $

 Row:    
ShowBorder .    $
 1   $
 Column:  .    $
 1   $

 Info    	Alignment$	 Far=�$ ContentAndGlyph=� .  *  $DevExpress.Xpf.Core.DXImageExtension     Image1  +DevExpress.Xpf.Core.Native.DXImageConverter$ Info_16x16.png    
LargeGlyph   $ Info_32x32.png � $
��0,10q�.+�.  (DevExpress.Xpf.Docking.DockLayoutManager  -     Name$ DemoDockContainer��$��1��   FloatingMode$ Desktop=�   
LayoutRoot. (  "DevExpress.Xpf.Docking.LayoutGroup  -     Name$ lgMain��   Items. *  $DevExpress.Xpf.Docking.DocumentGroup  -     Name$ DocumentHost��   DestroyOnClosingChildren .  . *  $DevExpress.Xpf.Docking.DocumentPanel  +  %DevExpress.Xpf.Docking.BaseLayoutItem   Caption$ Документы��   
AllowClose .  (  "DevExpress.Xpf.Docking.ContentItem   Content.   -   $ doc_container��$��1��$ Desktop=�.   . (  "DevExpress.Xpf.Docking.TabbedGroup  . (  "DevExpress.Xpf.Docking.LayoutPanel  -     Name$ arrive_documents��$ Приход��$    HeaderBarContainerControlName$  SolutionBar�� .  !   	AllowHide! .  . �� .+�(  "DevExpress.Xpf.Bars.ToolBarControl  $��Stretch=�$��5, 5, 10, 10q�.	 	  -   $ but_add_arr��$
 Добавить $' !UserControls/Images/Add_32x32.png��$ ContentAndGlyph=�"   GlyphAlignment$	" Top=�#   	GlyphSize$# Large=�	  -   $ but_del_arr��$
 Удалить $ Images/Cancel_32x32.png��$ ContentAndGlyph=�$	" Top=�$# Large=�	  -   $ but_refresh_list_arr��$
 Обновить $	" Top=�$ Images/Refresh2_32x32.png��$ ContentAndGlyph=�$# Large=�	  -   $ 
but_report��$
 
Отчет $# Large=�$	" Top=�$) #UserControls/Images/Print_32x32.png��$ ContentAndGlyph=�	  -   $ but_help_arr��$
 Справка $# Large=�$	" Top=�$, &UserControls/Images/Question_32x32.png��$ ContentAndGlyph=�%  DevExpress.Xpf.Grid.GridControl  -   $  Name$$ gc_arrive_list��)  #DevExpress.Xpf.Grid.DataControlBase%   AutoGenerateColumns$% AddNew=�$	��300��&   View& #  DevExpress.Xpf.Grid.TableView  -   '  Name$' view_rgid_arr��(   AllowPerPixelScrolling( . &   DevExpress.Xpf.Grid.DataViewBase)   ShowTotalSummary) . &   DevExpress.Xpf.Core.DXTabControl  $��0,20,0,0q�.@�#  DevExpress.Xpf.Core.DXTabItem  �  �DevExpress.Xpf.Core.Native.HeaderedSelectorItemBase`2[[DevExpress.Xpf.Core.DXTabControl, DevExpress.Xpf.Core.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a],[DevExpress.Xpf.Core.DXTabItem, DevExpress.Xpf.Core.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]]*   Header$%* Детали документа��.���� .+�  $��Stretch=�$��	5,7,10,10q�.	 	  -   $ but_det_arr_add��$
 Добавить $' !UserControls/Images/Add_16x16.png��$	" Top=�$# Small=�$ ContentAndGlyph=�	  -   $ but_del_det_arr��$
 Удалить $ ContentAndGlyph=�$* $UserControls/Images/Cancel_16x16.png��$	" Top=�$# Small=�	  -   $ but_refresh_det_arr��$
 Обновить $	" Top=�$# Small=�$, &UserControls/Images/Refresh2_32x32.png��$ ContentAndGlyph=�  -   $$ gc_arrive_det��$% AddNew=�$
��1000��&   ( . ) .   -   $ movement_documents��$ Перемещение��$  SolutionBar�� .  ! .  . �� .+�  $��Stretch=�$��5, 5, 10, 10q�.	 	  -   $ but_add_move��$
 Добавить $' !UserControls/Images/Add_32x32.png��$ ContentAndGlyph=�$	" Top=�$# Large=�	  -    $ but_del_move��$
 Удалить $ Images/Cancel_32x32.png��$ ContentAndGlyph=�$	" Top=�$# Large=�	  -!   $ but_refresh_list_move��$
 Обновить $	" Top=�$ Images/Refresh2_32x32.png��$ ContentAndGlyph=�$# Large=�	  -"   $ but_report_move��$
 
Отчет $# Large=�$	" Top=�$) #UserControls/Images/Print_32x32.png��$ ContentAndGlyph=�	  -#   $ but_help_move��$
 Справка $# Large=�$	" Top=�$, &UserControls/Images/Question_32x32.png��$ ContentAndGlyph=�  -$   $$ gc_move_list��$% AddNew=�$	��300��&   -%   $' view_rgid_move��( . ) .   $��0,20,0,0q�.@�  $%* Детали документа��.���� .+�  $��Stretch=�$��	5,7,10,10q�.	 	  -&   $ but_det_arr_move��$
 Добавить $' !UserControls/Images/Add_16x16.png��$	" Top=�$# Small=�$ ContentAndGlyph=�	  -'   $ but_del_det_move��$
 Удалить $ ContentAndGlyph=�$* $UserControls/Images/Cancel_16x16.png��$	" Top=�$# Small=�	  -(   $ but_refresh_det_move��$
 Обновить $	" Top=�$# Small=�$, &UserControls/Images/Refresh2_32x32.png��$ ContentAndGlyph=�  -)   $$ gc_move_det��$% AddNew=�$
��1000��&   ( . ) .   -*   $ leave_documents��$ Расход��$  SolutionBar�� .  ! .  . �� .+�  $��Stretch=�$��5, 5, 10, 10q�.	 	  -+   $ but_add_leave��$
 Добавить $' !UserControls/Images/Add_32x32.png��$ ContentAndGlyph=�$	" Top=�$# Large=�	  -,   $ but_del_leave��$
 Удалить $ Images/Cancel_32x32.png��$ ContentAndGlyph=�$	" Top=�$# Large=�	  --   $ but_refresh_list_leave��$
 Обновить $	" Top=�$ Images/Refresh2_32x32.png��$ ContentAndGlyph=�$# Large=�	  -.   $ but_report_leave��$
 
Отчет $# Large=�$	" Top=�$) #UserControls/Images/Print_32x32.png��$ ContentAndGlyph=�	  -/   $ but_help_leave��$
 Справка $# Large=�$	" Top=�$, &UserControls/Images/Question_32x32.png��$ ContentAndGlyph=�  -0   $$ gc_leave_list��$% AddNew=�$	��300��&   -1   $' view_rgid_leave��( . ) .   $��0,20,0,0q�.@�  $%* Детали документа��.���� .+�  $��Stretch=�$��	5,7,10,10q�.	 	  -2   $ but_det_leave_add��$
 Добавить $' !UserControls/Images/Add_16x16.png��$	" Top=�$# Small=�$ ContentAndGlyph=�	  -3   $ but_del_det_leave��$
 Удалить $ ContentAndGlyph=�$* $UserControls/Images/Cancel_16x16.png��$	" Top=�$# Small=�	  -4   $ but_refresh_det_leave��$
 Обновить $	" Top=�$# Small=�$, &UserControls/Images/Refresh2_32x32.png��$ ContentAndGlyph=�  -5   $$ gc_leave_det��$% AddNew=�$
��1000��&   ( . ) . 