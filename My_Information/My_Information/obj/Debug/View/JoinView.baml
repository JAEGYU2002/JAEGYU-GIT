   M S B A M L   `   `   `  ����I  EMy_Information, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:My_Information.ViewMy_Information.View  5   	   "    My_Information.View.JoinView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:My_Information.View     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � Title$ JoinView��5
   	   $��288.5��6   $	��400��6)   .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��80 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��1��6!   $��Center=�61   $��Center=�6N   $
��JOIN��6i   $
��Bold"�6u   $��30(�6�   $��
81,4,157,6q�6�   $��74��6�   �� 5   
   $��1��6   $��0��6!   $��Center=�61   $��Center=�6N   $��ID��6i   $
��Bold"�6s   �� 5   
   $��1��6   $��1��6   $��10q�6/   ��6;   �� *ID+ �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   $��2��6   $��0��6!   $��Center=�61   $��Center=�6N   $��PASSWORD��6i   $
��Bold"�6y   �� 5    
   $��2��6   $��1��6   $��10q�6/   ��6;   �� *
PASSWORD+$ PropertyChanged=��� 5"   
   $��3��6   $��0��6!   $��Center=�61   $��Center=�6N   $
��NAME��6i   $
��Bold"�6u   �� 5#   
   $��3��6   $��1��6   $��10q�6/   ��6;   �� *NAME+$ PropertyChanged=��� 5%   
   $��4��6   $��1��6   $��70,10,140,10q�6.   $��submit��6D   $
��Bold"�6U   ��6g   Z� ��6~   �� *
JoinButton+5&      5'      