   M S B A M L   `   `   `  ����N  JStudentManagement_S, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:StudentManagement_SStudentManagement_S  5   	   %    StudentManagement_S.LoginWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:StudentManagement_S     5   	   ^ ZMahApps.Metro.IconPacks, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137am iMahApps.Metro.IconPacks.BootstrapIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag	 cMahApps.Metro.IconPacks.BoxIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag
 cMahApps.Metro.IconPacks.Codicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah dMahApps.Metro.IconPacks.Coolicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ac _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ae aMahApps.Metro.IconPacks.Entypo, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.EvaIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ak gMahApps.Metro.IconPacks.FeatherIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah dMahApps.Metro.IconPacks.FileIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah dMahApps.Metro.IconPacks.Fontaudio, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj fMahApps.Metro.IconPacks.FontAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Fontisto, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj fMahApps.Metro.IconPacks.ForkAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Ionicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.JamIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137am iMahApps.Metro.IconPacks.MaterialDesign, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137al hMahApps.Metro.IconPacks.MaterialLight, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137af bMahApps.Metro.IconPacks.Microns, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ae aMahApps.Metro.IconPacks.Modern, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Octicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai eMahApps.Metro.IconPacks.PicolIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137al hMahApps.Metro.IconPacks.PixelartIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai eMahApps.Metro.IconPacks.RadixIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah  dMahApps.Metro.IconPacks.RemixIcon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai! eMahApps.Metro.IconPacks.RPGAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj" fMahApps.Metro.IconPacks.SimpleIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag# cMahApps.Metro.IconPacks.Typicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137af$ bMahApps.Metro.IconPacks.Unicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj% fMahApps.Metro.IconPacks.VaadinIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ak& gMahApps.Metro.IconPacks.WeatherIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah' dMahApps.Metro.IconPacks.Zondicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137axIcon-http://metro.mahapps.com/winfx/xaml/iconpacks!   	 
                        ! " # $ % & ' 5   	     � Title$  LoginWindow��5	   	   $	��450��6   $	��800��6*    � WindowStyle$
 None=�5
   
    � 
ResizeMode$ CanResizeWithGrip=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   
������  � AllowsTransparency$
 True��5   	    � DataContext 5      '   !StudentManagement_S.LoginWindowVM  5   
    � 	Resources 5         BooleanToVisibility��%   &	        �� 5   
   6'   5      y�5      �� 5   
    �� Path$ IsViewVisible�6    �� Mode$ TwoWay=�6'   	 �� 	Converter#	 [  65   .��5      �� 
 �� CornerRadius$
 30��6   ._�5   
   � .+�5      �� $
 30��6   $��2q�5       J� Opacity$ 1Q�5      ��5"      �� 5#       �� 
StartPoint$	 0,0&�6*    �� EndPoint$	 1,1&�6;   .��5$      �  � Color$ #462AD8��6'    � Offset$ 0Q�67   � 5%      $ #DA34AE��6'   $
 0.75Q�67   � 5&      $ #8A16C1��6'   $ 1Q�67   5'      ��5*      �� 5+      $	 0,1&�6*   $	 1,0&�6;   .��5,      � $ #000080��6'   $ 0Q�67   � 5-      $ #000033��6'   $ 1Q�67   5.      ._�53      � .+�54      �� $
 30��6   ��55      �� 56       j� Stretch$ UniformToFill=�6)    �� Opacity$
 0.40Q�6A    �� ImageSource$ \images\loging.png��57   )   59      � 5:       � ColumnDefinitions 5=      �� 5>      �� 5?      .+�5B      � $��0��6     � RowDefinitions 5C      �� 5D   "   $��40 �60   �� 5E   "   .+�5H      � $��1��6#   .+�5I   "   �� $��WELCOME��6,   $��1��6;   
�������$��40(�5K       $��Medium"�5L       $��
Montserrat)�5M       $��Center=�69   $��Center=�5N       5O      5P      � 5S      $��1��6   $��0,0,10,0q�6/    5U      �� 5V   "   $��40 �60   �� 5W   "   $��* �60   �� 5X   "   $��54 �60   �� 5Y   "   $��54 �60   �� 5Z   "   $��54 �60   �� 5[   "   $��* �60   .+�5_      � $��0��6#    5a   "   �� 5b   &   �� 5c   &   $��30 �67   �� 5d   &   $��30 �67   �� 5e   &   $��30 �67   �� 5f   &   $��5 �67   .+�5k   "   �� -   5         ��Name$ btnMinimize��5k   )   $��3q�5l   )   $��-��5m   )   
�������$��16(�5o   )   $��
Montserrat)�5p   )    � Cursor$
 Hand��5q   )   $��1��67   $��40��5r   C   $	��Top=�6O   ��5t   &   �� 5u   *    �� 
TargetType" ��60   .�5v   .   ��  �� Property � �� �� Value
 �   �6K    �� Triggers 5w   .   P� 5x   2    P� Property �@J�IsMouseOver P� Value$
 True��6Q   . �5y   6   ��  � �� �#000DFF6S   5z   3   5|   +   ��5   &   �� 5�   *    �� 
TargetType" ��6:   .R�5�   .   �� $��25��65   $��25��6@   $
 5��5�   5   #��z��5�   5   ._�5�   2   �� $��Center=�6C   $��Center=�5�   C   5�   /   5�   +   5�   #   �� 5�   "   -   5        $ 	btnResize��5�   )   $��0q�5�   )   $	��⤢��5�   )   
�������$��12(�5�   )   $��
Montserrat)�5�   )   $
 Hand��5�   )   $��2��5�   )   ��5�   &   �� 5�   *   " ��60   .�5�   .   ��  � ��
 �   �6K    5�   .   P� 5�   2    �@J�IsMouseOver$
 True��6Q   . �5�   6   ��  � �� �#1CF52A6S   5�   3   5�   +   ��5�   &   �� 5�   *   " ��6:   .R�5�   .   �� $��25��65   $��25��6@   $
 5��5�   5   #��z��5�   5   ._�5�   2   �� $��Center=�6C   $��Center=�5�   5   5�   /   5�   +   5�   #   �� 5�   "   -   5        $ btnClose��5�   )   $��0q�5�   )   $��X��5�   )   
�������$��12(�5�   )   $��
Montserrat)�5�   )   $
 Hand��5�   )   $��3��5�   )   ��5�   &   �� 5�   *   " ��60   .�5�   .   ��  � ��
 �   �6K    5�   .   P� 5�   2    �@J�IsMouseOver$
 True��6Q   . �5�   6   ��  � �� �#FF17006S   5�   3   5�   +   ��5�   &   �� 5�   *   " ��6:   .R�5�   .   �� $��25��65   $��25��6@   $
 5��5�   5   #��z��5�   5   ._�5�   2   �� $��Center=�6C   $��Center=�5�   7   5�   /   5�   +   5�   #   5�      � 5�      $��2��6#   $��0 0 20 0q�60    5�   "   �� 5�   &   $	��365 �67   �� 5�   &   $��* �67   .+�5�   "   � $��0��6'    5�   &   �� 5�   *   $	��75* �6;   �� 5�   *   $
��109* �6;   .+�5�   &   �� $��1q�6-   ���#acb0af$
 5��5�   '   $��0,7,0,7q�68   $��2��6I   ._�5�   *   � $	��7 9q�6/   .+�5�   .   .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ Account=�6D   ���#acb0af$��20��5�   L   $��Center=�6X   $��Stretch=�6u   $��32��6�   $��-150,0,160,0q�6�   �� 5�   .   $��Username��68   $��
62,0,-62,0q�6H   
����� �6\   �� 5�   .   -   5         ��Name$ UsernameTextBox��5�   6   $��
132,0,20,0q�6v   
����������	#FF56264C��6O   �� *
Username+$ TwoWay=�6�   5�   +   5�   '   5�   #   5�      � 5�      $��3��6#   $��0q�60    5�   "   �� 5�   &   $	��365 �67   �� 5�   &   $��* �67   .+�5�   "   � $��0��6'    5�   &   �� 5�   *   $	��75* �6;   �� 5�   *   $
��109* �6;   .+�5�   &   �� $��1q�6-   ���#acb0af$
 5��5�   '   $��0,7,0,7q�68   $��2��6I   ._�5�   *   � $	��7 9q�6/   .+�5�   .     $
 Lock=�6D   ���#acb0af$��20��5�   L   $��Center=�6X   $��Stretch=�6u   $��32��6�   $��-150,0,160,0q�6�   �� 5�   .   $��Password��68   $��
62,0,-62,0q�6H   
����� �6\   �� 5�   .   -   5        $ passwordTextBox��5�   6   $��
132,0,20,0q�6v   
���������6O   �� *
Password+$ TwoWay=�6�   5�   +   5�   '   5�   #   5�      � 5      $��4��6#   $��0,2,2,0q�60   $��2��6A   $	��Top=�6R   .+�5  "   � $	��0 9q�6'    5  &   �� 5  *   $	��170 �6;   �� 5  *   $��60 �6;   �� 5  *   $��* �6;   .+�5
  &   � $��1��6+   .+�5  *   �� $��0q�61   $��Login��6<     J� RenderTransformOrigin$  0.49,-0.579&�6m     LoginButton#��[ 6�   ��6L   �� *LoginCommand+6�   5  '   5  #   5     � 5     $��5��6#   .+�5  "   �� .+�5  "   �� $��Logig Information��6,   $��
62,0,-62,0q�6E   
����� �6Y   �� 5  "   $��Admin��6,   $��
62,0,-62,0q�69   
����� �6M   �� 5  "   $(��"User Name : user   Password : aaaa��6,   $��
62,0,-62,0q�6V   
����� �6j   �� 5  "   $��Student��6,   $��
62,0,-62,0q�6;   
����� �6O   �� 5  "   $(��"User Name : user   Password : aaaa��6,   $��
62,0,-62,0q�6V   
����� �6j   5  #   5     5     5     5      5!     5"     5#     5$     