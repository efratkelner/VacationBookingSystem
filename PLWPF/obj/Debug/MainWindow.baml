   M S B A M L   `   `   `  ����@  <PLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLWPFPLWPF  5   	       PLWPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:PLWPF     5   	   -   5          �Name$  
כניסה��5   	    � Title$ 
Vacation4U��5   	   $
��Auto��6   $
��Auto��6)    � SizeToContent$ WidthAndHeight=�67    � Icon$ /temps/icon.png��6V    � WindowState$ 	Maximized=�6m   $��RightToLeft=�6�    � WindowStyle$
 None=�6�    � WindowStartupLocation$ CenterScreen=�6�    � 
ResizeMode$ CanResizeWithGrip=�6�   .��5
      � 4  .System.Windows.Automation.AutomationProperties   HelpText$ 
כניסה��6   $��0,0,-8,0q�61   $	��849��6C   $
��1771��6P   ��5   
   �� 5      	 �� ImageSource$	 temps/image.png��6   
 � RowDefinitions
 5   
   �� 5      $
��214* �6   �� 5      $
��213* �6    � ColumnDefinitions 5   
   �� 5      �� 5      $	��65* �6   �� 5      $	��76* �6   �� 5      $
��980* �6   .+�5   
   �� $��
Vacation4U��6   $��Right=�6&   $	��358��6B   $��	0,31,41,0q�6O   $	��Top=�6b   $
��1000��6z   $	��100(�6�   $
��Bold"�6�   $��Broadway)�6�   $��3��6�   ��5      �� 5       �� 
TargetType" ��6    �� Triggers 5       :� 5!       :� RoutedEvent$ 
MouseEnter��6'   [�5"      �� 5#   "   .��5$   &   �� .��5%   *   W�  g� Duration$ 	0:0:0.300D�6:    �� TargetProperty$ FontSize�6O   	 W� To$	 100X�6t   5&   '   5'   #   5)      :� 5*      $ 
MouseLeave��6'   [�5+      �� 5,   "   .��5-   &   �� .��5.   *   W� $ 	0:0:0.800D�6:   $ FontSize�6O   $ 48X�6t   5/   '   50   #   52      54      56      �� 57   
   -   5         ��Name$ btnHost_Copy��57      $��אני רוצה לארח��6'   $
��Left=�6?   $	��161��6Z   $��
79,259,0,0q�6g   $	��Top=�6{   $	��575��6�   $
��Bold"�6�   $��72(�6�   $��1��6�   $��3��6  $��Guttman-Aharoni)�6  ��6�   Z� ��62  Z� �� 58   
   -   5        $ btnGuest��58      $"��אני רוצה להתארח��6#   $
��Left=�6=   $	��147��6X   $��79.4,10.4,0,0q�6e   $	��Top=�6|   $	��575��6�   $
��Bold"�6�   $��72(�6�   $��1��6�   $��3��6�   $��Guttman-Aharoni)�6�   $��1��6.  ��6  Z� ��6;  Z� �� 59   
   -   5        $ 
btnManager��59      $��
ניהול��6%   $
��Left=�65   $��33��6P   $��1045,394,0,0q�6\   $	��Top=�6r   $��69��6�   $��20(�6�   $��3��6�   $��Guttman-Aharoni)�6�   ���	#FF0B0B0C$
��Bold"�6   J� RenderTransformOrigin$ 
1.53,1.018&�6?  $��2��6b  ��6�   Z� ��6(  Z� 6b  �� 5:   
   $��בס"ד��6   $
��Left=�6$   $��32��6?   $	��Top=�6K   $��38��6c   $��2��6n   $
��Bold"�6~   $��0,31,0,0q�6�   �� 5;   
   -   5        $��btnExit��5;   !   $��
יציאה��6   $��3��60   $
��Left=�6@   $��37��6[   $��1023,37.4,0,0q�6g   $��1��6~   $	��Top=�6�   $	��109��6�   $
��Bold"�6�   $��16(�6�   $��Papyrus)�6�   ���	#FF07060E$ 0.433,1.543&�6>  ��6�   Z� ��6'  Z�  J� OpacityMask 5<      �� 5=       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5>      �  � Color$ Black��6#    � Offset$ 0Q�61   � 5?      $ White��6#   $ 1Q�61   5@      5B      5D      5E      