   M S B A M L   `   `   `  ����  GreatestApplicatioInMyLife+    %GreatestApplicatioInMyLife.pas_change   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   a ]DevExpress.Xpf.Core.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5   
   ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5   
   -   5          �Name$  window_change_pas��5   L   &   DevExpress.Xpf.Core.ThemeManager   	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$ 	LightGray 5   	    � Title$% Изменение пароля��5   	   $��260.187��6"   $��331.818��63    � WindowStartupLocation$ CenterScreen=�6D    � Icon$' !Images/icons8-Пароль-32.png��6i   .��5      �� .+�5
   
   �� $ ��Старый пароль:��6   $��	49,25,0,0q�6)   ,  &DevExpress.Xpf.Editors.PasswordBoxEdit  5   
   -   5          Name$ oldpas��5      $	��250��6.   $��Center=�6;   $��	25,0,0,15q�6X   %  DevExpress.Xpf.Editors.BaseEdit   AllowNullInput . '    AllowUpdateTextBlockWhenPrinting . 6�   �� 5   
   $��Новый пароль:��6   $��49,2,0,0q�6(     5   
   -   5        $ newpas��5      $	��250��6.   $��Center=�6;   $��	25,0,0,15q�6X    .  . 6�   a� 5   
   -   5         a�Name$ tbp_main_window_di��5      	 �� Orientation$	 
Horizontal=�63   $��Bottom=�6L   $��
10,15,10,0q�6g   .+�5      �� -   5        
 ��Name$
 bt_change_pas��5      $��Изменить��6,   $��	58,0,30,0q�6?   {�.  6d   �� 5      -   5        $
 bt_can��5      $��Отмена��6%   5      5      5      