   M S B A M L   `   `   `  ����  GreatestApplicatioInMyLife1    +GreatestApplicatioInMyLife.report_frame_ost   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   a ]DevExpress.Xpf.Core.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a<dxc2http://schemas.devexpress.com/winfx/2008/xaml/core  5      Adxdb6http://schemas.devexpress.com/winfx/2008/xaml/demobase  5      a ]DevExpress.Xpf.Grid.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v15.2.Core, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5      d `DevExpress.Xpf.Docking.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxdo5http://schemas.devexpress.com/winfx/2008/xaml/docking  5      <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5      ]	 YDevExpress.Mvvm.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aAdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm  	 5	      c
 _DevExpress.Xpf.NavBar.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxn4http://schemas.devexpress.com/winfx/2008/xaml/navbar 
 5
      ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      j fDevExpress.Xpf.LayoutControl.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  5      -   5        &   DevExpress.Xpf.Core.ThemeManager    	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$  
Office2013 5       � Title$&  Отчет по остаткам��5   	   $��503.277��6#   $��434.091��64    � WindowStartupLocation$ CenterScreen=�6a    � Icon$; 5Images/Параметры сортировки-16.png��6�   .��5      � $��	10,0,0,-1q�6    � ColumnDefinitions 5   
   �� 5      $	��65* �6   �� 5      $	��77* �6    � RowDefinitions 5   
   �� 5      $	��41* �6   �� 5      $
��192* �6   �� 5      $
��210* �6   �� 5      $	��75* �6   .+�5   
   �� -   5        $��
main_lable��5   a   $��Остатки��6   $��2��6"   $��24(�66   $��Center=�6D   6a   �� 5   
   $��2��6   $��1��6)   $	��242��66   $	��Top=�6C   $��2��6[   .+�5      �� $��Период��6   $��Center=�6%   �� 5      
���   �$��1q�6)    �� Padding$ 
12,12,0,12q�6=   $
��12,0q�6R    �� CornerRadius$ 5��6`   ��5       �� 5!       �� EndPoint$ 0.5,1&�6*   	 � MappingMode$	 RelativeToBoundingBox=�6;   
 �� 
StartPoint$
 0.5,0&�6_   .��5"      �  � Color$ White��6'    � Offset$ 1Q�65   � 5#      $ 	#FF2A83AC��6'   � 5$      $ 	#FFCEE2EC��6'   � 5%      $ 	#FF6AB5FF��6'   $ 1Q�69   5&      ._�5(      � $��0,0,9,0q�6    5)      �� 5*      $
��173* �6+   �� 5+      $
��215* �6+   .+�5-      �� $��0��6!   .+�5.      	� -   5        $��rb_wp��5.   X   $0��*Текущий рабочий период��6&   $��0,0,0,7q�6G   6e   	� 5/      -   5        $��rb_cust��5/   J   $��Произвольный��6&   $	��0,7q�6=   6Y   50      �� 51      
���   �$��1��61   $��1q�6A   $ 
12,12,0,12q�6U   $
��12,0q�6j   $ 5��6x   ._�52      �� -   5         ��Name$ sp_date��52   %   .+�54      �� $��На дату:��6$   $
��Left=�67   (  "System.Windows.Controls.DatePicker  55      -   5          Name$ dp_to��55   )   68   56      57      58      59      5:      �� 5=   
   $��2��6   $��2��6)   .+�5>      �� $��Номенклатура��6   $��Center=�6+   �� 5?      
���   �$��1q�6)   $ 
12,12,0,12q�6=   $
��12,0q�6R   $ 5��6`   ��5@      �� 5A      $ 0.5,1&�6*   $	 RelativeToBoundingBox=�6;   $
 0.5,0&�6_   .��5B      � $ White��6'   $ 1Q�65   � 5C      $ 	#FF2A83AC��6'   � 5D      $ 	#FFCEE2EC��6'   � 5E      $ 	#FF6AB5FF��6'   $ 1Q�69   5F      ._�5H      � $��0,0,9,0q�6    5I      �� 5J      $
��173* �6+   �� 5K      $
��215* �6+   .+�5M      �� $��0��6!   .+�5N      	� -   5        $��	rb_allnom��5N   R   $%��Вся номенклатура��6&   $��0,0,0,7q�6A   6c   	� 5O      -   5        $��
rb_namenom��5O   J   $��Наименование��6&   $	��0,7q�6=   6\   	� 5P      -	   5        $��rb_groupnom��5P   D   $��Группа��6&   $	��0,7q�67   6W   5Q      �� 5R      
���   �$��1��61   $��1q�6A   $ 12,12,12,12q�6U   $'��!12                             ,0q�6k   $ 5��5S   !   ._�5T      �� -
   5        $��sp_nom��5T   %   .+�5W      )  #DevExpress.Xpf.Editors.ComboBoxEdit  -   5        $��cb_nom��5W   A   $��0,10,0,0q�6/   6O   5Z      5[      5\      5]      5^      a� 5`   
   -   5         a�Name$ tbp_main_window_di��5`       �� Orientation$ 
Horizontal=�63   $��Bottom=�6L   $��
10,0,10,20q�6g   $��2��6{   $��3��6�   $��30��6�   .+�5a      �� -   5         ��Name$ bt_help��5a      $��Справка��6&   $��74��68   6C   �� 5b      -   5        $ bt_show��5b      $��Просмотр��6&   $��
100,0,30,0q�69   $��96��6N   6Y   �� 5d      -   5        $ bt_can��5d      $��Отмена��6%   $��82��66   6A   5f      5h      5i      