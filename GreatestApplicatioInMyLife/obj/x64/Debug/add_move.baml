   M S B A M L   `   `   `  ����  GreatestApplicatioInMyLife)    #GreatestApplicatioInMyLife.add_move   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   a ]DevExpress.Xpf.Core.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5   
   ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5   
   -   5          �Name$  window_add_arr��5   L   &   DevExpress.Xpf.Core.ThemeManager   	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$ 	LightGray 5   	    � Title$1 +Добавление перемещения��5   	   $��214.733��6(   $	��300��69    � WindowStartupLocation$ CenterScreen=�6j    � Icon$) #Images/icons8-Коробка-16.png��6�   .��5      �� .+�5	   
   �� $%��Склад получатель��6   $��25,0,0,0q�6+   )  #DevExpress.Xpf.Editors.ComboBoxEdit  5
   
   -   5          Name$ cb_wh��5
      $	��250��6*   $
��Left=�66   $��	25,0,0,15q�6Q   �� 5   
   $��Комментарий:��6   $��25,0,0,0q�6'   %  DevExpress.Xpf.Editors.MemoEdit  5   
   -   5          Name$ comment_arr��5      $	��250��6,   $
��Left=�69   $��	25,0,0,15q�6T   %  DevExpress.Xpf.Editors.BaseEdit   AllowNullInput . '    AllowUpdateTextBlockWhenPrinting . 6}   a� 5   
   -   5        	 a�Name$	 tbp_main_window_di��5      
 �� Orientation$
 
Horizontal=�63   $��Bottom=�6L   $��
10,15,10,0q�6g   .+�5      �� -   5         ��Name$ bt_create_arr��5      $��Создать��6,   $��	58,0,30,0q�6>   6Q   �� 5      -   5        $ bt_can_cr_arr��5      $��Отмена��6,   6=   5      5      5      