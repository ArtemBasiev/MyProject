   M S B A M L   `   `   `  ����   GreatestApplicatioInMyLife1    +GreatestApplicatioInMyLife.report_frame_ost   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     a ]DevExpress.Xpf.Core.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a<dxc2http://schemas.devexpress.com/winfx/2008/xaml/core  Adxdb6http://schemas.devexpress.com/winfx/2008/xaml/demobase  a ]DevExpress.Xpf.Grid.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v15.2.Core, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   d `DevExpress.Xpf.Docking.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxdo5http://schemas.devexpress.com/winfx/2008/xaml/docking  <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  ]	 YDevExpress.Mvvm.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aAdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm  	 @dxn4http://schemas.devexpress.com/winfx/2008/xaml/navbar  	 ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  j
 fDevExpress.Xpf.LayoutControl.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol 
 -   &   DevExpress.Xpf.Core.ThemeManager    	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$  
Office2013  � Title$&  Отчет по остаткам��$��503.277��$��434.091�� � WindowStartupLocation$ CenterScreen=� � Icon$; 5Images/Параметры сортировки-16.png��.��� $��	10,0,0,-1q� � ColumnDefinitions �� $	��65* ��� $	��77* � � RowDefinitions �� $	��41* ��� $
��192* ��� $
��210* ��� $	��75* �.+��� $��Остатки��$��2��$��24(�$��Center=��� $��2��$��1��$	��242��$	��Top=�$��2��.+��� $��Период��$��Center=��� 
���   �$��1q� �� Padding$ 
12,12,0,12q�$
��12,0q� �� CornerRadius$ 5������  �� EndPoint$ 0.5,1&�	 � MappingMode$	 RelativeToBoundingBox=�
 �� 
StartPoint$
 0.5,0&�.���  � Color$ White�� � Offset$ 1Q�� $ 	#FF2A83AC��� $ 	#FFCEE2EC��� $ 	#FF6AB5FF��$ 1Q�._�� $��0,0,9,0q� �� $
��173* ��� $
��215* �.+��� $��0��.+�	� -   $��rb_wp��$0��*Текущий рабочий период��$��0,0,0,7q�	� -   $��rb_cust��$��Произвольный��$	��0,7q��� 
���   �$��1��$��1q�$ 
12,12,0,12q�$
��12,0q�$ 5��._��� -    ��Name$ sp_date��.+��� $��На дату:��$
��Left=�(  "System.Windows.Controls.DatePicker  -     Name$ dp_to���� $��2��$��2��.+��� $��Номенклатура��$��Center=��� 
���   �$��1q�$ 
12,12,0,12q�$
��12,0q�$ 5������ $ 0.5,1&�$	 RelativeToBoundingBox=�$
 0.5,0&�.��� $ White��$ 1Q�� $ 	#FF2A83AC��� $ 	#FFCEE2EC��� $ 	#FF6AB5FF��$ 1Q�._�� $��0,0,9,0q� �� $
��173* ��� $
��215* �.+��� $��0��.+�	� -   $��	rb_allnom��$%��Вся номенклатура��$��0,0,0,7q�	� -   $��
rb_namenom��$��Наименование��$	��0,7q�	� -   $��rb_groupnom��$��Группа��$	��0,7q��� 
���   �$��1��$��1q�$ 12,12,12,12q�$'��!12                             ,0q�$ 5��._��� -	   $��sp_nom��.+�)  #DevExpress.Xpf.Editors.ComboBoxEdit  -
   $��cb_nom��$��0,10,0,0q�a� -    a�Name$ tbp_main_window_di�� �� Orientation$ 
Horizontal=�$��Bottom=�$��
10,0,10,20q�$��2��$��3��$��30��.+��� -    ��Name$ bt_help��$��Справка��$��74���� -   $ bt_show��$��Просмотр��$��
100,0,30,0q�$��96���� -   $ bt_can��$��Отмена��$��82��