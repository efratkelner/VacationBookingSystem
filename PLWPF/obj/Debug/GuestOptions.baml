   M S B A M L   `   `   `  ����@  <PLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLWPFPLWPF  5   	       PLWPF.GuestOptions   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:PLWPF     5   	     � Title$  
Vacation4U��5   	   $	��450��6   $	��800��6)    � Icon$ temps/icon.png��65   .��5	      � -   5         �Name$ GuestOptionsGrid��5	      ��5
   
   �� 5       �� ImageSource$ temps/unnamed.png��6   .+�5   
   �� -   5         ��Name$ btnAddRequest��5      $��הוספת בקשה��6(   $
��Left=�6=   $��46��6X   $��590,363,0,0q�6d   $	��Top=�6y   $	��159��6�   $
��Bold"�6�   �� 5   
   $��בס"ד��6   $
��Left=�6$   $��31��6?   $��	746,0,0,0q�6K   $	��Top=�6^   $��36��6v   �� 5   
   -   5        $ btnUpdateRequest��5      $��עדכון בקשה��6+   $
��Left=�6@   $��46��6[   $��395,363,0,0q�6g   $	��Top=�6|   $	��173��6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ lvGuestRequest��5      $��RightToLeft=�6+   $
��Left=�6G   $	��290��6b   $��	85,68,0,0q�6o   $	��Top=�6�   $	��615��6�    �� View 5      �� 5      .P�5      �� $�� ��6%    �� Width$ 20��60    �� DisplayMemberBinding 6;   �� *GuestRequestKey+�� 5      $(��"תאריך רישום למערכת��6%   $	 130��6A    6M   �� *RegistrationDate+�� 5      $)��#תאריך תחילת האירוח ��6%   $	 130��6B    6N   �� *	EntryDate+�� 5      $%��תאריך סןף האירוח ��6%   $	 130��6@    6L   �� *ReleaseDate+�� 5      $��
איזור��6%   $	 130��64    6@   �� *Area+�� 5      $��תת איזור��6%   $	 130��67    6C   �� *	SubArea+�� 5      $��מקום הנופש��6%   $	 130��69    6E   �� *Type+�� 5      $��מספר מבוגרים��6%   $	 130��6;    6G   �� *Adults+�� 5      $��מספר ילדים��6%   $	 130��69    6E   �� *
Children+�� 5      $��
בריכה��6%   $	 130��64    6@   �� *Pool+�� 5      $��ג'קוזי��6%   $	 130��65    6A   �� *	Jacuzzi+�� 5      $��גינה��6%   $	 130��63    6?   �� *Garden+�� 5       $#��אטרקציות לילדים��6%   $	 130��6>    6J   �� *ChildrensAttractions+�� 5!      $
��Wifi��6%   	 �� CellTemplate	 5"      �� 5#      .R�5$   "   �� {�.  
 d� 	IsChecked
 6=   �� *Wifi+5%      5'      �� 5(      $��מיטת תינוק��6%   	 5)      �� 5*      .R�5+   "   �� {�.  
 6=   �� *Cradle+5,      5.      �� 5/      $��ארוחת בוקר��6%   	 50      �� 51      .R�52   "   �� {�.  
 6=   �� *	Breakfast+53      55      56      58      �� 59   
   $��:הבקשות שלי��6   $
��Left=�6&   $��43��6A   $��
621,41,0,0q�6M   $	��Top=�6a   $	��106��6y   $
��Bold"�6�   �� 5:   
   -   5        $��btnMenu��5:   &   $��תפריט ראשי��6   $
��Left=�65   $��31��6P   $��
25,363,0,0q�6\   $	��Top=�6p   $	��121��6�    J� 	AllowDrop . $
��Bold"�6�   �� 5;   
   -   5        $��btnExit��5;   !   $��
יציאה��6   $
��Left=�60   $��27��6K   $��	10,12,0,0q�6W   $	��Top=�6j   $	��121��6�   $
��Bold"�6�   5=      5>      