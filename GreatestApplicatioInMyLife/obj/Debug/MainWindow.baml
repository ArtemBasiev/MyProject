   M S B A M L   `   `   `  ����  GreatestApplicatioInMyLife+    %GreatestApplicatioInMyLife.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   a ]DevExpress.Xpf.Core.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a<dxc2http://schemas.devexpress.com/winfx/2008/xaml/core  5      Adxdb6http://schemas.devexpress.com/winfx/2008/xaml/demobase  5      a ]DevExpress.Xpf.Grid.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v15.2.Core, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5      d `DevExpress.Xpf.Docking.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxdo5http://schemas.devexpress.com/winfx/2008/xaml/docking  5      <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5      ]	 YDevExpress.Mvvm.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aAdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm  	 5	      @dxn4http://schemas.devexpress.com/winfx/2008/xaml/navbar  	 5
      ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      j
 fDevExpress.Xpf.LayoutControl.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol 
 5      -   5          �Name$  
mainwindow��5       � Title$ Главное окно��5   	   $��699.757��6   $��1445.328��6/   &   DevExpress.Xpf.Core.ThemeManager   	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$ 
Office2013 6@    � Icon$< 6Images/Перемещать на тележке-32.png��6g    � WindowState$ 	Maximized=�6�   .��5      �  J� RenderTransformOrigin$ 	0.5,0.504&�6   .+�5   
   ]� ��. .+�5      -  'DevExpress.Xpf.Bars.BarContainerControl  $	��Top=�6'      Bars. 5      )  #DevExpress.Xpf.Bars.MainMenuControl  -   5          Name$ mainMenu��5   &   ,  &DevExpress.Xpf.Bars.ToolBarControlBase   Caption$ MainMenu��68   $��0q�6K   	   Items.	 5      $  DevExpress.Xpf.Bars.BarSubItem  !  DevExpress.Xpf.Bars.BarItem
   Content)  #DevExpress.Xpf.Core.ObjectConverter$
 СПРАВОЧНИКИ 6%      Items. 5      '	  !DevExpress.Xpf.Bars.BarButtonItem	  -   5         	 Name$	 Nom��5   ,   $
 Номенклатура 69      Glyph$  Images/Список-16.png��6j   	  5      -   5        $ 	brbt_char��5   ,   $;
 5Характеристики номенклатуры 6?   $5 /Images/Свойства сценария-16.png��6e   	  5      -   5        $ brbt_provider��5   ,   $
 Поставщики 6C   $ Images/Customer_16x16.png��6X   6z   	  5      -   5        $ brbt_employee��5   ,   $
 Сотрудники 6C   $ Images/Employee_16x16.png��6X   6z   	  5      -   5        $ brbt_customer��5   ,   $
 Объекты 6C   $" Images/Магазин-16.png��6y   	  5      -   5        $ brbtMeasure��5   ,   $'
 !Единицы измерения 6A   $ Images/Длина-16.png��6   	  5      -	   5        $ brbt_warehouse��5   ,   $
 Склады 6D   $ Images/Склад-16.png��6z   5        5      $
 ОТЧЕТЫ 6%   . 5       	  $
 Приход 6,   	  5!      $
 Расход 6,   	  5"      $
 Перемещение 6,   	  5#      -
   5         �Name$ 	bi_repost��5#   >   $
 Остатки 6,   6O   5%        5'      $#
 РАБОЧИЕ ПЕРИОДЫ 6%      BarItemDisplayMode$ Content=�6?   . 5(      	  $+
 %Приход номенклатуры 6,   5*        5+      $
 ПОМОЩЬ 6%   . 5,      	  $
 Справка 6,   $ Images/Question_16x16.png��6>   	  5-      $
 О прогрмамме 6,   $( "Images/Информация-16.png��6C   5.        5/      $
 
ВЫХОД 6%   . 50      	  -   5        $ 	btExitApp��50   ,   $
 Из приложения 6?   $ Images/Close_16x16.png��6W   6v   	  51      $&
  Из учетной записи 6,   $ Images/Выход-16.png��6H   52      54      55      *
  $DevExpress.Xpf.Bars.StatusBarControl
  56      -   5         
 Name$ 	statusBar��56   #   $��Bottom=�66   $ 	StatusBar��6N   .	 57      '  !DevExpress.Xpf.Bars.BarStaticItem  $

 Row: 6$      
ShowBorder .  63     58      $
 1 6$     59      $
 Column: 6$    .  66     5:      $
 1 6$     5;      $

 Info 6$      	Alignment$	 Far=�6�   $ ContentAndGlyph=�6�    .  63   *  $DevExpress.Xpf.Core.DXImageExtension     Image1  +DevExpress.Xpf.Core.Native.DXImageConverter$ Info_16x16.png    
LargeGlyph 6]     $ Info_32x32.png 6�   5<      � 5=      $
��0,10q�6   .+�5>      .  (DevExpress.Xpf.Docking.DockLayoutManager  -   5          Name$ DemoDockContainer��5>   )   $��1��6D      FloatingMode$ Desktop=�6Q      
LayoutRoot. 5@      (  "DevExpress.Xpf.Docking.LayoutGroup  -   5          Name$ lgMain��5@   '      Items. 5A      *  $DevExpress.Xpf.Docking.DocumentGroup  -   5          Name$ DocumentHost��5A   -      DestroyOnClosingChildren .  . 5B      *  $DevExpress.Xpf.Docking.DocumentPanel  +  %DevExpress.Xpf.Docking.BaseLayoutItem   Caption$ Документы��61      
AllowClose .  (  "DevExpress.Xpf.Docking.ContentItem   Content. 5D   "     -   5        $ doc_container��5D   9   $��1��6P   $ Desktop=�6]   . 5E   &     . 5F   *   (  "DevExpress.Xpf.Docking.TabbedGroup  . 5H   .   (  "DevExpress.Xpf.Docking.LayoutPanel  -   5          Name$ arrive_documents��5H   ?   $ Приход��6Y   $    HeaderBarContainerControlName$  SolutionBar��6k    .  !   	AllowHide! .  . 5J   2   �� .+�5K   6   (  "DevExpress.Xpf.Bars.ToolBarControl  $��Stretch=�6I   $��5, 5, 10, 10q�6e   .	 5L   :   	  -   5        $ but_add_arr��5L   L   $
 Добавить 6a   $' !UserControls/Images/Add_32x32.png��6�   $ ContentAndGlyph=�6�   "   GlyphAlignment$	" Top=�6�   #   	GlyphSize$# Large=�6�   	  5M   :   -   5        $ but_del_arr��5M   L   $
 Удалить 6a   $ Images/Cancel_32x32.png��6�   $ ContentAndGlyph=�6�   $	" Top=�6�   $# Large=�6�   	  5N   :   -   5        $ but_refresh_list_arr��5N   L   $
 Обновить 6j   $	" Top=�6�   $ Images/Refresh2_32x32.png��6�   $ ContentAndGlyph=�6�   $# Large=�6  	  5O   :   -   5        $ 
but_report��5O   L   $
 
Отчет 6`   $# Large=�6p   $	" Top=�6�   $) #UserControls/Images/Print_32x32.png��6�   $ ContentAndGlyph=�6�   6�   	  5P   :   -   5        $ but_help_arr��5P   L   $
 Справка 6b   $# Large=�6t   $	" Top=�6�   $, &UserControls/Images/Question_32x32.png��6�   $ ContentAndGlyph=�6�   5Q   7   %  DevExpress.Xpf.Grid.GridControl  5R   6   -   5        $  Name$$ gc_arrive_list��5R   F   )  #DevExpress.Xpf.Grid.DataControlBase%   AutoGenerateColumns$% AddNew=�6^   $	��300��6{   &   View& 5S   :   #  DevExpress.Xpf.Grid.TableView  5T   >   -   5        '  Name$' view_rgid_arr��5T   L   (   AllowPerPixelScrolling( . &   DevExpress.Xpf.Grid.DataViewBase)   ShowTotalSummary) . 6�   5V   7   &   DevExpress.Xpf.Core.DXTabControl  5X   6   $��0,20,0,0q�6F   .@�5Y   :   #  DevExpress.Xpf.Core.DXTabItem  �  �DevExpress.Xpf.Core.Native.HeaderedSelectorItemBase`2[[DevExpress.Xpf.Core.DXTabControl, DevExpress.Xpf.Core.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a],[DevExpress.Xpf.Core.DXTabItem, DevExpress.Xpf.Core.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]]*   Header$%* Детали документа��6G   .��5[   >   �� .+�5\   B     $��Stretch=�6U   $��	5,7,10,10q�6q   .	 5]   F   	  -   5        $ but_det_arr_add��5]   X   $
 Добавить 6q   $' !UserControls/Images/Add_16x16.png��6�   $	" Top=�6�   $# Small=�6�   $ ContentAndGlyph=�6�   	  5^   F   -   5        $ but_del_det_arr��5^   X   $
 Удалить 6q   $ ContentAndGlyph=�6�   $* $UserControls/Images/Cancel_16x16.png��6�   $	" Top=�6�   $# Small=�6  	  5_   F   -   5        $ but_refresh_det_arr��5_   X   $
 Обновить 6u   $	" Top=�6�   $# Small=�6�   $, &UserControls/Images/Refresh2_32x32.png��6�   $ ContentAndGlyph=�6  5a   C     5b   B   -   5        $$ gc_arrive_det��5b   R   $% AddNew=�6i   $
��1000��6�   & 5c   F     5d   J   ( . ) . 6v   5f   C   5g   ?   5h   ;   5i   7   5j   3   5l   /     5m   .   -   5        $ movement_documents��5m   ?   $ Перемещение��6[   $  SolutionBar��6r    .  ! .  . 5n   2   �� .+�5o   6     $��Stretch=�6I   $��5, 5, 10, 10q�6e   .	 5p   :   	  -   5        $ but_add_move��5p   L   $
 Добавить 6b   $' !UserControls/Images/Add_32x32.png��6�   $ ContentAndGlyph=�6�   $	" Top=�6�   $# Large=�6�   	  5q   :   -   5        $ but_del_move��5q   L   $
 Удалить 6b   $ Images/Cancel_32x32.png��6�   $ ContentAndGlyph=�6�   $	" Top=�6�   $# Large=�6�   	  5r   :   -    5        $ but_refresh_list_move��5r   L   $
 Обновить 6k   $	" Top=�6�   $ Images/Refresh2_32x32.png��6�   $ ContentAndGlyph=�6�   $# Large=�6  	  5s   :   -!   5        $ but_report_move��5s   L   $
 
Отчет 6e   $# Large=�6u   $	" Top=�6�   $) #UserControls/Images/Print_32x32.png��6�   $ ContentAndGlyph=�6�   6�   	  5t   :   -"   5        $ but_help_move��5t   L   $
 Справка 6c   $# Large=�6u   $	" Top=�6�   $, &UserControls/Images/Question_32x32.png��6�   $ ContentAndGlyph=�6�   5u   7     5v   6   -#   5        $$ gc_move_list��5v   F   $% AddNew=�6\   $	��300��6y   & 5w   :     5x   >   -$   5        $' view_rgid_move��5x   L   ( . ) . 6�   5z   7     5|   6   $��0,20,0,0q�6F   .@�5}   :     $%* Детали документа��6G   .��5   >   �� .+�5�   B     $��Stretch=�6U   $��	5,7,10,10q�6q   .	 5�   F   	  -%   5        $ but_det_arr_move��5�   X   $
 Добавить 6r   $' !UserControls/Images/Add_16x16.png��6�   $	" Top=�6�   $# Small=�6�   $ ContentAndGlyph=�6�   6�   	  5�   F   -&   5        $ but_del_det_move��5�   X   $
 Удалить 6r   $ ContentAndGlyph=�6�   $* $UserControls/Images/Cancel_16x16.png��6�   $	" Top=�6�   $# Small=�6�   6   	  5�   F   -'   5        $ but_refresh_det_move��5�   X   $
 Обновить 6v   $	" Top=�6�   $# Small=�6�   $, &UserControls/Images/Refresh2_32x32.png��6�   $ ContentAndGlyph=�6�   6  5�   C     5�   B   -(   5        $$ gc_move_det��5�   R   $% AddNew=�6g   $
��1000��6�   & 5�   F     5�   J   ( . ) . 6v   5�   C   5�   ?   5�   ;   5�   7   5�   3   5�   /     5�   .   -)   5        $ leave_documents��5�   ?   $ Расход��6X   $  SolutionBar��6j    .  ! .  . 5�   2   �� .+�5�   6     $��Stretch=�6I   $��5, 5, 10, 10q�6e   .	 5�   :   	  -*   5        $ but_add_leave��5�   L   $
 Добавить 6c   $' !UserControls/Images/Add_32x32.png��6�   $ ContentAndGlyph=�6�   $	" Top=�6�   $# Large=�6�   	  5�   :   -+   5        $ but_del_leave��5�   L   $
 Удалить 6c   $ Images/Cancel_32x32.png��6�   $ ContentAndGlyph=�6�   $	" Top=�6�   $# Large=�6�   	  5�   :   -,   5        $ but_refresh_list_leave��5�   L   $
 Обновить 6l   $	" Top=�6�   $ Images/Refresh2_32x32.png��6�   $ ContentAndGlyph=�6�   $# Large=�6  	  5�   :   --   5        $ but_report_leave��5�   L   $
 
Отчет 6f   $# Large=�6v   $	" Top=�6�   $) #UserControls/Images/Print_32x32.png��6�   $ ContentAndGlyph=�6�   6�   	  5�   :   -.   5        $ but_help_leave��5�   L   $
 Справка 6d   $# Large=�6v   $	" Top=�6�   $, &UserControls/Images/Question_32x32.png��6�   $ ContentAndGlyph=�6�   5�   7     5�   6   -/   5        $$ gc_leave_list��5�   F   $% AddNew=�6]   $	��300��6z   & 5�   :     5�   >   -0   5        $' view_rgid_leave��5�   L   ( . ) . 6�   5�   7     5�   6   $��0,20,0,0q�6F   .@�5�   :     $%* Детали документа��6G   .��5�   >   �� .+�5�   B     $��Stretch=�6U   $��	5,7,10,10q�6q   .	 5�   F   	  -1   5        $ but_det_leave_add��5�   X   $
 Добавить 6s   $' !UserControls/Images/Add_16x16.png��6�   $	" Top=�6�   $# Small=�6�   $ ContentAndGlyph=�6�   6�   	  5�   F   -2   5        $ but_del_det_leave��5�   X   $
 Удалить 6s   $ ContentAndGlyph=�6�   $* $UserControls/Images/Cancel_16x16.png��6�   $	" Top=�6�   $# Small=�6�   6   	  5�   F   -3   5        $ but_refresh_det_leave��5�   X   $
 Обновить 6w   $	" Top=�6�   $# Small=�6�   $, &UserControls/Images/Refresh2_32x32.png��6�   $ ContentAndGlyph=�6�   6  5�   C     5�   B   -4   5        $$ gc_leave_det��5�   R   $% AddNew=�6h   $
��1000��6�   & 5�   F     5�   J   ( . ) . 6v   5�   C   5�   ?   5�   ;   5�   7   5�   3   5�   /   5�   +   5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      5�      