   M S B A M L   `   `   `  ����  GreatestApplicatioInMyLife4    .GreatestApplicatioInMyLife.report_frame_arrive   5   
   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   a ]DevExpress.Xpf.Core.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a<dxc2http://schemas.devexpress.com/winfx/2008/xaml/core  5      Adxdb6http://schemas.devexpress.com/winfx/2008/xaml/demobase  5      a ]DevExpress.Xpf.Grid.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v15.2.Core, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5      d `DevExpress.Xpf.Docking.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxdo5http://schemas.devexpress.com/winfx/2008/xaml/docking  5      <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5      ]	 YDevExpress.Mvvm.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aAdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm  	 5	      c
 _DevExpress.Xpf.NavBar.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxn4http://schemas.devexpress.com/winfx/2008/xaml/navbar 
 5
      ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      j fDevExpress.Xpf.LayoutControl.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  5      &   DevExpress.Xpf.Core.ThemeManager    	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$  
Office2013 5       � Title$$ Отчет по приходу��5   	   $��503.277��6"   $��434.091��63   .��5      � $��	10,0,0,-1q�6    � ColumnDefinitions 5   
   �� 5      $	��65* �6   �� 5      $	��77* �6    � RowDefinitions 5   
   �� 5      $	��41* �6   �� 5      $
��192* �6   �� 5      $
��210* �6   �� 5      $	��75* �6   .+�5   
   �� $��Остатки��6   $��2��6"   $��24(�66   $��Center=�6D   �� 5   
   $��2��6   $��1��6)   $	��242��66   $	��Top=�6C   $��2��6[   .+�5      �� $��Период��6   $��Center=�6%   �� 5      
���   �$��1q�6)    �� Padding$ 
12,12,0,12q�6=   $
��12,0q�6R    �� CornerRadius$ 5��6`   ��5       �� 5!       �� EndPoint$ 0.5,1&�6*    � MappingMode$ RelativeToBoundingBox=�6;    �� 
StartPoint$ 0.5,0&�6_   .��5"      � 	 � Color$	 White��6'   
 � Offset$
 1Q�65   � 5#      $	 	#FF2A83AC��6'   � 5$      $	 	#FFCEE2EC��6'   � 5%      $	 	#FF6AB5FF��6'   $
 1Q�69   5&      ._�5(      � $��0,0,9,0q�6    5)      �� 5*      $
��173* �6+   �� 5+      $
��215* �6+   .+�5-      �� $��0��6!   .+�5.      	� -   5        $��rb_wp��5.   X   $0��*Текущий рабочий период��6&   $��0,0,0,7q�6G   6X   	� 5/      -   5        $��rb_cust��5/   J   $��Произвольный��6&   $	��0,7q�6=   6J   50      �� 51      
���   �$��1��61   $��1q�6A   $ 
12,12,0,12q�6U   $
��12,0q�6j   $ 5��6x   ._�52      �� -   5         ��Name$ sp_date��52   %   .+�53      �� $	��С:��6$   $
��Left=�61   (  "System.Windows.Controls.DatePicker  54      -   5          Name$ dp_from��54   )   �� 55      $��По:��6$   $
��Left=�62     56      -   5        $ dp_to��56   )   57      58      59      5:      5;      �� 5>   
   $��2��6   $��2��6)   .+�5?      �� $��Номенклатура��6   $��Center=�6+   �� 5@      
���   �$��1q�6)   $ 
12,12,0,12q�6=   $
��12,0q�6R   $ 5��6`   ��5A      �� 5B      $ 0.5,1&�6*   $ RelativeToBoundingBox=�6;   $ 0.5,0&�6_   .��5C      � $	 White��6'   $
 1Q�65   � 5D      $	 	#FF2A83AC��6'   � 5E      $	 	#FFCEE2EC��6'   � 5F      $	 	#FF6AB5FF��6'   $
 1Q�69   5G      ._�5I      � $��0,0,9,0q�6    5J      �� 5K      $
��173* �6+   �� 5L      $
��215* �6+   .+�5N      �� $��0��6!   .+�5O      	� -   5        $��	rb_allnom��5O   R   $%��Вся номенклатура��6&   $��0,0,0,7q�6A   6R   	� 5P      -   5        $��
rb_namenom��5P   J   $��Наименование��6&   $	��0,7q�6=   6J   	� 5Q      -   5        $��rb_groupnom��5Q   D   $��Группа��6&   $	��0,7q�67   6D   5R      �� 5S      
���   �$��1��61   $��1q�6A   $ 12,12,12,12q�6U   $'��!12                             ,0q�6k   $ 5��5T   !   ._�5U      �� -	   5        $��sp_nom��5U   %   .+�5X      )  #DevExpress.Xpf.Editors.ComboBoxEdit  -
   5        $��cb_nom��5X   A   $��0,10,0,0q�6/   6A   5[      5\      5]      5^      5_      a� 5a   
   -   5         a�Name$ tbp_main_window_di��5a       �� Orientation$ 
Horizontal=�63   $��Bottom=�6L   $��
10,0,10,20q�6g   $��2��6{   $��3��6�   $��30��6�   .+�5b      �� -   5         ��Name$ bt_help��5b      $��Справка��6&   $��74��68   �� 5c      -   5        $ bt_show��5c      $��Просмотр��6&   $��
100,0,30,0q�69   $��96��6N   �� 5e      -   5        $ bt_can��5e      $��Отмена��6%   $��82��66   5g      5i      5j      