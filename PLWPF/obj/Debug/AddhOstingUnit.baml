   M S B A M L   `   `   `  ����@  <PLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLWPFPLWPF  5   	       PLWPF.AddhOstingUnit   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:PLWPF     5   	     � Title$&   הוספת יחידת אירוח��5   	   $	��450��6#   $	��800��60    � Icon$ /temps/icon.png��6<    � SizeToContent$ WidthAndHeight=�6S    � WindowState$ 	Maximized=�6r   $��RightToLeft=�6�    � WindowStartupLocation$ CenterScreen=�6�    � 
ResizeMode$ CanResizeWithGrip=�6�   .��5	      � $��
0,0,-6.4,0q�6   ��5
   
   �� 5       �� ImageSource$ temps/unnamed.png��6    � ColumnDefinitions 5   
   �� 5      $	��68* �6   �� 5      $��7* �6   �� 5      $
��321* �6   .+�5   
   �� $��בס"ד��6   $
��Left=�6$   $��29��6?   $��	10,10,0,0q�6K   $	��Top=�6^   $��54��6v   �� 5   
   $ ��מחיר לילה לילד��6   $
��Left=�6)   $��38��6D   $��
385,99,0,0q�6P   $	��Top=�6d   $	��147��6|   $��2��6�   �� 5   
   $&�� מחיר ללילה למבוגר��6   $
��Left=�6,   $��43��6G   $��385,137,0,0q�6S   $	��Top=�6h   $	��133��6�   $��2��6�   �� 5   
   -   5        $��txbPriceForChild��5      $
��Left=�6*   $��38��6E   $��
292,99,0,0q�6Q    �� TextWrapping$
 Wrap=�6e   $	��Top=�6�   $��67��6  $��2��6  ��6y   �� *PriceForChild+	 �� Mode$	 TwoWay=�
 �� ValidatesOnDataErrors
 .  �� NotifyOnValidationError .  �� ValidatesOnExceptions . 6  �� 5   
   -   5        $��txbPriceForAdult��5      $
��Left=�6*   $��43��6E   $��292,137,0,0q�6Q   $
 Wrap=�6f   $	��Top=�6�   $��67��6  $��2��6  ��6z   �� *PriceForAdult+$	 TwoWay=�
 .  .  . 6  �� 5   
   $"��שם יחידת האירוח��6   $
��Left=�6*   $��31��6E   $��
385,68,0,0q�6Q   $	��Top=�6e   $	��133��6}   $��2��6�   �� 5   
   -   5        $��txbHostingUnitName��5      $
��Left=�6,   $��38��6G   $��
292,56,0,0q�6S   $
 Wrap=�6g   $	��Top=�6�   $��67��6  $��2��6"  ��6{   �� *HostingUnitName+$	 TwoWay=�
 .  .  . 6"  �� 5   
   -   5        $��cmbArea��5      $
��Left=�6�   $��29��6�   $��292,199,0,0q�6�   $	��Top=�6�   $	��213��6�   $��2��6.  4  .System.Windows.Automation.AutomationProperties   HelpText$ אזור��6>   �� Text 6"   �� *
Enums.Area+$	 TwoWay=�
 .  .  . 6c  �� 5   
   -   5        $��btnAdd��5      $��הוסף��6!   $
��Left=�60   $��53��6K   $��359,332,0,0q�6W   $	��Top=�6l   $	��250��6�   $��2��6�   $
��Bold"�6�   ��5      �� 5      $ temps/unnamed.png��6   5      5       5!      