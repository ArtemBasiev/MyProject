   M S B A M L   `   `   `  ����   GreatestApplicatioInMyLife*    $GreatestApplicatioInMyLife.AutWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     a ]DevExpress.Xpf.Core.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  -     �Name$  	autwindow��&   DevExpress.Xpf.Core.ThemeManager   	ThemeName0  *DevExpress.Xpf.Core.ThemeNameTypeConverter$ 	LightGray  � Title$ Авторизация��$��295.5��$��475.5�� � WindowStartupLocation$ CenterScreen=� � Icon$ Images/Employee_16x16.png��.���� $��1q� �� Padding$ 
12,12,0,12q� �� CornerRadius$ 5��$��0,0,0,-1q�����  �� EndPoint$ 0.5,1&� � MappingMode$ RelativeToBoundingBox=�	 �� 
StartPoint$	 0.5,0&�.��� 
 � Color$
 White�� � Offset$ 1Q�� $
 	#FF2A83AC��� $
 	#FFCEE2EC��� $
 	#FF6AB5FF��$ 1Q�._�� $��0,0,9,0q� � ColumnDefinitions �� $
��173* ��� $
��215* �.+��� $��0��.+�	� -   $��rb_user��$��Пользователь��$��0,0,0,7q�	� -   $��rb_admin��$ ��Администратор��$	��0,7q��� 
���   �$��1��$��1q�$ 
12,12,0,12q�$
��12,0q�$ 5��._��� .+��� -   $��sp_admin��$y�	Collapsed=�.+��� $!��Введите пароль��$��Center=�$	��Top=�$��0,8,0,0q�,  &DevExpress.Xpf.Editors.PasswordBoxEdit  -   $��pb_admin��$��Center=�$	��Top=�$	��150��$��0,8,0,0q�%  DevExpress.Xpf.Editors.BaseEdit   	EditValue.   $	��100��$	��150���� -    ��Name$ 
btLoginAdm��$��
Войти��$��Center=�$	��Top=�$��58��$��0,8,0,0q��� -    ��Name$ sp_login��$y�Hidden=�.+��� $!��Выберите склад��$��Center=�$	��Top=�$��89�� J� RenderTransformOrigin$ 0.573,0.591&�)  #DevExpress.Xpf.Editors.ComboBoxEdit  -     Name$ cb_choose_war��$��Center=�$	��Top=�$	��150��$��0,8,0,0q��� $/��)Выберите пользователя��$��Center=�$	��Top=�$��0,8,0,0q�  -	   $ cb_choose_user��$��Center=�$	��Top=�$	��150��$��0,8,0,0q��� $!��Введите пароль��$��Center=�$	��Top=�$��0,8,0,0q�  -
   $��pb_user��$��Center=�$	��Top=�$	��150��$��0,8,0,0q�.   $	��100��$	��150���� -   $ btLogin��$��
Войти��$��Center=�$	��Top=�$��58��$��0,8,0,0q�