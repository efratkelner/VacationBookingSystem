   M S B A M L   `   `   `  ����@  <PLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLWPFPLWPF  5   	       PLWPF.HostEntrance   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:PLWPF     5   	     � Title$  
אבטחה��5   	   $	��600��6   $	��300��6$    � Icon$ /temps/icon.png��60   ���	#FFF3EAEA � SizeToContent$ WidthAndHeight=�6^    � WindowState$ 	Maximized=�6}   $��RightToLeft=�6�    � WindowStartupLocation$ CenterScreen=�6�    � 
ResizeMode$ CanResizeWithGrip=�6�   .��5	      � -   5         �Name$ HostEntranceGrid��5	      $��	0,-21,2,0q�6%    � RowDefinitions 5
   
   �� 5      $	��57* �6   �� 5      $	��73* �6   ��5   
   �� 5       �� ImageSource$ temps/unnamed.png��6   	 � ColumnDefinitions	 5   
   �� 5      $��0* �6   �� 5      $��0* �6   �� 5      $	��43* �6   �� 5      $��0* �6   �� 5      $��7* �6   �� 5      $��0* �6   .+�5   
   �� -   5        
 ��Name$
 btnEnter��5      $��5��6#   $��
כניסה��67   $
��Left=�6G   $��41��6b   $��134,244,0,0q�6n   $	��Top=�6�   $	��134��6�   $
��Bold"�6�   $��16(�6�   $��1��6)  {�6�   ��  �� ElementName$ cbRobotCheck�� �� Mode$ OneWay=� �� Path$ 	IsChecked���5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ Black��6#    � Offset$ 1Q�61   � 5      $ White��6#   $ 0.807Q�61   � 5      $ 	#FFD5D5D5��6#   $ 0.237Q�65   � 5      $ Black��6#   $ 1Q�61   � 5       $ 	#FF784141��6#   5!      5#      �� 5$   
   $��מספר זהות��6   $
��Left=�6$   $��32��6?   $��	85,46,0,0q�6K   $	��Top=�6^   $	��115��6v   $
��Bold"�6�   $��16(�6�   $��2��6�   �� 5%   
   $��
סיסמא��6   $
��Left=�6    $��43��6;   $��
85,142,0,0q�6G   $	��Top=�6[   $	��107��6s   $
��Bold"�6   $��16(�6�   $��2��6�   �� 5&   
   -   5         ��Name$ 	txtUserID��5&      $��3��6%   $
��Left=�69   $��39��6T   $��	85,83,0,0q�6`    �� TextWrapping$
 Wrap=�6s   $	��Top=�6�   $	��183��6�   ���	#FF0C0404 �� 	MaxLength$ 9��6�   .��6�   ��5'      �� 5(      $ 0.5,1&�6&   $ 0.5,0&�67   .��5)      � $ Black��6#   $ 1Q�61   � 5*      $ White��6#   $ 0.767Q�61   5+      .��5,   "   5-      �� 5.   
   $��בס"ד��6   $
��Left=�6$   $��31��6?   $��	10,10,0,0q�6K   $	��Top=�6^   $��50��6v   $��2��6�   ��6�   Z� �� 5/   
   -   5         ��Name$ cbRobotCheck��5/      $��3��6*   $��אני לא רובוט��6>   $
��Left=�6U   $��34��6p   $��17,298,0,-1q�6|   $	��Top=�6�   $	��133��6�   $
��Bold"�6�   $��1��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   z�50      V� 51      .~�52      �� �� 53      �� 54       �� Angle$
 -0.6Q�6&   T� 55      56      ��58      �� 59      $ 0.5,1&�6&    � MappingMode$ RelativeToBoundingBox=�67   $ 0.5,0&�6[   .��5:      � $ White��6#   $
 0.84Q�61   5;      5=      G� 5?   
   -   5        $
��pBox��5?      $��3��6#    G� 	MaxLength$ 6��67    G� PasswordChar$ *��6E   $
��Left=�6W   $��41��6r   $��
85,190,0,0q�6~   $	��Top=�6�   $	��183��6�   �� 5@   
   -   5        $��btnNew��5@   %   $��3��6   $��מארח חדש��63   $��33��6F   $��149,96,10,0q�6R   $��1��6g   $	��Top=�6t   $
��Bold"�6�   ���	#FF01040E���	#FF0A09096�   5B      5C      