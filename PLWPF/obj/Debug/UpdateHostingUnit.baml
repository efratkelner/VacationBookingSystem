   M S B A M L   `   `   `  ����@  <PLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLWPFPLWPF  5   	       PLWPF.UpdateHostingUnit   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:PLWPF     5   	     � Title$&   עדכון יחידת אירוח��5   	   $	��450��6#   $	��500��60    � Icon$ /temps/icon.png��6<   .��5	      �� -   5         ��Name$ hostingUnitDetailsStack��5	      ��5
   
   �� 5       �� ImageSource$ temps/unnamed.png��6   .+�5   
   �� $��בס"ד��6   $
��Left=�6$   $��29��6?   $��	450,0,0,0q�6K   $	��Top=�6^   $��54��6v   $��2��6�   �� 5   
   -   5         ��Name$ cboxName��5      $
��Left=�6&   $��25��6A   $��	220,5,0,0q�6M   $	��Top=�6`   $	��120��6x   6�   �� 5   
   $2��,עדכן לפי שם יחידת האירוח��6   $
��Left=�64   $��33��6O   $��340,-20,0,0q�6[   $	��Top=�6p   $	��148��6�   �� 5   
   $ ��מחיר לילה לילד��6   $
��Left=�6)   $��38��6D   $��
390,30,0,0q�6P   $	��Top=�6d   $	��147��6|   �� 5   
   $&�� מחיר ללילה למבוגר��6   $
��Left=�6,   $��43��6G   $��370,-10,0,0q�6S   $	��Top=�6h   $	��133��6�   $��2��6�   �� 5   
   -   5        $��txbPriceForAdult��5      $
��Left=�6*   $��21��6E   $��300,-40,0,0q�6Q    �� TextWrapping$
 Wrap=�6f   $	��Top=�6�   $��67��6�   $��2��6�   ��6z   �� *PriceForChliid+6�   �� 5   
   -   5        $��txbPriceForChild��5      $
��Left=�6*   $��21��6E   $��300,-70,0,0q�6Q   $
 Wrap=�6f   $	��Top=�6�   $��67��6�   $��2��6�   ��6z   �� *PriceForAdult+6�   �� 5   
   $��
איזור��6   $
��Left=�6    $��31��6;   $��380,-15,0,0q�6G   $	��Top=�6\   $	��133��6t   $��2��6�   �� 5   
   -   5        $��AreaComboBox��5      $
��Left=�6F   $��29��6a   $��155,-30,0,0q�6m   $	��Top=�6�   $	��213��6�   $��2��6�    J� 	AllowDrop .   �� SelectedItem 6(   �� *Area+6�   �� 5   
   -   5         ��Name$ tbArea��5      $
��Left=�6:   $��17��6U   $��187,-35,0,0q�6a   $
��Wrap=�6v   $	��139��6�   ��6$   �� *Area+6�   �� 5   
   -   5        $��	btnUpdate��5   4   $��2��6   $��עדכן��6%   $
��Left=�6E   $��26��6`   $��
68,190,0,0q�6l   $	��Top=�6�   $��90��6�   $
��Bold"�6�   5      5      