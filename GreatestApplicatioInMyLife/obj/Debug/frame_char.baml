   M S B A M L   `   `   `  ����  GreatestApplicatioInMyLife+    %GreatestApplicatioInMyLife.frame_char   5   
   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   a ]DevExpress.Xpf.Core.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a<dxc2http://schemas.devexpress.com/winfx/2008/xaml/core  5      Adxdb6http://schemas.devexpress.com/winfx/2008/xaml/demobase  5      a ]DevExpress.Xpf.Grid.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v15.2.Core, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5      d `DevExpress.Xpf.Docking.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxdo5http://schemas.devexpress.com/winfx/2008/xaml/docking  5      <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5      ]	 YDevExpress.Mvvm.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aAdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm  	 5	      @dxn4http://schemas.devexpress.com/winfx/2008/xaml/navbar  	 5
      ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      j
 fDevExpress.Xpf.LayoutControl.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol 
 5      -   5          �Name$  
mainwindow��5      &   DevExpress.Xpf.Core.ThemeManager   	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$ 
Office2013 5   
    � Title$; 5Характеристика номенклатуры��5   	   $��504.202��6-   $��662.606��6>   .��5      �  � RowDefinitions 5   
   �� 5      $
��421* �6   �� 5      $	��55* �6    � ColumnDefinitions 5   
   �� 5      $
��222* �6   �� 5      $
��421* �6   .+�5   
   �� $��0��6   $��2��6%   .+�5      %  DevExpress.Xpf.Grid.GridControl  -   5        $��grid_tree_char��5   q   )  #DevExpress.Xpf.Grid.DataControlBase   AutoGenerateColumns$ AddNew=�6   #   EnableSmartColumnsGeneration . $��0,0,10,0q�6_   $
��1000��6�      View 5      #  DevExpress.Xpf.Grid.TableView  5         AllowPerPixelScrolling . &   DevExpress.Xpf.Grid.DataViewBase	   ShowTotalSummary	 . 6B   5!      5$      �� 5%   
   $��1��6   $��10,0,0,0q�6%   $��2��67   .+�5&        -   5        $��grid_master_char��5&   m   $ AddNew=�6    . $
��10,0q�6_   $
��1000��6�    5'        5(       . 	 . 6B   5*      5-      �� 5.   
   $��1��6   $��1��6%   .+�5/      a� -   5        
 a�Name$
 tbp_frame_char��5/       �� Orientation$ 
Horizontal=�63   $��Bottom=�6L   $��
20,20,10,0q�6g   .+�50      �� -   5         ��Name$ 	bt_create��50      $��Добавить��6,   $��
200,0,30,0q�6?   $��12(�6m   �� 52      -   5        $ 	bt_cancel��52      $��Закрыть��6,   $��12(�6W   53      54      56      57      